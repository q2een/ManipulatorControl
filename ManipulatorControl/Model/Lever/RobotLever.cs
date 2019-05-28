using LptStepperMotorControl.Stepper;

namespace ManipulatorControl
{
    public class RobotLever
    {
        public LeverType Type { get; private set; }

        public StepperMotor Stepper { get; set; }

        public RobotLever(LeverType type, StepperMotor stepper)
        {
            Type = type;
            Stepper = stepper;
        }
    }
}
