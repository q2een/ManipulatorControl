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
using ManipulatorControl.BL.Settings;

namespace ManipulatorControl
{
    /// <summary>
    /// Предоставляет класс презентера приложения.
    /// </summary>
    public class ManipulatorPresenter
    {
        private readonly IMessageService messageService;
        private readonly ICurrentPositionLoader currentPositionLoader;
        private readonly IManipulatorControlView view;
        private readonly ISettingsView settings;

        private DesignParameters parameters;
        private LPTPort port = new LPTPort();
        private ScriptBuilder scriptBuilder;

        private readonly LeverMovement leverMovement;
        private readonly RobotMovement movement;
        private readonly WorkspaceManager workspaceManager;

        private List<LeverStepperSettings> leverSteppers = new List<LeverStepperSettings>();
        private readonly LeverStepper[] levers;

        private int editingWorkspaceIndex = -1;
        private RobotWorkspace editingWorkspace;

        private ScriptExecutor scriptExecutor;
        private List<MovementScript> scripts = new List<MovementScript>();

        /// <summary>
        /// Предоставляет класс презентера приложения.
        /// </summary>
        /// <param name="view">Представление приложения</param>
        /// <param name="settingsView">Представление изменения параметров</param>
        /// <param name="currentPositionLoader">Объект класса, описывающего механизм получения и сохранения текущего положения робота</param>
        /// <param name="messageService">Объект класса, описывающего механизм обмены сообщения с пользователем</param>
        public ManipulatorPresenter(IManipulatorControlView view, ISettingsView settingsView, ICurrentPositionLoader currentPositionLoader, IMessageService messageService)
        {
            this.view = view;
            this.currentPositionLoader = currentPositionLoader;
            this.settings = settingsView;
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
            this.view.InvokeRemoveZeroPosition += View_InvokeRemoveZeroPosition;
            this.view.InvokeSaveWorkspaceValues += View_InvokeSaveWorkspaceValues;
            this.view.InvokeCloseEditWorkspaceMode += View_InvokeCloseEditWorkspaceMode;
            this.view.InvokeRemoveWorkspace += View_InvokeRemoveWorkspace;
            this.view.InvokeAddWorkspace += View_InvokeAddWorkspace;
            this.view.InvokeRenameWorkspace += View_InvokeRenameWorkspace;

            this.view.InvokeCreateScript += View_InvokeCreateScript;
            this.view.InvokeSaveScript += View_InvokeSaveScript;
            this.view.InvokeCancelCreatingScript += View_InvokeCancelCreatingScript;

            this.view.InvokeRemoveScript += View_InvokeRemoveScript;
            this.view.InvokeScriptRename += View_InvokeScriptRename;


            this.view.InvokeRunScript += View_InvokeRunScript;
            this.view.InvokeRunScriptReverse += View_InvokeRunScriptReverse;
            this.view.InvokeSetCurrentAsStart += View_InvokeSetCurrentAsStart;
            this.view.InvokeSetCurrentAsEnd += View_InvokeSetCurrentAsEnd;
            this.view.InvokeMoveToStartScript += View_InvokeMoveToStartScript;
            this.view.InvokeMoveToEndScript += View_InvokeMoveToEndScript;

            this.view.InvokeScriptBackTo += View_InvokeScriptBackTo;


            LoadApplicationSettings();
            this.levers = GetRobotLever().ToArray();

            leverMovement = new LeverMovement(port, levers);

            movement = new RobotMovement(new Calculation(parameters), leverMovement);
            workspaceManager = new WorkspaceManager(parameters, LoadWorkspaces(), Properties.Settings.Default.ActiveWorkspaceIndex);
            scriptExecutor = new ScriptExecutor(movement);
            
            workspaceManager.OnActiveWorkspaceChanged += WorkspaceManager_OnActiveWorkspaceChanged;
            workspaceManager.ActiveWorkspace = workspaceManager.ActiveWorkspace;

            movement.LocationChanged += Movement_LocationChanged;
            movement.LeverPositionChanged += Movement_LeverPositionChanged;
            movement.OnZeroPositionChanged += Movement_OnZeroPositionChanged;
            movement.OnMovingStart += Movement_OnMovingStart;
            movement.OnMovingEnd += Movement_OnMovingEnd;

            scriptExecutor.StepPassed += ScriptExecutor_StepPassed;
            scriptExecutor.OnExecutingStart += ScriptExecutor_OnExecutingStart;
            scriptExecutor.OnExecutingEnd += ScriptExecutor_OnExecutingEnd;

            Movement_LocationChanged(false, movement.Calculation.GetCurrentLocation());

            view.SetWorkspaces(workspaceManager.RobotWorkspaces, workspaceManager.ActiveWorkspaceIndex);

            SetCurrentPositionOnView();

            //StringBuilder sb = new StringBuilder();



            //for (int i = 320; i <= 1100; i++)
            //{
            //    for (int j = 320; j < 1026; j++)
            //    {
            //        double x = 0, y = 0;

            //        movement.Calculation.GetXYByABValues(i, j, out x, out y);

            //        sb.AppendLine(x + " | " + y);
            //    }
            //}

            //File.WriteAllText("3.txt", sb.ToString());
    
        }

