using LptStepperMotorControl.Stepper;

namespace ManipulatorControl.BL
{
    public class LeverMovingEndEventArgs : StepLever
    {
        public StepperStopReason StopReason { get; set;}

        public LeverMovingEndEventArgs(LeverType lever, long stepsCount, StepperStopReason stopReason) : base(lever, stepsCount)
        {
            StopReason = stopReason;
        }

        public LeverMovingEndEventArgs(StepLever stepLever, StepperStopReason stopReason) : this(stepLever.Lever, stepLever.StepsCount, stopReason)
        {
        }
    }
}
