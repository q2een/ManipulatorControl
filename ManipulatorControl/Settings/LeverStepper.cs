using ManipulatorControl.BL;

namespace ManipulatorControl.Settings
{
    public class LeverStepper
    {
        public LeverType LeverType { get; set; }

        public StepDirPinType PinType { get; set; }

        public LptStepperMotorControl.Stepper.StepperMotor Stepper { get; set; }

        public LeverStepper(LeverType type, StepDirPinType pinType, LptStepperMotorControl.Stepper.StepperMotor stepper)
        {
            LeverType = type;
            PinType = pinType;
            Stepper = stepper;
        }
    }
}
