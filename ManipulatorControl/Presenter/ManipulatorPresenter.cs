using GCodeParser;
using LptStepperMotorControl.PortControl;
using LptStepperMotorControl.Stepper;
using ManipulatorControl.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UM160CalculationLib;
using Newtonsoft.Json;
using System.IO;
using ManipulatorControl.Workspace;
using ManipulatorControl.MessageService;
using ManipulatorControl.Settings;
using ManipulatorControl.Model;

namespace ManipulatorControl
{
    // TODO: 
    // * рабочие зоны робота: проверка текущего положения при задании новой рабочей зоны, переезд к нулевому значению или к ближайшему в границах.
    // * добавить уведомления об успешных действиях, ошибках и тд.
    // * Переработать сохранение параметров.
    public class ManipulatorPresenter
    {
        private readonly IMessageService messageService;
        private readonly IManipulatorControlView view;
        private readonly ISettingsView settings;

        private DesignParameters parameters;
        private readonly Calculation calculation;

        private readonly StepperWorker worker = new StepperWorker(100);
        private LPTPort port = new LPTPort();

        private readonly GCodeInterpreter interpreter;
        private readonly Parser parser;

        private List<LeverStepper> leverSteppers = new List<LeverStepper>();
        private readonly RobotLever[] levers;
        private RobotLever movingLever;

        private int editingWorkspaceIndex = -1;
        private List<RobotWorkspace> robotWorkspaces = new List<RobotWorkspace>();
        private RobotWorkspace activeWorkspace, editingWorkspace;

        private double x, y, z;

        public ManipulatorPresenter(IManipulatorControlView view, IMessageService messageService)
        {
            this.view = view;
            this.settings = new SettingsForm();
            this.messageService = messageService;

            this.parameters = LoadDesignParameters();
            this.calculation = new Calculation(parameters);
            this.interpreter = new GCodeInterpreter(this.calculation);
            this.parser = new Parser(interpreter);

            this.settings.SaveSettings += Settings_SaveSettings;

            this.view.OnViewClosing += View_OnViewClosing;

            this.view.ManualControlStart += MoveLeverStart;
            this.view.ManualControlStop += View_ManualControlStop;
            this.view.InvokeStepperAbort += View_InvokeStepperAbort;
            this.view.InvokeStepperStop += View_InvokeStepperStop;
            this.view.RunGCodeInterpreter += View_RunGCodeInterpreter;
            this.view.OpenSettings += View_OpenSettings;

            // Подписка на события для редактирования рабочих зон.
            this.view.InvokeSetActiveWorkspace += View_InvokeSetActiveWorkspace;
            this.view.InvokeSetEditWorkspaceMode += View_InvokeSetEditWorkspaceMode;  
            this.view.OnActiveEditingLeverChanged += View_OnActiveEditingLeverChanged;   
            this.view.InvokeWorkspaceValueChange += View_InvokeWorkspaceValueChange;      
            this.view.InvokeSaveWorkspaceValues += View_InvokeSaveWorkspaceValues;
            this.view.InvokeCloseEditWorkspaceMode += View_InvokeCloseEditWorkspaceMode;   
            this.view.InvokeRemoveWorkspace += View_InvokeRemoveWorkspace;
            this.view.InvokeAddWorkspace += View_InvokeAddWorkspace;
            this.view.InvokeRenameWorkspace += View_InvokeRenameWorkspace;

            this.worker.OnStart += Worker_OnStart;
            this.worker.OnStop += Worker_OnStop;
            this.worker.OnStop += interpreter.OnStepperStop;
            this.worker.Elapsed += Worker_Elapsed;

            this.interpreter.OnInterpreterStart += Interpreter_OnInterpreterStart;
            this.interpreter.OnInterpreterStop += Interpreter_OnInterpreterStop;
            this.interpreter.OnInvokeStartStepper += MoveLeverStart;


            LoadApplicationSettings();
            this.levers = GetRobotLever().ToArray();
        }

        public void SetWorkerInterval(int interval)
        {
            worker.Interval = interval;

            messageService.ShowExclamation(interval.ToString());
        }

        private void SetNewCoordinateLocation()
        {
            calculation.SetCurrentCoordinates(ref x, ref y, ref z);
            this.view.SetCurrentPosition(false, x, y, z);
        }

