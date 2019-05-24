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

namespace ManipulatorControl
{
    // TODO: 
    // * рабочие зоны робота: проверка текущего положения при задании новой рабочей зоны, переезд к нулевому значению или к ближайшему в границах.
    // * изменить класс для ограничения рабочей области. (AB обновляется неправильно). Оставить AB только в параметрах робота. Ограничения рабочей области вынести в IWorkspace.
    // * Cохранение текущего положения робота.
    public class ManipulatorPresenter
    {
        private readonly IMessageService messageService;
        private readonly IManipulatorControlView view;
        private readonly ISettingsView settings;

        private DesignParameters parameters;
        private readonly Calculation calculation;

        private readonly StepperWorker worker = new StepperWorker();
        private LPTPort port = new LPTPort();

        private readonly GCodeInterpreter interpreter;
        private readonly Parser parser;

        private readonly RobotLever[] levers;
        private RobotLever movingLever;

        //  private LeverPosition nullPos = new LeverPosition() { Lever = LeverType.Horizontal, Position = 50 };

        private Dictionary<string, StepDirPin> pins;

        private int editingWorkspaceIndex = -1;
        private List<RobotWorkspace> robotWorkspaces;
        private RobotWorkspace activeWorkspace, editingWorkspace;


        public ManipulatorPresenter(IManipulatorControlView view, IMessageService messageService)
        {
            this.view = view;
            this.settings = new SettingsForm();
            this.messageService = messageService;

            this.parameters = LoadDesignParameters();
            this.calculation = new Calculation(parameters);
            this.interpreter = new GCodeInterpreter(this.calculation);
            this.parser = new Parser(interpreter);

            this.settings.StepDirNames = SettingsReader.GetStepDirNames();
            this.settings.SaveSettings += Settings_SaveSettings;

            this.view.ManualControlStart += MoveLeverStart;
            this.view.ManualControlStop += View_ManualControlStop;
            this.view.InvokeStepperAbort += View_InvokeStepperAbort;
            this.view.InvokeStepperStop += View_InvokeStepperStop;
            this.view.RunGCodeInterpreter += View_RunGCodeInterpreter;
            this.view.OpenSettings += View_OpenSettings;

            this.view.InvokeSetActiveWorkspace += View_InvokeSetActiveWorkspace;

            this.view.InvokeSetEditWorkspaceMode += View_InvokeSetEditWorkspaceMode;
            this.view.InvokeWorkspaceValueChange += View_InvokeWorkspaceValueChange;

            this.view.InvokeSaveWorkspaceValues += View_InvokeSaveWorkspaceValues;
            this.view.InvokeCloseEditWorkspaceMode += View_InvokeCloseEditWorkspaceMode;

            this.view.InvokeRemoveWorkspace += View_InvokeRemoveWorkspace;
            this.view.InvokeAddWorkspace += View_InvokeAddWorkspace;
            this.view.InvokeRenameWorkspace += View_InvokeRenameWorkspace;

            this.worker.OnStart += Worker_OnStart;
            this.worker.OnStop += Worker_OnStop;
            this.worker.OnStop += interpreter.OnStepperStop;

            this.interpreter.OnInterpreterStart += Interpreter_OnInterpreterStart;
            this.interpreter.OnInterpreterStop += Interpreter_OnInterpreterStop;
            this.interpreter.OnInvokeStartStepper += MoveLeverStart;


            this.pins = SettingsReader.GetStepDirPins();
            this.motors = SettingsReader.GetMotors();

            this.levers = GetRobotLever().ToArray();


            //!!!
            activeWorkspace = new RobotWorkspace("Детали для станка");
            activeWorkspace.HorizontalLeverWorkspace = parameters.HorizontalLever.Clone() as IPartMovable; 
            activeWorkspace.Lever1Workspace = parameters.Lever1.Clone() as IPartMovable;
            activeWorkspace.Lever2Workspace = parameters.Lever2.Clone() as IPartMovable; 

            var he = new RobotWorkspace("Конструктивные параметры");
            he.HorizontalLeverWorkspace = parameters.HorizontalLever.Clone() as IPartMovable; 
            he.Lever1Workspace = parameters.Lever1.Clone() as IPartMovable; 
            he.Lever2Workspace = parameters.Lever2.Clone() as IPartMovable;

            robotWorkspaces = new List<RobotWorkspace>{ he, activeWorkspace };

            view.SetWorkspaces(robotWorkspaces);
        }

        #region Загрузка параметров, значений.

        // TODO: Загрузка параметров из настроек. Сейчас заглушка.
        private DesignParameters LoadDesignParameters()
        {
            //return JsonConvert.DeserializeObject<DesignParameters>(File.ReadAllText("design.settings"));
            var par = JsonConvert.DeserializeObject<DesignParameters>(File.ReadAllText("design.settings"));
            //par.Lever1.Workspace = new LeverWorkspace(520, 500, 540,500);
            return par;
        }

        private List<RobotWorkspace> LoadWorkspaces()
        {
            return new List<RobotWorkspace>();
        }

        private IEnumerable<RobotLever> GetRobotLever()
        {
            yield return new RobotLever(LeverType.Horizontal, GetStepper(LeverType.Horizontal), CoordinateDirections.ZPositive, CoordinateDirections.ZNegative);

            yield return new RobotLever(LeverType.Lever1, GetStepper(LeverType.Lever1),
                 CoordinateDirections.XNegative | CoordinateDirections.YNegative, CoordinateDirections.XPositive | CoordinateDirections.YPositive);

            yield return new RobotLever(LeverType.Lever2, GetStepper(LeverType.Lever2),
                CoordinateDirections.XNegative | CoordinateDirections.YPositive, CoordinateDirections.XPositive | CoordinateDirections.YNegative);
        }

