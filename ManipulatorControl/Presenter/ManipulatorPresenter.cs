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
using ManipulatorControl.Model;

namespace ManipulatorControl
{
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


        private List<RobotWorkspace> robotWorkspaces;
        private RobotWorkspace activeWorkspace;


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


            this.worker.OnStart += Worker_OnStart;
            this.worker.OnStop += Worker_OnStop;      
            this.worker.OnStop += interpreter.OnStepperStop;

            this.interpreter.OnInterpreterStart += Interpreter_OnInterpreterStart;
            this.interpreter.OnInterpreterStop += Interpreter_OnInterpreterStop;
            this.interpreter.OnInvokeStartStepper += MoveLeverStart;


            this.pins = SettingsReader.GetStepDirPins();
            this.motors = SettingsReader.GetMotors();

            this.levers = GetRobotLever().ToArray();
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
            this.settings.Show();
        }


        // TODO: Загрузка параметров из настроек. Сейчас заглушка.
        private DesignParameters LoadDesignParameters()
        {
            //return JsonConvert.DeserializeObject<DesignParameters>(File.ReadAllText("design.settings"));
             var par = JsonConvert.DeserializeObject<DesignParameters>(File.ReadAllText("design.settings"));
            par.Lever1.Workspace = new LeverWorkspace(520, 500, 540);
            return par;
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
                CoordinateDirections.XPositive | CoordinateDirections.YPositive, CoordinateDirections.XNegative | CoordinateDirections.YNegative);

            yield return new RobotLever(LeverType.Lever2, GetStepper(LeverType.Lever2),
                CoordinateDirections.XPositive | CoordinateDirections.YNegative, CoordinateDirections.XNegative | CoordinateDirections.YPositive);
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

        private void Worker_OnStop(object sender, EventArgs e)
        {
            view.Directions ^= movingLever.ActiveDirection;

            Debug.WriteLine((sender as StepperWorker).StopReason);

            //calculation.SetNewAB(movingLever.Type, movingLever.Stepper.CurrentStepsCount);

          /*  if (nullPos.Position == 50)
                view.Directions = CoordinateDirections.OnZZero;   */

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
                // Хранить нулевое положение (AB).
                /*
                 if (stepsCount == 0)
                     stepsCount = calculation.CalculateStepsToAbValue(type, AB);
                 else
                     stepsCount = stepsCount == -1 ? calculation.CalculateStepsToLeverMax(type) : calculation.CalculateStepsToLeverMin(type);
                 */

                stepLever.StepsCount = stepLever.StepsCount == -1 ? -long.MaxValue : long.MaxValue;
            }

            movingLever = levers.Single(lever => lever.Type == stepLever.Lever);

            worker.Stepper = movingLever.Stepper;
            worker.Stepper.TargetStepsCount = stepLever.StepsCount;

            Debug.WriteLine(worker.Stepper.Direction + " " + worker.Stepper.TargetStepsCount);

            new Task(() => worker.Start()).Start(); 
        }
    }
}