        #region Загрузка параметров, значений.

        private void LoadApplicationSettings()
        {   
            if (this.parameters == null)
                throw new NullReferenceException();

            LoadStepDirNames();

            robotWorkspaces.Add(GetDesignParametersWorkspace("Конструктивные параметры"));
            LoadWorkspaces();

            SetNewCoordinateLocation();
        }

        private DesignParameters LoadDesignParameters()
        {
            var parameters = JsonConvert.DeserializeObject<DesignParameters>(File.ReadAllText("design.settings"));

            RemoveWorkspacesFromDesignParameters(parameters);
            SetSavedCurrentPositionToDesignParameters(parameters);

            return parameters;
        }

        #region Обращение к параметрам приложения.

        private void SetSavedCurrentPositionToDesignParameters(DesignParameters parameters)
        {
            parameters.HorizontalLever.AB = Properties.Settings.Default.HorizontalLeverAB;
            parameters.Lever1.AB = Properties.Settings.Default.Lever1AB;
            parameters.Lever2.AB = Properties.Settings.Default.Lever2AB;
        }

        private void GetSavedCurrentPositionFromDesignParameters(DesignParameters parameters)
        {
            Properties.Settings.Default.HorizontalLeverAB = parameters.HorizontalLever.AB;
            Properties.Settings.Default.Lever1AB = parameters.Lever1.AB;
            Properties.Settings.Default.Lever2AB = parameters.Lever2.AB;

            Properties.Settings.Default.Save();
        }

        private void SaveLeverCurrentPosition(LeverType type, double currentPosition)
        {
            if (type == LeverType.Horizontal)
                Properties.Settings.Default.HorizontalLeverAB = currentPosition;
            if (type == LeverType.Lever1)
                Properties.Settings.Default.Lever1AB = currentPosition;
            if (type == LeverType.Lever2)
                Properties.Settings.Default.Lever2AB = currentPosition;

            Properties.Settings.Default.Save();
        }

        #endregion

        private void RemoveWorkspacesFromDesignParameters(DesignParameters parameters)
        {
            parameters.Lever1.Workspace = null;
            parameters.Lever2.Workspace = null;
            parameters.HorizontalLever.Workspace = null;
        }
                              
        private void UpdateDesignParameters(DesignParameters designParameters)
        {
            if (parameters == designParameters)
                return;

            this.parameters = designParameters;
            calculation.DesignParameters = designParameters;
            GetSavedCurrentPositionFromDesignParameters(designParameters);
            robotWorkspaces[0] = GetDesignParametersWorkspace("Конструктивные параметры");

            view.SetWorkspaces(robotWorkspaces, robotWorkspaces.IndexOf(activeWorkspace ?? robotWorkspaces.FirstOrDefault()));

            SetNewCoordinateLocation();
        }

        private void LoadWorkspaces()
        {
            try
            {
                var workspaces = JsonConvert.DeserializeObject<List<RobotWorkspace>>(File.ReadAllText("workspaces.settings"), new WorkspaceConverter());
                activeWorkspace = null;
                editingWorkspace = null;
                robotWorkspaces.AddRange(workspaces);
            }
            catch(Exception e)
            {
                messageService.ShowError(e.Message);                
            }

            view.SetWorkspaces(robotWorkspaces);   

            //view.SetZeroPositionState(GetSettedZeroCoordinates(activeWorkspace));
            view.SetWorkspaces(robotWorkspaces);
        }

        private void SaveWorkspaces()
        {
            try
            {
                var settings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                settings.Converters.Add(new WorkspaceConverter());
                settings.Formatting = Formatting.Indented;

                File.WriteAllText("workspaces.settings", JsonConvert.SerializeObject(robotWorkspaces.Skip(1), settings));
            }
            catch (Exception e)
            {
                messageService.ShowError(e.Message);
            }
        }

        private void LoadStepDirNames()
        {
            try
            {
                var stepDirNames = JsonConvert.DeserializeObject<List<StepDirName>>(File.ReadAllText("stepDirNames.settings"));
                this.settings.StepDirNames = stepDirNames;
            }
            catch (Exception e)
            {
                messageService.ShowError(e.Message);
            }
        }

