using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LptStepperMotorControl.Stepper;

namespace ManipulatorControl.Controls
{
    public partial class StepperSettingsPanel : UserControl
    {
        public override string Text
        {
            get
            {
                return gbMain.Text;
            }
            set
            {
                gbMain.Text = value;
            }
        }

        public LeverType LeverType
        {
            get
            {
                return (LeverType)Enum.Parse(typeof(LeverType), cmbLeverType.SelectedValue.ToString()); ;
            }
            set
            {
                cmbLeverType.SelectedIndex = (int)value;
            }
        }

        public float Speed
        {
            get
            {
                float s = float.NaN;
                float.TryParse(tbSpeed.Text, System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out s);
                return s;
            }
            set
            {
                tbSpeed.Text = value == float.NaN ? "" : value.ToString();
            }
        }

        public float Acceleration
        {
            get
            {
                float a = float.NaN;
                float.TryParse(tbAccel.Text, System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out a);
                return a;
            }
            set
            {
                tbAccel.Text = value == float.NaN ? "" : value.ToString();
            }
        }

        public int AccelerationInMS
        {
            get
            {
                int a = 0;
                int.TryParse(tbSecAccel.Text, out a);
                return a;
            }
            set
            {
                tbSecAccel.Text = value.ToString();
            }
        }

        public bool CWDirectionIsLogicalZero
        {
            get
            {
                return cbIsLog0.Checked;
            }
            set
            {
                cbIsLog0.Checked = value;
            }
        }

        public StepDirPin StepDirPin
        {
            get
            {
                var item = cmbLptPins.SelectedItem as StepDirName;
                return item == null ? new StepDirPin() : item.StepDir;
            }
            set
            {                   
                cmbLptPins.SelectedItem = this.pins.FirstOrDefault(pin => pin.StepDir == value) ?? cmbLptPins.SelectedItem;
            }
        }

        public StepperMotor Stepper
        {
            get
            {
                return null;
            }
            set
            {
                if (value == null)
                    return;

                Acceleration = value.Acceleration;
                Speed = value.MaxSpeed;
                CWDirectionIsLogicalZero = value.CWDirectionIsLogicalZero;
                StepDirPin = value.Pins;
            }
        }

        public bool IsValid
        {
            get
            {
                return errorProvider.GetError(tbAccel) == "" && errorProvider.GetError(tbSpeed) == "";
            }
        }

        public StepperSettingsPanel()
        {
            InitializeComponent();

            cmbLeverType.DataSource = Enum.GetNames(typeof(LeverType));
        }

        public StepperSettingsPanel(IEnumerable<StepDirName> pins) : this()
        {
            SetPins(pins);
        }

        public void SetPins(IEnumerable<StepDirName> pins)
        {
            this.pins = pins;
            cmbLptPins.DataSource = this.pins;
        }

        private void CalculateNewAccel()
        {
            if (Speed != float.NaN)
                Acceleration = Speed / (AccelerationInMS / 1000.0f);
        }

        private void CalculateNewAccelInMS()
        {
            if (Speed != float.NaN && Acceleration != float.NaN && Acceleration != 0)
                AccelerationInMS = Convert.ToInt32(Speed / (Acceleration / 1000));
        }

        private void KeyValidating_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void tbSecAccel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void tbSecAccel_TextChanged(object sender, EventArgs e)
        {
            if (tbSecAccel.Focused)
                CalculateNewAccel();
        }

        private void tbAccel_TextChanged(object sender, EventArgs e)
        {
            if (tbAccel.Focused)
                CalculateNewAccelInMS();
        }

        private void tbSpeed_TextChanged(object sender, EventArgs e)
        {
            CalculateNewAccelInMS();
        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            if((tb == tbSpeed && (Speed == float.NaN || Speed == 0)) || 
                (tb == tbAccel && (Acceleration == float.NaN || Acceleration == 0)))
                errorProvider.SetError(tb, "Необходимо указать значение больше нуля");
            else
                errorProvider.Clear();
        }

        private IEnumerable<StepDirName> pins;
    }
}
