using LptStepperMotorControl.Stepper;
using ManipulatorControl.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UM160CalculationLib;

namespace ManipulatorControl
{
    public partial class SettingsForm : Form, ISettingsView
    {
        private readonly List<string> cmbItems = new List<string> { "Не задан", "1", "2", "3", "4", "5", "6", "7", "8", "9", "14", "16", "17" };
        List<ComboBox> comboBoxes, stepDirCmbs;

        public event EventHandler SaveSettings = delegate { };

        public SettingsForm()
        {
            InitializeComponent();

            comboBoxes = new List<ComboBox> { cmbXStep, cmbXDir, cmbXEnable, cmbYStep, cmbYDir, cmbYEnable, cmbZStep, cmbZDir, cmbZEnable, cmbCStep, cmbCDir, cmbCEnable };
            stepDirCmbs = comboBoxes.Except(new ComboBox[] { cmbXEnable, cmbYEnable, cmbZEnable, cmbCEnable }).ToList();

            comboBoxes.ForEach(cmb => { cmb.Items.AddRange(cmbItems.ToArray()); cmb.SelectedIndex = 0; });
        }

        public List<StepDirName> StepDirNames
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                foreach (var stepDirName in value)
                {
                    switch(stepDirName.Type)
                    {
                        case StepDirPinType.X:
                            SetStepDirEnablePinsToComboBoxes(stepDirName.StepDir, cmbXStep, cmbXDir, cmbXEnable);
                            break;
                        case StepDirPinType.Y:
                            SetStepDirEnablePinsToComboBoxes(stepDirName.StepDir, cmbYStep, cmbYDir, cmbYEnable);
                            break;
                        case StepDirPinType.Z:
                            SetStepDirEnablePinsToComboBoxes(stepDirName.StepDir, cmbZStep, cmbZDir, cmbZEnable);
                            break;
                        case StepDirPinType.C:
                            SetStepDirEnablePinsToComboBoxes(stepDirName.StepDir, cmbCStep, cmbCDir, cmbCEnable);
                            break;
                    }

                    stepperSettingsPanel1.SetPins(value);
                    stepperSettingsPanel2.SetPins(value);
                    stepperSettingsPanel3.SetPins(value);
                }
            }
        }

        public List<StepperMotor> SteperMotors
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DesignParameters DesignParameters
        {
            get
            {
                return designParametersTabs.DesignParameters;
            }

            set
            {
                designParametersTabs.DesignParameters = value;
            }
        }

        void ISettingsView.Show()
        {
            this.ShowDialog();
        }

        private void SetStepDirEnablePinsToComboBoxes(StepDirPin pins, ComboBox cmbStep, ComboBox cmbDir, ComboBox cmbEnable)
        {
            SetStepDirEnablePinToComboBox(pins.Step, cmbStep);
            SetStepDirEnablePinToComboBox(pins.Dir, cmbDir);
            SetStepDirEnablePinToComboBox(pins.Enable, cmbEnable);
        }

        private void SetStepDirEnablePinToComboBox(int pin, ComboBox comboBox)
        {
            var lbl = comboBox.Tag as Label;

            if (lbl != null)
                lbl.Text = pin == 0 ? cmbItems[0] : pin.ToString();

            comboBox.SelectedIndex = pin == 0 ? 0 : cmbItems.IndexOf(pin.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSettings(sender, e);
        }

        // Обработка события изменения индекса в выпадающем списке.
        // Запрет на выбор одинаковых номером PIN для параметров, кроме параметра ENABLE
        // так как сигнал на включение может быть установлен на один PIN. 
        private void StepDirCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentCmb = sender as ComboBox;

            if (currentCmb == null)
                return;

            var linkedLabel = currentCmb.Tag as Label;

            if (linkedLabel != null)
                linkedLabel.ForeColor = linkedLabel.Text == cmbItems[currentCmb.SelectedIndex] ? Color.Green : Color.Salmon;

            var cmbWithSameValue = (stepDirCmbs.Contains(currentCmb) ? comboBoxes : stepDirCmbs).Where(cmb => cmb.SelectedIndex == currentCmb.SelectedIndex && !cmb.Equals(currentCmb));

            foreach (var cmb in cmbWithSameValue)
                cmb.SelectedIndex = 0;
        }
    }
}
