using GCodeParser;
using ManipulatorControl.BL.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM160CalculationLib;

namespace ManipulatorControl.BL
{
    public class RobotMovement
    {
        private readonly LeverMovement leverMovement;

        private Location location;

        public Location Location
        {
            get
            {
                return location;
            }
            private set
            {
                location = value;
                LocationChanged(leverMovement.IsRunning, value);
            }
        }

        public Calculation Calculation { get; set; }

        public DesignParameters DesignParameters
        {
            get
            {
                return Calculation != null ? Calculation.DesignParameters : null;
            }
        }

        public bool IsRunning
        {
            get
            {
                return leverMovement.IsRunning;
            }
        }


        public event LocationEventHandler LocationChanged = delegate { };
        public event EventHandler<LeverPosition> LeverPositionChanged = delegate { };

        public event EventHandler<StepLever> OnMovingStart = delegate { };
        public event EventHandler<LeverMovingEndEventArgs> OnMovingEnd = delegate { };


        public event EventHandler<LeverZeroPositionEventArgs> OnZeroPositionChanged = delegate { };


        public RobotMovement(Calculation сalculation, LeverMovement leverMovement)
        {
            Calculation = сalculation;
;

            this.leverMovement = leverMovement;

            Location = Calculation.GetCurrentLocation();

            this.leverMovement.OnMovingEnd += LeverMovement_OnMovingEnd;
            this.leverMovement.OnMovingStart += LeverMovement_OnMovingStart;
            this.leverMovement.OnStepsIntervalElapsed += LeverMovement_OnStepsIntervalElapsed;

        }

        public List<GCodeException> RunGCode(string[] lines)
        {
            var interpreter = new GCodeInterpreter(Calculation);
            var parser = new Parser(interpreter);

            var result = parser.Parse(lines);

            if (!result)
                return parser.Errors;

            var queue = interpreter.Interprete(parser.CommandQueue);

            leverMovement.Move(queue);

            return new List<GCodeException>();
        }

        public void MoveLever(LeverPosition leverPosition)
        {
            leverMovement.Move(Calculation.GetStepLeverToPosition(leverPosition));
        }

        public void MoveRobotByPath(IEnumerable<LeverPosition> leverPositions, Action doAfter)
        {
            var queue = new Queue<StepLever>();

            foreach (var leverPosition in leverPositions)
            {
                queue.Enqueue(Calculation.GetStepLeverToPosition(leverPosition));
            }
             
            leverMovement.Move(queue, doAfter);
        }

        public void ManulControlRun(StepLever stepLever)
        {
            if (leverMovement.IsRunning)
                return;
         
             if (stepLever.StepsCount == 0)
                 stepLever.StepsCount = Calculation.CalculateStepsToLeverZero(stepLever.Lever);
             else
                 stepLever.StepsCount = Calculation.CalculateStepsByDirection(stepLever.Lever, stepLever.StepsCount == 1);

            leverMovement.Move(stepLever);
        }

        public void ManualControlStop(LeverType type)
        {
            leverMovement.Stop(type);
        }

        public void Stop()
        {
            leverMovement.Stop();
        }

        public void Abort()
        {
            leverMovement.Abort();
        }

        public void SetStepsInterval(int interval)
        {
            leverMovement.StepsInterval = interval;
        }

        public double GetLeverPosition(LeverType type)
        {
            return Calculation.GetPartMovableByLeverType(type).AB;
        }

        public IEnumerable<LeverPosition> GetCurrentLeversPosition()
        {
            //yield return new LeverPosition(LeverType.Horizontal, GetLeverPosition(LeverType.Horizontal));
            //yield return new LeverPosition(LeverType.Lever1, GetLeverPosition(LeverType.Lever1));
            //yield return new LeverPosition(LeverType.Lever2, GetLeverPosition(LeverType.Lever2));
            return new[]
            {
                new LeverPosition(LeverType.Horizontal, GetLeverPosition(LeverType.Horizontal)),
                new LeverPosition(LeverType.Lever1, GetLeverPosition(LeverType.Lever1)),
                new LeverPosition(LeverType.Lever2, GetLeverPosition(LeverType.Lever2))
            };

        }

        public bool IsNowAtPosition(IEnumerable<LeverPosition> position)
        {
            var current = GetCurrentLeversPosition().OrderBy(i => i.LeverType);
            position = position.OrderBy(i => i.LeverType);

            return current.SequenceEqual(position);
        }

        public bool IsOnZeroPosition(LeverType type)
        {
            var lever = Calculation.GetPartMovableByLeverType(type);

            return lever.Workspace.ABzero == lever.AB;
        }

        private void ChangeLeverPosition(LeverType type, long stepsCount)
        {
            var lever = Calculation.GetPartMovableByLeverType(type);

            var oldValue = lever.AB;

            Calculation.SetNewLeverPosition(type, stepsCount);

            Location = Calculation.GetCurrentLocation();

            var newValue = lever.AB;

            LeverPositionChanged(this, new LeverPosition(type, newValue));

            if (lever.ABzero == null)
                return;

            if(oldValue == lever.Workspace.ABzero || newValue == lever.Workspace.ABzero)
              OnZeroPositionChanged(this, new LeverZeroPositionEventArgs(type, newValue == lever.Workspace.ABzero));
        }

        private void LeverMovement_OnStepsIntervalElapsed(object sender, StepLever e)
        {
            Location = Calculation.GetLocation(Location, e);
        }

        private void LeverMovement_OnMovingStart(object sender, StepLever e)
        {
            OnMovingStart(this, e);
        }

        private void LeverMovement_OnMovingEnd(object sender, LeverMovingEndEventArgs e)
        {
            ChangeLeverPosition(e.Lever, e.StepsCount);
            OnMovingEnd(this, e);
        }
    }
}
