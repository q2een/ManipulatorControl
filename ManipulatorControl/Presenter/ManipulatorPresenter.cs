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
using ManipulatorControl.MessageService;
using ManipulatorControl.Settings;
using ManipulatorControl.BL;
using ManipulatorControl.BL.Workspace;
using ManipulatorControl.BL.Script;

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
        private LPTPort port = new LPTPort();
        private ScriptBuilder scriptBuilder;

        private readonly LeverMovement leverMovement;
        private readonly RobotMovement movement;
        private readonly WorkspaceManager workspaceManager;

        private List<Settings.LeverStepper> leverSteppers = new List<Settings.LeverStepper>();
        private readonly BL.LeverStepper[] levers;

        private int editingWorkspaceIndex = -1;
        private RobotWorkspace editingWorkspace;

        public ManipulatorPresenter(IManipulatorControlView view, IMessageService messageService)
        {
            this.view = view;
            this.settings = new SettingsForm();
            this.messageService = messageService;

            this.parameters = LoadDesignParameters();

            this.settings.SaveSettings += Settings_SaveSettings;

            this.view.OnViewClosing += View_OnViewClosing;

            this.view.ManualControlStart += View_ManualControlStart;
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

            this.view.InvokeCreateScript += View_InvokeCreateScript;
            this.view.InvokeScriptBackTo += View_InvokeScriptBackTo;


            LoadApplicationSettings();
            this.levers = GetRobotLever().ToArray();

            leverMovement = new LeverMovement(port, levers);

            movement = new RobotMovement(new Calculation(parameters), leverMovement);

            workspaceManager = new WorkspaceManager(parameters, LoadWorkspaces());
            workspaceManager.OnActiveWorkspaceChanged += WorkspaceManager_OnActiveWorkspaceChanged;
            workspaceManager.ActiveWorkspace = GetActiveRobotWorkspace();

            movement.LocationChanged += Movement_LocationChanged;
            movement.LeverPositionChanged += Movement_LeverPositionChanged;
            movement.OnZeroPositionChanged += Movement_OnZeroPositionChanged;
            movement.OnMovingStart += Movement_OnMovingStart;
            movement.OnMovingEnd += Movement_OnMovingEnd;

            Movement_LocationChanged(false, movement.Calculation.GetCurrentLocation());

            view.SetWorkspaces(workspaceManager.RobotWorkspaces, workspaceManager.ActiveWorkspaceIndex);

            view.SetCurrentPosition(new LeverPosition(LeverType.Horizontal, movement.GetLeverPosition(LeverType.Horizontal)));
            view.SetCurrentPosition(new LeverPosition(LeverType.Lever1, movement.GetLeverPosition(LeverType.Lever1)));
            view.SetCurrentPosition(new LeverPosition(LeverType.Lever2, movement.GetLeverPosition(LeverType.Lever2)));
        }

        private void View_InvokeScriptBackTo(object sender, LeverScriptPosition e)
        {
            try
            {
                scriptBuilder.BackTo(e);
            }
            catch(Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_InvokeCreateScript(object sender, EventArgs e)
        {
            scriptBuilder = new ScriptBuilder(movement); 
            scriptBuilder.SetCurrentPositionAsStart();

            scriptBuilder.OnPathChanged += ScriptBuilder_OnPathChanged;
        }

        private void ScriptBuilder_OnPathChanged(object sender, EventArgs e)
        {
            view.SetScriptQueue(scriptBuilder.Path);         
        }

        #region Загрузка параметров, значений.

        private void LoadApplicationSettings()
        {   
            if (this.parameters == null)
                throw new NullReferenceException();

            LoadStepDirNames();
        }

        private DesignParameters LoadDesignParameters()
        {
            var parameters = JsonConvert.DeserializeObject<DesignParameters>(File.ReadAllText("design.settings"));

            WorkspaceManager.RemoveWorkspacesFromDesignParameters(parameters);
            SetSavedCurrentPositionToDesignParameters(parameters);

            return parameters;
        }

        #region Обращение к параметрам приложения.

        private RobotWorkspace GetActiveRobotWorkspace()
        {

            return JsonConvert.DeserializeObject<RobotWorkspace>(Properties.Settings.Default.ActiveWorkspace, new WorkspaceConverter());
        }

        private void SaveActiveRobotWorkspace(RobotWorkspace workspace)
        {
            var settings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            settings.Converters.Add(new WorkspaceConverter());
            settings.Formatting = Formatting.Indented;

            Properties.Settings.Default.ActiveWorkspace = JsonConvert.SerializeObject(workspace, settings);
            Properties.Settings.Default.Save();
        }

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
                              
        private void UpdateDesignParameters(DesignParameters designParameters)
        {
            if (parameters == designParameters)
                return;

            parameters.HorizontalLever = designParameters.HorizontalLever;
            parameters.L1 = designParameters.L1;
            parameters.L2 = designParameters.L2;
            parameters.Lc = designParameters.Lc;
            parameters.Lever1 = designParameters.Lever1;
            parameters.Lever2 = designParameters.Lever2;

            GetSavedCurrentPositionFromDesignParameters(designParameters);

            view.SetWorkspaces(workspaceManager.RobotWorkspaces, workspaceManager.ActiveWorkspace != null ? workspaceManager.RobotWorkspaces.IndexOf(workspaceManager.ActiveWorkspace) : 0);

            Movement_LocationChanged(false, movement.Calculation.GetCurrentLocation());
        }

        private List<RobotWorkspace> LoadWorkspaces()
        {
            try
            {
                return JsonConvert.DeserializeObject<List<RobotWorkspace>>(File.ReadAllText("workspaces.settings"), new WorkspaceConverter());
            }
            catch(Exception e)
            {
                messageService.ShowError(e.Message);                
            }

            return new List<RobotWorkspace>();
        }

        private void SaveWorkspaces()
        {
            try
            {
                var settings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                settings.Converters.Add(new WorkspaceConverter());
                settings.Formatting = Formatting.Indented;

                File.WriteAllText("workspaces.settings", JsonConvert.SerializeObject(workspaceManager.RobotWorkspaces.Skip(1), settings));
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
                leverSteppers = JsonConvert.DeserializeObject<List<Settings.LeverStepper>>(File.ReadAllText("leverSteppers.settings"));
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

        private IEnumerable<BL.LeverStepper> GetRobotLever()
        {
            LoadLeverSteppers();

            foreach (var stepper in leverSteppers)
            {
                stepper.Stepper.Port = port;
                stepper.Stepper.Pins = this.settings.StepDirNames.Single(s => s.Type == stepper.PinType).StepDir;
            }

            yield return new BL.LeverStepper(LeverType.Horizontal, leverSteppers.Single(lever => lever.LeverType == LeverType.Horizontal).Stepper);

            yield return new BL.LeverStepper(LeverType.Lever1, leverSteppers.Single(lever => lever.LeverType == LeverType.Lever1).Stepper);

            yield return new BL.LeverStepper(LeverType.Lever2, leverSteppers.Single(lever => lever.LeverType == LeverType.Lever2).Stepper);    
        }

        #endregion

        private void Settings_SaveSettings(object sender, EventArgs e)
        {
            try
            {
                UpdateDesignParameters(this.settings.DesignParameters);

                var settings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                File.WriteAllText("design.settings", JsonConvert.SerializeObject(this.settings.DesignParameters, settings));

                SaveStepDirNames();
                SaveLeverSteppers();
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_OpenSettings(object sender, EventArgs e)
        {
            if (movement.IsRunning || view.IsEditWorkspaceMode)
                return;

            this.settings.DesignParameters = parameters;
            this.settings.Show();
        }
        
        // Cохранение параметров перед закрытием.
        private void View_OnViewClosing(object sender, EventArgs e)
        {
            SaveWorkspaces();

            movement.Stop();
        }

        #region Рабочие зоны манипулятора.

        private void WorkspaceManager_OnActiveWorkspaceChanged(object sender, EventArgs e)
        {
            view.SetCurrentWorkspace(workspaceManager.ActiveWorkspace);
            SaveActiveRobotWorkspace(workspaceManager.ActiveWorkspace);
        }

        // Происходит при изменении активного плеча робота-манипулятора, значения которого редактируются пользователем.
        private void View_OnActiveEditingLeverChanged(object sender, EditWorkspaceEventArgs e)
        {
            view.SetCurrentEditWorkspaceModeLeverPosition(e.LeverType, movement.GetLeverPosition(e.LeverType));
            view.SetRobotWorkspaceParams(editingWorkspace);
        }

        // Задать выбранную зону как активную рабочую зону.
        private void View_InvokeSetActiveWorkspace(object sender, WorkspaceEventArgs e)
        {
            if (view.IsEditWorkspaceMode)
                return;

            try
            {
                var workspace = workspaceManager.RobotWorkspaces[e.Index];

                var action = new Action(() =>
                {
                    workspaceManager.ActiveWorkspace = workspace;
                    messageService.ShowMessage(string.Format("Рабочая зона «{0}» установлена в качестве активной", workspace.Name));
                });

                if (workspaceManager.IsRobotInWorkspace(workspace))
                {
                    action();
                    return;
                }

                if(messageService.ShowExclamation("Робот находится вне выбранной рабочей зоны. Переместить плечи робота в нулевую точку ?") == UserResponse.OK)
                {
                    movement.MoveRobotByPath(workspaceManager.GetLeverPositionsToWorkspaceZero(workspace), action);
                }
                
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        // Переименовать рабочую зону.
        private void View_InvokeRenameWorkspace(object sender, WorkspaceEventArgs e)
        {
            if (view.IsEditWorkspaceMode)
                return;
            try
            {
                workspaceManager.Rename(e.Index, e.Name);

            view.SetWorkspaces(workspaceManager.RobotWorkspaces, e.Index);
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        // Добавить рабочую зону.
        private void View_InvokeAddWorkspace(object sender, WorkspaceEventArgs e)
        {
            if (view.IsEditWorkspaceMode)
                return;
            try
            {
                workspaceManager.Add(e.Name);

                view.SetWorkspaces(workspaceManager.RobotWorkspaces, workspaceManager.RobotWorkspaces.Count - 1);
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        // Удалить рабочую зону.
        private void View_InvokeRemoveWorkspace(object sender, WorkspaceEventArgs e)
        {
            if (view.IsEditWorkspaceMode)
                return;
            try
            {
                if (messageService.ShowExclamation("Вы действительно хотите удалить выбранную рабочую зону") == UserResponse.OK)
                {
                    workspaceManager.Remove(e.Index);

                    view.SetWorkspaces(workspaceManager.RobotWorkspaces, e.Index - 1);
                }
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        // Отменить изменения.
        private void View_InvokeCloseEditWorkspaceMode(object sender, WorkspaceEventArgs e)
        {
            view.SetEditWorkspaceMode(false, null, MovableValueType.None);
            view.SetWorkspaces(workspaceManager.RobotWorkspaces, editingWorkspaceIndex);
            editingWorkspace = null;
            editingWorkspaceIndex = -1;
            return;
        }

        // Сохранить изменения.
        private void View_InvokeSaveWorkspaceValues(object sender, WorkspaceEventArgs e)
        {
            if (!view.IsEditWorkspaceMode || editingWorkspace == null)
                return;

            try
            {
                var errors = editingWorkspace.GetDesignParametersExceptions(this.parameters);

                if (errors.Count() == 0)
                {
                    view.SetEditWorkspaceMode(false, null, MovableValueType.None);

                    workspaceManager.SetWorkspace(editingWorkspaceIndex, editingWorkspace);

                    view.SetWorkspaces(workspaceManager.RobotWorkspaces, editingWorkspaceIndex);
                    editingWorkspace = null;
                    editingWorkspaceIndex = -1;
                    return;
                }

                string errorMessage = "Рабочая зона не сохранена. Ошибки:";

                foreach (var error in errors)
                {
                    errorMessage += String.Format("\n\n{0} : {1}", (error.Key), error.Value.Message);
                }

                throw new Exception(errorMessage);
            }
            catch(Exception ex)
            {
                messageService.ShowError(ex.Message);

            }
        }

        // Установить режим редактирования рабочей зоны.
        private void View_InvokeSetEditWorkspaceMode(object sender, WorkspaceEventArgs e)
        {
            try
            {
                workspaceManager.SetDefaultWorkspace();

                editingWorkspace = workspaceManager.GetClone(e.Index);

                var editValues = MovableValueType.Zero;

                if (e.Index != 0)
                    editValues |= MovableValueType.Max | MovableValueType.Min;

                editingWorkspaceIndex = e.Index;

                view.SetEditWorkspaceMode(true, editingWorkspace, editValues);
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        //  Изменение ограничений и задание нулевой точки для плеч робота.
        private void View_InvokeWorkspaceValueChange(object sender, EditWorkspaceEventArgs e)
        {
            if (editingWorkspace == null || e.ValueType == MovableValueType.None)
                return;

            editingWorkspace.SetValue(e.LeverType, e.ValueType, movement.GetLeverPosition(e.LeverType));

            view.SetRobotWorkspaceParams(editingWorkspace);
        }

        #endregion

        #region Перемещение плечей робота-манипулятора. Ручное управление. Управление G кодами.  

        private void Movement_OnMovingEnd(object sender, StepLever e)
        {
            view.SetStatusMessage("");
        }

        private void Movement_OnMovingStart(object sender, StepLever e)
        {
            view.SetStatusMessage(e.Lever.ToRuString() + ": перемещение");
        }

        private void Movement_OnZeroPositionChanged(object sender, LeverZeroPositionEventArgs e)
        {
            bool isOnZ = e.LeverType == LeverType.Horizontal ? e.IsOnZeroPosition : movement.IsOnZeroPosition(LeverType.Horizontal);
            bool isOnXY = (e.LeverType == LeverType.Lever1 ? e.IsOnZeroPosition : movement.IsOnZeroPosition(LeverType.Lever1))
                        && (e.LeverType == LeverType.Lever2 ? e.IsOnZeroPosition : movement.IsOnZeroPosition(LeverType.Lever2));

            view.SetZeroPositionState(isOnXY, isOnZ);
        }

        private void Movement_LeverPositionChanged(object sender, LeverPosition e)
        {
            SaveLeverCurrentPosition(e.Lever, e.Position);

            if (view.IsEditWorkspaceMode)
                view.SetCurrentEditWorkspaceModeLeverPosition(e.Lever, e.Position);

            view.SetCurrentPosition(e);
        }

        private void Movement_LocationChanged(bool isRunning, Location location)
        {
            view.SetCurrentLocation(isRunning, location.X, location.Y, location.Z);
        }

        private void View_InvokeStepperAbort(object sender, EventArgs e)
        {
            movement.Abort();
        }

        private void View_InvokeStepperStop(object sender, EventArgs e)
        {
            movement.Stop();
        }

        private void View_RunGCodeInterpreter(object sender, EventArgs e)
        {
            if (view.IsManualControlMode)
                return;

            try
            {
                view.ParserErrors = movement.RunGCode(view.GCodeLines);
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_ManualControlStop(object sender, StepLever stepLever)
        {
            movement.ManualControlStop(stepLever.Lever);
        }

        private void View_ManualControlStart(object sender, StepLever stepLever)
        {
            try
            {
                if (!view.IsManualControlMode)
                    return;

                movement.ManulControlRun(stepLever);
            }
            catch(Exception e)
            {
                messageService.ShowError(e.Message);
            }
        }

        #endregion
    }
}
