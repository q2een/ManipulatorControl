using LptStepperMotorControl.Stepper;
using ManipulatorControl.BL.Settings;
using ManipulatorControl.Controls;
using ManipulatorControl.Settings;
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

namespace ManipulatorControl.View
{
    public partial class SettingsForm : Form, ISettingsView
    {
        private readonly List<string> cmbItems = new List<string> { "Не задан", "1", "2", "3", "4", "5", "6", "7", "8", "9", "14", "16", "17" };
        List<ComboBox> comboBoxes, stepDirCmbs;

        private readonly StepperSettingsPanel[] steppersPanels;

        public event EventHandler SaveSettings = delegate { };

        public SettingsForm()
        {
            InitializeComponent();

            comboBoxes = new List<ComboBox> { cmbXStep, cmbXDir, cmbXEnable, cmbYStep, cmbYDir, cmbYEnable, cmbZStep, cmbZDir, cmbZEnable, cmbCStep, cmbCDir, cmbCEnable };
            stepDirCmbs = comboBoxes.Except(new ComboBox[] { cmbXEnable, cmbYEnable, cmbZEnable, cmbCEnable }).ToList();
            steppersPanels = new[] { stepperSettingsPanel1, stepperSettingsPanel2, stepperSettingsPanel3 };
            comboBoxes.ForEach(cmb => { cmb.Items.AddRange(cmbItems.ToArray()); cmb.SelectedIndex = 0; });


        }

        public List<StepDirName> StepDirNames
        {
            get
            {
                var stepDirNames = new List<StepDirName>();

                stepDirNames.Add(GetStepDirName(StepDirPinType.X));
                stepDirNames.Add(GetStepDirName(StepDirPinType.Y));
                stepDirNames.Add(GetStepDirName(StepDirPinType.Z));
                stepDirNames.Add(GetStepDirName(StepDirPinType.C));

                return stepDirNames;
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

        public List<LeverStepperSettings> LeverSteppers
        {
            get
            {
                var leverSteppers = new List<LeverStepperSettings>();
                
                for (int i = 0; i < steppersPanels.Length; i++)
                {
                    var panel = steppersPanels[i];
                    leverSteppers.Add(new LeverStepperSettings(panel.LeverType, StepDirNames.Single(pin=> pin.StepDir == panel.StepDirPin).Type, panel.Stepper)); 
                }

                return leverSteppers;
            }
            set
            {
                if (value.Count != 3)
                    throw new Exception("Недопустимые параметры для настройки шаговых двигателей");

                for (int i = 0; i < steppersPanels.Length; i++)
                {
                    steppersPanels[i].StepDirPin = GetStepDirName(value[i].PinType).StepDir;
                    steppersPanels[i].Stepper = value[i].Stepper;
                    steppersPanels[i].LeverType = value[i].LeverType;
                }
            }
        }

        public DesignParameters DesignParameters
        {
            get
            {
                return designParametersControl.DesignParameters;
            }

            set
            {
                designParametersControl.DesignParameters = value;
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

        private int GetSelectedPin(ComboBox cmb)
        {
            if (cmb.SelectedIndex <= 0)
                return 0;

            return int.Parse(cmbItems[cmb.SelectedIndex]);
        }

        private StepDirName GetStepDirName(StepDirPinType pinType)
        {
            StepDirPin pins = new StepDirPin();

            switch (pinType)
            {
                case StepDirPinType.X:
                    pins = new StepDirPin(GetSelectedPin(cmbXStep), GetSelectedPin(cmbXDir), GetSelectedPin(cmbXEnable));
                    break;
                case StepDirPinType.Y:
                    pins = new StepDirPin(GetSelectedPin(cmbYStep), GetSelectedPin(cmbYDir), GetSelectedPin(cmbYEnable));
                    break;
                case StepDirPinType.Z:
                    pins = new StepDirPin(GetSelectedPin(cmbZStep), GetSelectedPin(cmbZDir), GetSelectedPin(cmbZEnable));
                    break;
                case StepDirPinType.C:
                    pins = new StepDirPin(GetSelectedPin(cmbCStep), GetSelectedPin(cmbCDir), GetSelectedPin(cmbCEnable));
                    break;
            }

            return new StepDirName(pinType, pins);
        }

        private void SetStepDirEnablePinToComboBox(int pin, ComboBox comboBox)
        {
            var lbl = comboBox.Tag as Label;

            if (lbl != null)
                lbl.Text = pin == 0 ? cmbItems[0] : pin.ToString();

            comboBox.SelectedIndex = pin == 0 ? 0 : cmbItems.IndexOf(pin.ToString());
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveSettings(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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
