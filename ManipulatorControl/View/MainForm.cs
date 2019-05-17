using GCodeParser;
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
    public partial class MainForm : Form, IManipulatorControlView
    {
        private bool isHotKeyMode, isManualControlMode;

        public bool IsHotKeyMode
        {
            get { return isHotKeyMode; }
            set
            {
                hotKeysControlMI.Checked = value;
                buttonsControlMI.Checked = !value;

                foreach (var item in controlItems)
                {
                    item.Invalidate(value);
                }

                isHotKeyMode = value;
            }
        }
         
        public bool IsManualControlMode
        {
            get { return isManualControlMode; }
            set
            {
                manualControlMI.Checked = value;
                gCodesControlMI.Checked = !value;

                tabControlType.SelectedTab = value ? tpManualControl : tpGCodes;

                hotKeysControlMI.Visible = value;
                hotKeysControlMI.Enabled = value;
                buttonsControlMI.Visible = value;
                buttonsControlMI.Enabled = value;
                controlTypeSeparatorMI.Visible = value;

                interpreteGCodesMI.Visible = !value;
                interpreteGCodesMI.Enabled = !value;
                interpreteSeparatorMI.Visible = !value;

                isManualControlMode = value;
            }
        }

        public CoordinateDirections Directions
        {
            get
            {
                return directionPanel.Directions;
            }
            set
            {
                directionPanel.Directions = value;
            }
        }

        public List<GCodeException> ParserErrors
        {
            get
            {
                return lstErrors.Items.Cast<GCodeException>().ToList();
            }
            set
            {
                gbErrors.Visible = value != null && value.Count > 0; 
                lstErrors.Items.Clear();
                lstErrors.Items.AddRange(value.ToArray());
            }
        }

        public string[] GCodeLines
        {
            get
            {
                return gCodesBox.Lines;
            }
            set
            {
                gCodesBox.Lines = value;
            }
        }

        public bool IsZeroPositionSet
        {
            get
            {
                return directionPanel.IsZeroEnabled;
            }
            set
            {
                directionPanel.IsZeroEnabled = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            controlItems = new[] {
                                    new ManualControlItem(LeverType.Horizontal, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, btnZPos, btnZNeg, btnZNull),
                                    new ManualControlItem(LeverType.Lever1, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, btnYPos, btnYNeg, btnYNull),
                                    new ManualControlItem(LeverType.Lever2, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, btnXPos, btnXNeg, btnXNull),
                                 };

            IsHotKeyMode = true;
        }                                                                                                

        private readonly ManualControlItem[] controlItems;


        public event StepperMoveEventHandler ManualControlStart = delegate { };
        public event StepperMoveEventHandler ManualControlStop = delegate { };
        public event EventHandler InvokeStepperAbort = delegate { };
        public event EventHandler InvokeStepperStop = delegate { };
        public event EventHandler RunGCodeInterpreter = delegate { };
        public event EventHandler OpenSettings = delegate { };

        private ManualControlItem activeControlItem;

        private void HandleStartManualMove(object sender, EventArgs e)
        {
            var controlItem = sender as ManualControlItem;

            if (!IsManualControlMode || controlItem == null)
                return;

            if (activeControlItem != null)
            {
                if(controlItem != activeControlItem)
                {
                    controlItem.Active = null;
                    return;
                }
                return;
            }

            ManualControlStart(this, controlItem.StepLever);

            activeControlItem = controlItem;
        }

        private void HandleStopManualMove(object sender, EventArgs e)
        {
            var controlItem = sender as ManualControlItem;

            if (!IsManualControlMode || controlItem == null || activeControlItem == null)
                return;
  
            if (controlItem != activeControlItem)
            {
                controlItem.Active = null;
                return;
            }

            ManualControlStop(this, controlItem.StepLever);

            activeControlItem = null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IsManualControlMode = true;

             foreach (var item in controlItems)
             {
                 this.KeyDown += item.HandleKeyDown;
                 this.KeyUp += item.HandleKeyUp;
                 item.OnInvokeStart += HandleStartManualMove;
                 item.OnInvokeStop += HandleStopManualMove;
             }

            btnStop.Click += InvokeStepperStop;
            btnAbort.Click += InvokeStepperAbort;
            interpreteGCodesMI.Click += RunGCodeInterpreter;

            settingsMI.Click += OpenSettings;
        }

        private void buttonsControlMI_Click(object sender, EventArgs e)
        {
            IsHotKeyMode = (sender as ToolStripMenuItem) == hotKeysControlMI;
        }

        private void lstErrors_DoubleClick(object sender, EventArgs e)
        {
            var selected = lstErrors.SelectedItem as GCodeException;

            if (selected == null)
                return;

            gCodesBox.SetCursorOnLineStart(selected.Line - 1);
        }

        private void tabControlType_Selected(object sender, TabControlEventArgs e)
        {
            IsManualControlMode = tabControlType.SelectedTab == tpManualControl;
        }

        private void buttonsTypeControlMI_Click(object sender, EventArgs e)
        {
            IsManualControlMode = (sender as ToolStripMenuItem) == manualControlMI;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            directionPanel.IsZeroEnabled = true;

            
            /* var lever1 = new LeverDesignParameters(825, 530, 320, 320, 1000, 12, 1.0 / 240.0, 112.07, 55.62);
             var lever2 = new LeverDesignParameters(670, 360, 320, 320, 1000, 12, 1.0 / 240.0, 0, 0) { PhiMax = 360, PhiMin = 0 };
             var leverz = new HorizontalLeverDesignParameters(0, 1000, 0, 2.94);

             var des = new DesignParameters(710, 1000, 615, leverz, lever1, lever2);

             var calc = new Calculation(des);

             var z = AnglesCalculation.GetAngles(des, -130.37, 1444.17);

             var d = PulseCalculation.GetPulsesCount(lever1, lever1.PhiMin); 


             var zs = calc.CalculateStepsToAbValue(LeverType.Lever1, 340);

             var asd = PulseCalculation.GetNewAB(lever1, -zs);

             var sad = PulseCalculation.GetPulsesCount(leverz, 250);   */
        }


    }
}