        private void SaveStepDirNames()
        {
            try
            {
                File.WriteAllText("stepDirNames.settings", JsonConvert.SerializeObject(settings.StepDirNames));
            }
            catch (Exception e)
            {
                messageService.ShowError(e.Message);
            }
        }

        private void LoadLeverSteppers()
        {
            try
            {
                leverSteppers = JsonConvert.DeserializeObject<List<LeverStepper>>(File.ReadAllText("leverSteppers.settings"));
                this.settings.LeverSteppers = leverSteppers;
            }
            catch (Exception e)
            {
                messageService.ShowError(e.Message);
            }
        }

        private void SaveLeverSteppers()
        {
            try
            {
                File.WriteAllText("leverSteppers.settings", JsonConvert.SerializeObject(settings.LeverSteppers));

                foreach (var lever in levers)
                {
                    var stepper = settings.LeverSteppers.Single(l => l.LeverType == lever.Type).Stepper;
                    lever.Stepper.Acceleration = stepper.Acceleration;
                    lever.Stepper.MaxSpeed = stepper.MaxSpeed;
                    lever.Stepper.CWDirectionIsLogicalZero = stepper.CWDirectionIsLogicalZero;
                }
            }
            catch (Exception e)
            {
                messageService.ShowError(e.Message);
            }
        }

        private IEnumerable<RobotLever> GetRobotLever()
        {
            LoadLeverSteppers();

            foreach (var stepper in leverSteppers)
            {
                stepper.Stepper.Port = port;
                stepper.Stepper.Pins = this.settings.StepDirNames.Single(s => s.Type == stepper.PinType).StepDir;
            }

            yield return new RobotLever(LeverType.Horizontal, leverSteppers.Single(lever => lever.LeverType == LeverType.Horizontal).Stepper);

            yield return new RobotLever(LeverType.Lever1, leverSteppers.Single(lever => lever.LeverType == LeverType.Lever1).Stepper);

            yield return new RobotLever(LeverType.Lever2, leverSteppers.Single(lever => lever.LeverType == LeverType.Lever2).Stepper);    
        }

        #endregion

        private void Settings_SaveSettings(object sender, EventArgs e)
        {
            UpdateDesignParameters(this.settings.DesignParameters);

            var settings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            File.WriteAllText("design.settings", JsonConvert.SerializeObject(this.settings.DesignParameters, settings));

            SaveStepDirNames();
            SaveLeverSteppers();
        }

        private void View_OpenSettings(object sender, EventArgs e)
        {
            if (movingLever != null || view.IsEditWorkspaceMode)
                return;

            this.settings.DesignParameters = parameters;
            this.settings.Show();
        }
        
        // Cохранение параметров перед закрытием.
        private void View_OnViewClosing(object sender, EventArgs e)
        {
            SaveWorkspaces();

            if (movingLever == null)
                return;

            worker.Stop();
        }

        #region Рабочие зоны манипулятора.

        // Устанавливает в качестве рабочей зоны конструктивные параметры робота.
        private void SetDefaultWorkspace()
        {
            RemoveWorkspacesFromDesignParameters(this.parameters);
            this.activeWorkspace = null;
        }

        // Возвращает копию рабочей зоны соответствующую конструктивным параметрам робота.
        private RobotWorkspace GetDesignParametersWorkspaceClone(string name)
        {
            if (parameters == null)
                return null;

            var workspace = new RobotWorkspace(name);
            workspace.HorizontalLever = parameters.HorizontalLever.Clone() as LeverWorkspace;
            workspace.Lever1 = parameters.Lever1.Clone() as LeverWorkspace;
            workspace.Lever2 = parameters.Lever2.Clone() as LeverWorkspace;

            return workspace;
        }

        // Возвращает копию рабочей зоны соответствующую конструктивным параметрам робота.
        private RobotWorkspace GetDesignParametersWorkspace(string name)
        {
            if (parameters == null)
                return null;

            var workspace = new RobotWorkspace(name);
            workspace.HorizontalLever = parameters.HorizontalLever as IPartMovable;
            workspace.Lever1 = parameters.Lever1 as IPartMovable;
            workspace.Lever2 = parameters.Lever2 as IPartMovable;

            return workspace;
        }

