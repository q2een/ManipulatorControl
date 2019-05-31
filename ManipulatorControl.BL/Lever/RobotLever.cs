using LptStepperMotorControl.Stepper;

namespace ManipulatorControl.BL
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