        Dictionary<LeverType, StepperMotor> motors;
        private StepperMotor GetStepper(LeverType type)
        {
            var motor = motors[type];
            motor.Port = port;
            var driverMotorName = type == LeverType.Horizontal ? "Z" : (type == LeverType.Lever1 ? "Y" : "X");
            motor.Pins = pins[driverMotorName];

            return motor;
        }

        #endregion

        #region Рабочие зоны манипулятора.
       
        // Устанавливает в качестве рабочей зоны конструктивные параметры робота.
        private void SetDefaultWorkspace()
        {
            parameters.Lever1.Workspace = null;
            parameters.Lever2.Workspace = null;
            parameters.HorizontalLever.Workspace = null;

            activeWorkspace = null;
        }

        // Возвращает копию рабочей зоны соответствующую конструктивным параметрам робота.
        private RobotWorkspace GetDesignParametersWorkspace(string name)
        {
            if (parameters == null)
                return null;

            var workspace = new RobotWorkspace(name);
            workspace.HorizontalLeverWorkspace = parameters.HorizontalLever.Clone() as IPartMovable;
            workspace.Lever1Workspace = parameters.Lever1.Clone() as IPartMovable;
            workspace.Lever2Workspace = parameters.Lever2.Clone() as IPartMovable;

            return workspace;
        } 

        // Устанавливает заданную рабочую зону в качестве активной рабочей зоны.
        private void SetActiveWorkspace(RobotWorkspace workspace)
        {
            parameters.Lever1.Workspace = workspace.Lever1Workspace;
            parameters.Lever2.Workspace = workspace.Lever2Workspace;
            parameters.HorizontalLever.Workspace = workspace.HorizontalLeverWorkspace;

            activeWorkspace = workspace;
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

			var workspace = GetDesignParametersWorkspace(e.Name);
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
				throw new Exception("Нельзя удалить данную рабочу область");

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

			var errors = editingWorkspace.GetDesignParametersExceptions();

			if(errors.Count() == 0)
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
                errorMessage += String.Format("\n{0} : {1}", error.Key, error.Value);
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

            editingWorkspace.GetLeverByType(LeverType.Horizontal).AB = parameters.HorizontalLever.AB;
            editingWorkspace.GetLeverByType(LeverType.Lever1).AB = parameters.Lever1.AB;
            editingWorkspace.GetLeverByType(LeverType.Lever2).AB = parameters.Lever2.AB;

            view.SetEditWorkspaceMode(true, editingWorkspace, editValues);
		}

        //  Изменение ограничений и задание нулевой точки для плеч робота.
        private void View_InvokeWorkspaceValueChange(object sender, EditWorkspaceEventArgs e)
		{
			if (editingWorkspace == null || e.ValueType == MovableValueType.None)
				return;

			editingWorkspace.SetValue(e.LeverType, e.ValueType);

			view.SetRobotWorkspaceParams(editingWorkspace);
		}

        #endregion

        private void Settings_SaveSettings(object sender, EventArgs e)
        {
            var settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            File.WriteAllText("design.settings", JsonConvert.SerializeObject(this.settings.DesignParameters, settings));

            parameters = this.settings.DesignParameters;
        }

        private void View_OpenSettings(object sender, EventArgs e)
        {
            if (movingLever != null)
                return;

            parameters.Lever1.IsABIncreasesOnStepperCW = false;
            parameters.Lever2.IsABIncreasesOnStepperCW = true;

            parameters.Lever1.Workspace = parameters.Lever1;

            var a = calculation.CalculateStepsToAbValue(LeverType.Lever2, 540);
            var b = calculation.CalculateStepsToAbValue(LeverType.Lever1, 540);
            this.settings.DesignParameters = parameters;
            this.settings.Show();
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

            var result = parser.Parse(view.GCodeLines);
            view.ParserErrors = parser.Errors;

            if (result)
                interpreter.StartInterprete(parser.CommandQueue);
        }

        private void SetNewABValue(LeverType type, long stepsCount)
        {
            if (view.IsEditWorkspaceMode)
            {
                var ab = calculation.GetNewAB(type, stepsCount); 
                editingWorkspace.GetLeverByType(type).AB = ab;
                view.SetRobotWorkspaceParams(editingWorkspace);
            }

            calculation.SetNewAB(type, stepsCount);
        }

        private void Worker_OnStop(object sender, EventArgs e)
        {
            view.Directions ^= movingLever.ActiveDirection;

            SetNewABValue(movingLever.Type, movingLever.Stepper.CurrentStepsCount);
           
            var leverDesignParams = calculation.GetPartMovableByLeverType(movingLever.Type);

            //if (leverDesignParams.AB == leverDesignParams.ABzero)
                //view.Directions = CoordinateDirections.OnZZero;   

            movingLever = null;
        }

        private void Worker_OnStart(object sender, EventArgs e)
        {  
            view.Directions = movingLever.ActiveDirection;
        }

        private void View_InvokeStepperStop(object sender, EventArgs e)
        {
            worker.Stop();
        }

        private void View_InvokeStepperAbort(object sender, EventArgs e)
        {
            worker.Abort();
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
    }
}
