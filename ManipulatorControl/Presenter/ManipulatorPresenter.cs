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

namespace ManipulatorControl
{

    // TODO: рабочие зоны робота, установка значений, изменение значений, установка нулевого значения.
    // Обновление текущего положения робота и корректное его сохранение.
    public class ManipulatorPresenter
    {
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


        public ManipulatorPresenter(IManipulatorControlView view)
        {
            this.view = view;
            this.settings = new SettingsForm();

            this.parameters = LoadDesignParameters();
            this.calculation = new Calculation(parameters);
            this.interpreter = new GCodeInterpreter(this.calculation);
            this.parser = new Parser(interpreter);

            this.settings.StepDirNames = SettingsReader.GetStepDirNames();
            this.settings.DesignParameters = parameters;
            this.settings.SaveSettings += Settings_SaveSettings;

            this.view.ManualControlStart += MoveLeverStart;
            this.view.ManualControlStop += View_ManualControlStop;
            this.view.InvokeStepperAbort += View_InvokeStepperAbort;
            this.view.InvokeStepperStop += View_InvokeStepperStop;
            this.view.RunGCodeInterpreter += View_RunGCodeInterpreter;
            this.view.OpenSettings += View_OpenSettings;
            this.view.SetWorkspaceModeChanged += View_SetWorkspaceModeChanged;
            this.view.InvokeWorkspaceValueChange += View_InvokeWorkspaceValueChange;
            this.view.InvokeSetEditWorkspaceMode += View_InvokeSetEditWorkspaceMode;
            this.view.InvokeSaveWorkspaceValues += View_InvokeSaveWorkspaceValues;


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
            activeWorkspace.HorizontalLeverWorkspace = parameters.HorizontalLever.Clone() as IPartMovable; ;
            activeWorkspace.Lever1Workspace = parameters.Lever1.Clone() as IPartMovable; ;
            activeWorkspace.Lever2Workspace = parameters.Lever2.Clone() as IPartMovable; ;

            var he = new RobotWorkspace("Конструктивные параметры");
            he.HorizontalLeverWorkspace = parameters.HorizontalLever.Clone() as IPartMovable; ;
            he.Lever1Workspace = parameters.Lever1.Clone() as IPartMovable; ;
            he.Lever2Workspace = parameters.Lever2.Clone() as IPartMovable; ;

            robotWorkspaces = new List<RobotWorkspace> { he, activeWorkspace };

            view.SetWorkspaces(robotWorkspaces.ToArray());
        }

        private void View_InvokeSaveWorkspaceValues(object sender, WorkspaceEventArgs e)
        {
            if (!view.IsEditWorkspaceMode || editingWorkspace == null)
                return;

            var errors = editingWorkspace.GetDesignParametersExceptions();

            if(errors.Count() == 0)
            {
                view.SetEditWorkspaceMode(false, null, MovableValueType.None);
                this.robotWorkspaces[editingWorkspaceIndex] = editingWorkspace;
                editingWorkspace = null;
                editingWorkspaceIndex = -1;
                view.SetWorkspaces(robotWorkspaces.ToArray());
                return;
            }

            throw errors.First().Value;
        }

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

        private void View_SetWorkspaceModeChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_InvokeWorkspaceValueChange(object sender, EditWorkspaceEventArgs e)
        {
            if (editingWorkspace == null || e.ValueType == MovableValueType.None)
                return;

            editingWorkspace.SetValue(e.LeverType, e.ValueType);

            view.SetRobotWorkspaceParams(editingWorkspace);
        }

        private void Settings_SaveSettings(object sender, EventArgs e)
        {
            var settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            File.WriteAllText("design.settings", JsonConvert.SerializeObject(this.settings.DesignParameters, settings));

            parameters = this.settings.DesignParameters;
        }

        private void View_OpenSettings(object sender, EventArgs e)
        {
            parameters.Lever1.IsABIncreasesOnStepperCW = false;
            parameters.Lever2.IsABIncreasesOnStepperCW = true;

            parameters.Lever1.Workspace = parameters.Lever1;

            var a = calculation.CalculateStepsToAbValue(LeverType.Lever2, 540);
            var b = calculation.CalculateStepsToAbValue(LeverType.Lever1, 540);
            this.settings.Show();
        }


        // TODO: Загрузка параметров из настроек. Сейчас заглушка.
        private DesignParameters LoadDesignParameters()
        {
            //return JsonConvert.DeserializeObject<DesignParameters>(File.ReadAllText("design.settings"));
            var par = JsonConvert.DeserializeObject<DesignParameters>(File.ReadAllText("design.settings"));
            //par.Lever1.Workspace = new LeverWorkspace(520, 500, 540,500);
            return par;
        }

        private void SetDefaultWorkspace()
        {
            parameters.Lever1.Workspace = null;
            parameters.Lever2.Workspace = null;
            parameters.HorizontalLever.Workspace = null;

            activeWorkspace = null;    
        }
        
        private List<RobotWorkspace> LoadWorkspaces()
        {
            return new List<RobotWorkspace>();
        }

        private void SetActiveWorksace(RobotWorkspace workspace)
        {
            parameters.Lever1.Workspace = workspace.Lever1Workspace;
            parameters.Lever2.Workspace = workspace.Lever2Workspace;
            parameters.HorizontalLever.Workspace = workspace.HorizontalLeverWorkspace;

            activeWorkspace = workspace;
        }

        private IEnumerable<RobotLever> GetRobotLever()
        {
            yield return new RobotLever(LeverType.Horizontal, GetStepper(LeverType.Horizontal), CoordinateDirections.ZPositive, CoordinateDirections.ZNegative);

            yield return new RobotLever(LeverType.Lever1, GetStepper(LeverType.Lever1),
                 CoordinateDirections.XNegative | CoordinateDirections.YNegative, CoordinateDirections.XPositive | CoordinateDirections.YPositive);

            yield return new RobotLever(LeverType.Lever2, GetStepper(LeverType.Lever2),
                CoordinateDirections.XNegative | CoordinateDirections.YPositive, CoordinateDirections.XPositive | CoordinateDirections.YNegative);
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

        Dictionary<LeverType, StepperMotor> motors;
        private StepperMotor GetStepper(LeverType type)
        {
            var motor = motors[type];
            motor.Port = port;
            var driverMotorName = type == LeverType.Horizontal ? "Z" : (type == LeverType.Lever1 ? "Y" : "X");
            motor.Pins = pins[driverMotorName];

            return motor;
        }

        private void SetNewABValue(LeverType type, long stepsCount)
        {
            var ab = calculation.GetNewAB(type, stepsCount);

            if (view.IsEditWorkspaceMode)
            {
                editingWorkspace.GetLeverByType(type).AB = ab;
                view.SetRobotWorkspaceParams(editingWorkspace);
            }

            calculation.SetNewAB(type, stepsCount);

            Debug.WriteLine(ab + " " + stepsCount + " | " + calculation.GetPartMovableByLeverType(type).AB + " " + stepsCount);
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

                //stepLever.StepsCount = stepLever.StepsCount == -1 ? -long.MaxValue : long.MaxValue;
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