        private void SetCurrentPositionOnView()
        {
            view.SetCurrentPosition(new LeverPosition(LeverType.Horizontal, movement.GetLeverPosition(LeverType.Horizontal)));
            view.SetCurrentPosition(new LeverPosition(LeverType.Lever1, movement.GetLeverPosition(LeverType.Lever1)));
            view.SetCurrentPosition(new LeverPosition(LeverType.Lever2, movement.GetLeverPosition(LeverType.Lever2)));
        }

        #region Загрузка параметров, значений.

        private void LoadApplicationSettings()
        {
            if (this.parameters == null)
                throw new NullReferenceException();

            this.settings.StepDirNames = Load<List<StepDirName>>(Properties.Resources.StepDirNamesSettingsFileName);

            var savedScripts = Load<List<MovementScript>>(Properties.Resources.ScriptsSettingsFileName);
            scripts = savedScripts == null ? new List<MovementScript>() : savedScripts;

            view.SetScriptsList(scripts);
        }

        private DesignParameters LoadDesignParameters()
        {
            var parameters = Load<DesignParameters>(Properties.Resources.DesignSettingsFileName);

            WorkspaceManager.RemoveWorkspacesFromDesignParameters(parameters);
            SetSavedCurrentPositionToDesignParameters(parameters);

            return parameters;
        }

        #region Обращение к параметрам приложения.

        private void SaveActiveRobotWorkspace(RobotWorkspace workspace)
        {
            Properties.Settings.Default.ActiveWorkspaceIndex = workspaceManager.ActiveWorkspaceIndex;
            Properties.Settings.Default.Save();
        }

        private void SetSavedCurrentPositionToDesignParameters(DesignParameters parameters)
        {
            parameters.HorizontalLever.AB = currentPositionLoader.GetCurrentPosition(LeverType.Horizontal);
            parameters.Lever1.AB = currentPositionLoader.GetCurrentPosition(LeverType.Lever1);
            parameters.Lever2.AB = currentPositionLoader.GetCurrentPosition(LeverType.Lever2);
        }

        private void GetSavedCurrentPositionFromDesignParameters(DesignParameters parameters)
        {
            currentPositionLoader.SaveCurrentPosition(LeverType.Horizontal, parameters.HorizontalLever.AB);
            currentPositionLoader.SaveCurrentPosition(LeverType.Lever1, parameters.Lever1.AB);
            currentPositionLoader.SaveCurrentPosition(LeverType.Lever2, parameters.Lever2.AB);
        }

        #endregion

        private void UpdateDesignParameters(DesignParameters designParameters)
        {

            var settings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            File.WriteAllText("design.settings", JsonConvert.SerializeObject(designParameters, settings));

            if (parameters == designParameters)
                return;

            parameters.HorizontalLever = designParameters.HorizontalLever;
            parameters.L1 = designParameters.L1;
            parameters.L2 = designParameters.L2;
            parameters.Lc = designParameters.Lc;
            parameters.Lever1 = designParameters.Lever1;
            parameters.Lever2 = designParameters.Lever2;

            GetSavedCurrentPositionFromDesignParameters(designParameters);

            workspaceManager.DesignParametersWorkspace = workspaceManager.RobotWorkspaces.First();
            view.SetWorkspaces(workspaceManager.RobotWorkspaces, workspaceManager.ActiveWorkspace != null ? workspaceManager.RobotWorkspaces.IndexOf(workspaceManager.ActiveWorkspace) : 0);
            SetCurrentPositionOnView();

            view.SetZeroPositionState(movement.IsOnZeroPosition(LeverType.Horizontal), movement.IsOnZeroPosition(LeverType.Lever1) && movement.IsOnZeroPosition(LeverType.Lever2));

            Movement_LocationChanged(false, movement.Calculation.GetCurrentLocation());
        }

