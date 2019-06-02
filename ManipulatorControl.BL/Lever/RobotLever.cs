using LptStepperMotorControl.Stepper;

namespace ManipulatorControl.BL
{
    public class LeverStepper
    {
        public LeverType Type { get; private set; }

        public StepperMotor Stepper { get; set; }

        public LeverStepper(LeverType type, StepperMotor stepper)
        {
            Type = type;
            Stepper = stepper;
        }
    }
}