        // Устанавливает заданную рабочую зону в качестве активной рабочей зоны.
        private void SetActiveWorkspace(RobotWorkspace workspace)
        {
            parameters.Lever1.Workspace = workspace.Lever1;
            parameters.Lever2.Workspace = workspace.Lever2;
            parameters.HorizontalLever.Workspace = workspace.HorizontalLever;

            activeWorkspace = workspace;
        }

        // Происходит при изменении активного плеча робота-манипулятора, значения которого редактируются пользователем.
        private void View_OnActiveEditingLeverChanged(object sender, EditWorkspaceEventArgs e)
        {
            view.SetCurrentEditWorkspaceModeLeverPosition(e.LeverType, calculation.GetPartMovableByLeverType(e.LeverType).AB);
            view.SetRobotWorkspaceParams(editingWorkspace);
        }

        // Задать выбранную зону как активную рабочую зону.
        private void View_InvokeSetActiveWorkspace(object sender, WorkspaceEventArgs e)
        {
            if (view.IsEditWorkspaceMode)
                return;

            SetActiveWorkspace(robotWorkspaces.ElementAtOrDefault(e.Index));
        }

        // Переименовать рабочую зону.
        private void View_InvokeRenameWorkspace(object sender, WorkspaceEventArgs e)
        {
            if (view.IsEditWorkspaceMode)
                return;

            if (e.Index == 0)
                throw new Exception("Нельзя переименовать данную рабочу область");

            var workspace = robotWorkspaces.ElementAtOrDefault(e.Index);

            if (workspace == null)
                throw new Exception("Указанная рабочая область не существует");

            workspace.Name = e.Name;

            view.SetWorkspaces(robotWorkspaces, e.Index);
        }

        // Добавить рабочую зону.
        private void View_InvokeAddWorkspace(object sender, WorkspaceEventArgs e)
        {
            if (view.IsEditWorkspaceMode)
                return;

            var workspace = GetDesignParametersWorkspaceClone(e.Name);
            robotWorkspaces.Add(workspace);
            view.SetWorkspaces(robotWorkspaces, robotWorkspaces.Count - 1);
        }

        // Удалить рабочую зону.
        private void View_InvokeRemoveWorkspace(object sender, WorkspaceEventArgs e)
        {
            if (view.IsEditWorkspaceMode)
                return;

            if (e.Index < 0)
                throw new IndexOutOfRangeException();

            if (e.Index == 0)
            {
                messageService.ShowMessage("Нельзя удалить данную рабочу область");
                return;
            }

            robotWorkspaces.RemoveAt(e.Index);
            view.SetWorkspaces(robotWorkspaces, e.Index - 1);
        }

        // Отменить изменения.
        private void View_InvokeCloseEditWorkspaceMode(object sender, WorkspaceEventArgs e)
        {
            view.SetEditWorkspaceMode(false, null, MovableValueType.None);
            view.SetWorkspaces(robotWorkspaces, editingWorkspaceIndex);
            editingWorkspace = null;
            editingWorkspaceIndex = -1;
            return;
        }

        // Сохранить изменения.
        private void View_InvokeSaveWorkspaceValues(object sender, WorkspaceEventArgs e)
        {
            if (!view.IsEditWorkspaceMode || editingWorkspace == null)
                return;

            var errors = editingWorkspace.GetDesignParametersExceptions(this.parameters);

            if (errors.Count() == 0)
            {
                view.SetEditWorkspaceMode(false, null, MovableValueType.None);
                this.robotWorkspaces[editingWorkspaceIndex] = editingWorkspace;
                view.SetWorkspaces(robotWorkspaces, editingWorkspaceIndex);
                editingWorkspace = null;
                editingWorkspaceIndex = -1;
                return;
            }

            string errorMessage = "Рабочая зона не сохранена. Ошибки:";

            foreach (var error in errors)
            {
                errorMessage += String.Format("\n\n{0} : {1}", (error.Key).ToRuString(), error.Value.Message);
            }

            messageService.ShowError(errorMessage);
        }

        // Установить режим редактирования рабочей зоны.
        private void View_InvokeSetEditWorkspaceMode(object sender, WorkspaceEventArgs e)
        {
            SetDefaultWorkspace();
            editingWorkspace = robotWorkspaces[e.Index].Clone() as RobotWorkspace;

            var editValues = MovableValueType.Zero;

            if (e.Index != 0)
                editValues |= MovableValueType.Max | MovableValueType.Min;

            editingWorkspaceIndex = e.Index;

            view.SetEditWorkspaceMode(true, editingWorkspace, editValues);
        }

