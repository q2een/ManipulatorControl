using LptStepperMotorControl.Stepper;

namespace ManipulatorControl
{
    public class StepDirName
    {
        public StepDirPinType Type { get; set; }

        public StepDirPin StepDir { get; set; }

        public StepDirName(StepDirPinType pinType, StepDirPin pins)
        {
            Type = pinType;
            StepDir = pins;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} {2} {3}", Type, StepDir.Step, StepDir.Dir, StepDir.Enable);
        }
    }
}
