using LptStepperMotorControl.Stepper;
using System.Windows.Forms;

namespace ManipulatorControl
{
    public class ManualUserControls
    {
        public Button Button { get; private set; }

        public Keys Key { get; set; }

        /// <summary>
        /// true - cw, false - ccw, null = to Zero.
        /// </summary>
        public bool? Direction { get; set; }

        public ManualUserControls(Button button, Keys key, bool? direction)
        {
            Button = button;
            Key = key;
            Direction = direction;
        }

        public static implicit operator long(ManualUserControls muc)
        {
            if (muc.Direction == null)
                return 0;

            if (muc.Direction == true)
                return 1;

            return -1;
        }
    }
}
