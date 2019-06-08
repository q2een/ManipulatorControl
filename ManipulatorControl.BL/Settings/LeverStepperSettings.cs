using ManipulatorControl.BL;

namespace ManipulatorControl.BL.Settings
{
    public class LeverStepperSettings
    {
        public LeverType LeverType { get; set; }

        public StepDirPinType PinType { get; set; }

        public LptStepperMotorControl.Stepper.StepperMotor Stepper { get; set; }

        public LeverStepperSettings(LeverType type, StepDirPinType pinType, LptStepperMotorControl.Stepper.StepperMotor stepper)
        {
            LeverType = type;
            PinType = pinType;
            Stepper = stepper;
        }
    }
}