        //  Изменение ограничений и задание нулевой точки для плеч робота.
        private void View_InvokeWorkspaceValueChange(object sender, EditWorkspaceEventArgs e)
        {
            if (editingWorkspace == null || e.ValueType == MovableValueType.None)
                return;

            editingWorkspace.SetValue(e.LeverType, e.ValueType, calculation.GetPartMovableByLeverType(e.LeverType).AB);

            view.SetRobotWorkspaceParams(editingWorkspace);
        }

        #endregion
        
        #region Остановка и прерывание работы.

        private void View_InvokeStepperStop(object sender, EventArgs e)
        {
            worker.Stop();
        }

        private void View_InvokeStepperAbort(object sender, EventArgs e)
        {
            worker.Abort();
        }

        #endregion

        #region Перемещение плечей робота-манипулятора. Ручное управление. Управление G кодами.  
         
        private void ChangeLeverPosition(LeverType type, long stepsCount)
        {
            calculation.SetNewAB(type, stepsCount);

            var newValue = calculation.GetPartMovableByLeverType(type).AB;

            if (view.IsEditWorkspaceMode)
                view.SetCurrentEditWorkspaceModeLeverPosition(type, newValue);

            SaveLeverCurrentPosition(type, newValue);

            view.SetZeroPositionState(parameters.Lever1.AB == parameters.Lever1.Workspace.ABzero && parameters.Lever2.AB == parameters.Lever2.Workspace.ABzero, parameters.HorizontalLever.AB == parameters.HorizontalLever.Workspace.ABzero);
            SetNewCoordinateLocation();
        }

        private void Interpreter_OnInterpreterStop(object sender, EventArgs e)
        {
            Debug.WriteLine("INTERPRETER STOP");
        }

        private void Interpreter_OnInterpreterStart(object sender, EventArgs e)
        {
            Debug.WriteLine("INTERPRETER START");
        }

        private void View_RunGCodeInterpreter(object sender, EventArgs e)
        {
            if (view.IsManualControlMode)
                return;

            try
            {
                var result = parser.Parse(view.GCodeLines);
                view.ParserErrors = parser.Errors;

                if (result)
                    interpreter.StartInterprete(parser.CommandQueue);
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void Worker_Elapsed(object sender, EventArgs e)
        {
            if (movingLever == null)
                return;

            if (movingLever.Type == LeverType.Horizontal)
                z = calculation.GetZ(movingLever.Stepper.CurrentStepsCount);
            else
                calculation.GetXY(movingLever.Type, movingLever.Stepper.CurrentStepsCount, out x, out y);
            this.view.SetCurrentPosition(true, x, y, z);
        }

        private void Worker_OnStop(object sender, EventArgs e)
        {
            ChangeLeverPosition(movingLever.Type, movingLever.Stepper.CurrentStepsCount);

            //view.Directions ^= movingLever.ActiveDirection;

            var leverDesignParams = calculation.GetPartMovableByLeverType(movingLever.Type);

            movingLever = null;
        }

        private void Worker_OnStart(object sender, EventArgs e)
        {
            //view.Directions = movingLever.ActiveDirection;
        }
        
        private void View_ManualControlStop(object sender, StepLever stepLever)
        {
            if (!worker.Enabled)
                return;

            worker.Stop();
        }

        private void MoveLeverStart(object sender, StepLever stepLever)
        {
            if (worker.Stepper!= null && worker.Stepper.Enabled)
                return;

            if (view.IsManualControlMode)
            {
                if (stepLever.StepsCount == 0)
                    stepLever.StepsCount = calculation.CalculateStepsToLeverZero(stepLever.Lever);
                else
                    stepLever.StepsCount = calculation.CalculateStepsByDirection(stepLever.Lever, stepLever.StepsCount == 1);
            }

            if (stepLever.StepsCount == 0)
                return;

            movingLever = levers.Single(lever => lever.Type == stepLever.Lever);

            worker.Stepper = movingLever.Stepper;
            worker.Stepper.TargetStepsCount = stepLever.StepsCount;

            new Task(worker.Start).Start(); 
        }

        #endregion
    }
}