        private T Load<T>(string path, params JsonConverter[] converters)
        {
            try
            {
                return JSONSettingsSaver.Load<T>(path, converters);
            }
            catch(Exception ex)
            {
                messageService.ShowError(ex.Message);
            }

            return default(T);
        }

        private void Save<T>(string path, T obj, params JsonConverter[] converters)
        {
            try
            {
                obj.SaveAsJSONFile(path, converters);
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }
        
        private List<RobotWorkspace> LoadWorkspaces()
        {
            var workspaces = Load<List<RobotWorkspace>>(Properties.Resources.WorkspacesSettingsFileName, new WorkspaceConverter());

            return workspaces ?? new List<RobotWorkspace>();
        }
        
        private void SaveLeverSteppers()
        {
            try
            {
                settings.LeverSteppers.SaveAsJSONFile(Properties.Resources.LeverSteppersSettingsFileName);

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

        private IEnumerable<LeverStepper> GetRobotLever()
        {
            leverSteppers = Load<List<LeverStepperSettings>>(Properties.Resources.LeverSteppersSettingsFileName);
            this.settings.LeverSteppers = leverSteppers;

            foreach (var stepper in leverSteppers)
            {
                stepper.Stepper.Port = port;
                stepper.Stepper.Pins = this.settings.StepDirNames.Single(s => s.Type == stepper.PinType).StepDir;
            }

            yield return new LeverStepper(LeverType.Horizontal, leverSteppers.Single(lever => lever.LeverType == LeverType.Horizontal).Stepper);

            yield return new LeverStepper(LeverType.Lever1, leverSteppers.Single(lever => lever.LeverType == LeverType.Lever1).Stepper);

            yield return new LeverStepper(LeverType.Lever2, leverSteppers.Single(lever => lever.LeverType == LeverType.Lever2).Stepper);    
        }

        #endregion

        private void Settings_SaveSettings(object sender, EventArgs e)
        {
            try
            {
                UpdateDesignParameters(this.settings.DesignParameters);

                settings.StepDirNames.SaveAsJSONFile(Properties.Resources.StepDirNamesSettingsFileName);
                SaveLeverSteppers();

                this.settings.Close();
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
            workspaceManager.RobotWorkspaces.Skip(1).SaveAsJSONFile(Properties.Resources.WorkspacesSettingsFileName, new WorkspaceConverter());
            scripts.SaveAsJSONFile(Properties.Resources.ScriptsSettingsFileName);

            movement.Stop();
        }

        #region Создание и выполнение сценариев.

        private void ScriptExecutor_OnExecutingEnd(object sender, EventArgs e)
        {
            view.SetScriptExecuting(false, null);
            view.SetScriptQueue(scriptExecutor.MovementScript.MovementPath, scriptExecutor.MovementScript.MovementPath.Count - 1, false);

            if (scriptExecutor.Exception == null)
                messageService.ShowMessage("Сценарий «" + scriptExecutor.MovementScript.Name + "» успешно выполнен.");
            else
                messageService.ShowError("Сценарий «" + scriptExecutor.MovementScript.Name + "»  не выполнен. Ошибка:\n" + scriptExecutor.Exception.Message);
        }

        private void ScriptExecutor_OnExecutingStart(object sender, EventArgs e)
        {
            view.SetScriptExecuting(true, (sender as ScriptExecutor).MovementScript);
        }

        private void ScriptExecutor_StepPassed(object sender, LeverScriptPosition e)
        {
            var path = new List<LeverScriptPosition>(scriptExecutor.MovementScript.MovementPath);
            var index = path.IndexOf(e) + 1;
            view.SetScriptQueue(path, index > path.Count - 1 ? index - 1 : index, true);
        }

        private void View_InvokeScriptRename(object sender, WorkspaceEventArgs e)
        {
            if (scriptExecutor.IsExecuting)
                return;

            try
            {
                scripts[e.Index].Name = e.Name;
                view.SetScriptsList(scripts);
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_InvokeRemoveScript(object sender, MovementScript e)
        {
            if (scriptExecutor.IsExecuting)
                return;

            try
            {
                if (messageService.ShowExclamation("Вы действительно хотите удалить сценарий «" + e.Name + "»") == UserResponse.OK)
                {
                    scripts.Remove(e);
                    view.SetScriptsList(scripts);
                }
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_InvokeCancelCreatingScript(object sender, EventArgs e)
        {
            try
            {
                if (messageService.ShowExclamation("Вы действительно хотите отменить создание сценария ?") == UserResponse.OK)
                {
                    scriptBuilder.Cancel();

                    scriptBuilder.OnPathChanged -= ScriptBuilder_OnPathChanged;
                    scriptBuilder.OnNewStartPoint -= ScriptBuilder_OnNewStartPoint;
                    scriptBuilder.OnNewEndPoint -= ScriptBuilder_OnNewEndPoint;

                    view.SetScriptCreatingMode(false);
                }
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_InvokeMoveToEndScript(object sender, MovementScript e)
        {
            try
            {
                if (e == null)
                    return;

                if (messageService.ShowExclamation("Переместить манипулятор в конечную точку сценария  «" + e.Name + "»") == UserResponse.OK)
                {
                    var action = new Action(() => messageService.ShowMessage("Робот перемещен в конечную точку сценария «" + e.Name + "»"));

                    movement.MoveRobotByPath(e.End, action);
                }
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_InvokeMoveToStartScript(object sender, MovementScript e)
        {
            try
            {
                if (e == null)
                    return;

                if (messageService.ShowExclamation("Переместить манипулятор в начальную точку сценария  «" + e.Name + "»") == UserResponse.OK)
                {
                    var action = new Action(() => messageService.ShowMessage("Робот перемещен в начальную точку сценария «" + e.Name + "»"));

                    movement.MoveRobotByPath(e.Start, action);
                }
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_InvokeSetCurrentAsEnd(object sender, EventArgs e)
        {
            try
            {
                if (scriptBuilder == null)
                    throw new Exception("Невозможно установить конечное значение, так как сценарий еще не создан или не редактируется");

                scriptBuilder.SetCurrentPositionAsEnd();

            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_InvokeSetCurrentAsStart(object sender, EventArgs e)
        {
            try
            {
                if (scriptBuilder == null)
                    throw new Exception("Невозможно установить начальное значение, так как сценарий еще не создан или не редактируется");

                scriptBuilder.SetCurrentPositionAsStart();

            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_InvokeRunScriptReverse(object sender, MovementScript e)
        {
            try
            {
                var isAtPosition = movement.IsNowAtPosition(e.End);

                if (!isAtPosition && messageService.ShowExclamation("Перед началом выполнения сценария робот будет перемещен в начальное положение") != UserResponse.OK)
                    return;

                scriptExecutor.Execute(e, true);
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_InvokeRunScript(object sender, MovementScript e)
        {
            try
            {
                var isAtPosition = movement.IsNowAtPosition(e.Start);

                if (!isAtPosition && messageService.ShowExclamation("Перед началом выполнения сценария робот будет перемещен в начальное положение") != UserResponse.OK)
                    return;

                scriptExecutor.Execute(e, false);
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_InvokeSaveScript(object sender, EventArgs e)
        {
            try
            {
                if (scriptBuilder == null)
                    throw new Exception("Невозможно сохранить сценарий, так как он еще не создан или не редактируется");

                scripts.Add(scriptBuilder.GetScript());
                view.SetScriptsList(scripts);

                scriptBuilder.OnPathChanged -= ScriptBuilder_OnPathChanged;
                scriptBuilder.OnNewStartPoint -= ScriptBuilder_OnNewStartPoint;
                scriptBuilder.OnNewEndPoint -= ScriptBuilder_OnNewEndPoint;

                view.SetScriptCreatingMode(false);

                messageService.ShowMessage("Сценарий сохранен");
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }

        }

        private void View_InvokeScriptBackTo(object sender, LeverScriptPosition e)
        {
            try
            {
                scriptBuilder.BackTo(e);
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        private void View_InvokeCreateScript(object sender, WorkspaceEventArgs e)
        {
            view.SetScriptCreatingMode(true);
            scriptBuilder = new ScriptBuilder(movement, e.Name);

            scriptBuilder.OnPathChanged += ScriptBuilder_OnPathChanged;
            scriptBuilder.OnNewStartPoint += ScriptBuilder_OnNewStartPoint;
            scriptBuilder.OnNewEndPoint += ScriptBuilder_OnNewEndPoint;

            scriptBuilder.SetCurrentPositionAsStart();
        }

        private void ScriptBuilder_OnNewEndPoint(object sender, EventArgs e)
        {
            view.SetScriptCreatingPoint((sender as ScriptBuilder).EndPoint, false);
        }

        private void ScriptBuilder_OnNewStartPoint(object sender, EventArgs e)
        {
            view.SetScriptCreatingPoint((sender as ScriptBuilder).StartPoint, true);
        }

        private void ScriptBuilder_OnPathChanged(object sender, EventArgs e)
        {
            view.SetScriptQueue(scriptBuilder.Path, scriptBuilder.Path.Count - 1, false);
        }


        #endregion

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
            workspaceManager.SetActiveWorkspace(0);
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

                if(messageService.ShowExclamation("Робот находится вне выбранной рабочей зоны. Переместить плечи робота в рабочую зону ?") == UserResponse.OK)
                {
                    movement.MoveRobotByPath(workspaceManager.GetLeversPositionToWorkspaceRange(workspace), action);
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
            view.SetEditWorkspaceMode(false, null, MovableValueTypes.None);
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

                if(editingWorkspaceIndex == 0)
                {
                    this.movement.DesignParameters.Lever1.ABzero = editingWorkspace.Lever1.ABzero;
                    this.movement.DesignParameters.Lever2.ABzero = editingWorkspace.Lever2.ABzero;
                    this.movement.DesignParameters.HorizontalLever.ABzero = editingWorkspace.HorizontalLever.ABzero;

                    UpdateDesignParameters(this.movement.DesignParameters);
                }

                if (errors.Count() == 0)
                {
                    view.SetEditWorkspaceMode(false, null, MovableValueTypes.None);

                    workspaceManager.SetWorkspace(editingWorkspaceIndex, editingWorkspace);

                    view.SetWorkspaces(workspaceManager.RobotWorkspaces, editingWorkspaceIndex);
                    editingWorkspace = null;
                    editingWorkspaceIndex = -1;
                    return;
                }

                string errorMessage = "Рабочая зона не сохранена. Ошибки:";

                foreach (var error in errors)
                {
                    errorMessage += string.Format("\n\n{0} : {1}", (error.Key), error.Value.Message);
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

                var editValues = MovableValueTypes.Zero;

                if (e.Index != 0)
                    editValues |= MovableValueTypes.Max | MovableValueTypes.Min;

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
            if (editingWorkspace == null || e.ValueType == MovableValueTypes.None)
                return;

            editingWorkspace.SetValue(e.LeverType, e.ValueType, movement.GetLeverPosition(e.LeverType));

            if(editingWorkspaceIndex == 0)
            {
                movement.Calculation.GetRobotLeverByType(e.LeverType).ABzero = null;
            }

            view.SetRobotWorkspaceParams(editingWorkspace);
        }

        private void View_InvokeRemoveZeroPosition(object sender, EditWorkspaceEventArgs e)
        {
            if (editingWorkspace == null)
                return;

            editingWorkspace.RemoveZero(e.LeverType);

            view.SetRobotWorkspaceParams(editingWorkspace);
        }

        #endregion

        #region Перемещение плеч робота-манипулятора. Ручное управление. Управление G кодами.  

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
            currentPositionLoader.SaveCurrentPosition(e.LeverType, e.Position);

            if (view.IsEditWorkspaceMode)
                view.SetCurrentEditWorkspaceModeLeverPosition(e.LeverType, e.Position);

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
