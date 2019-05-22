using GCodeParser;
using ManipulatorControl.Model;
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
        private bool isHotKeyMode, isManualControlMode, isSetWorkspaceMode;

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

        public bool IsSetWorkspaceMode
        {
            get
            {
                return isSetWorkspaceMode;
                return true;
                throw new NotImplementedException();
            }
            set
            {
                if (value == isSetWorkspaceMode)
                    return;

                isSetWorkspaceMode = value;

                ToogleLeverNameLablesAndRadiobuttons(!value);
                // SetWorkspaceModeChanged(this, EventArgs.Empty);
            }
        }

        private RobotWorkspace activeWorkspace;

        public void SetRobotWorkspaceParams(RobotWorkspace workspace)
        {
            if (activeWorkspace != workspace)
                activeWorkspace = workspace;

            this.Invoke(new Action(() =>
            {
                gbWorkspaceInfo.Text = "Рабочая зона: " + workspace.Name;

                var lever = workspace.GetLeverByType(GetSetWorkspaceModeActiveLever());

                lblWorkspaceAB.Text = lever.AB.ToString();
                lblWorkspaceABmax.Text = lever.ABmax.ToString();
                lblWorkspaceABmin.Text = lever.ABmin.ToString();
                lblWorkspaceABZero.Text = lever.ABzero.ToString();
            }));
        }

        private LeverType GetSetWorkspaceModeActiveLever()
        {
            if (rbHorizontalLever.Checked)
                return LeverType.Horizontal;
            if (rbLever1.Checked)
                return LeverType.Lever1;

            return LeverType.Lever2;
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

        public event EventHandler<WorkspaceEventArgs> InvokeWorkspaceValueChange;
        public event EventHandler SetWorkspaceModeChanged = delegate { };

        private ManualControlItem activeControlItem;

        private void HandleStartManualMove(object sender, EventArgs e)
        {
            var controlItem = sender as ManualControlItem;

            if (!IsManualControlMode || controlItem == null)
                return;

            if (activeControlItem != null)
            {
                if (controlItem != activeControlItem)
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
            IsSetWorkspaceMode = true;

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
            if(tabControlType.SelectedTab == tpManualControl || tabControlType.SelectedTab == tpGCodes)
                IsManualControlMode = tabControlType.SelectedTab == tpManualControl;
        }

        private void buttonsTypeControlMI_Click(object sender, EventArgs e)
        {
            IsManualControlMode = (sender as ToolStripMenuItem) == manualControlMI;
        }

        private void TableHeaderRadiobuttons_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            
            tlpManualControl.Invalidate();
            tlpManualControl.Update();

            var index = rb == rbHorizontalLever ? 0 : (sender == rbLever1 ? 1 : 2);  
            var width = tlpManualControl.Width * (tlpManualControl.ColumnStyles[0].Width / 100.0f);

            tlpManualControl.CreateGraphics().FillRectangle(Brushes.DarkGray, width * index, rb.Location.Y + rb.Height, width, tlpManualControl.Height);

            SetRobotWorkspaceParams(activeWorkspace);
        }


        private void lstWorkspaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            var workspace = lstWorkspaces.SelectedItem as RobotWorkspace;

            if (workspace == null)
                return;

            lblHorizontalMax.Text = workspace.HorizontalLeverWorkspace.ABmax.ToString();
            lblHorizontalMin.Text = workspace.HorizontalLeverWorkspace.ABmin.ToString();
            lblHorizontalZero.Text = workspace.HorizontalLeverWorkspace.ABzero.ToString();
            lblLever1Max.Text = workspace.Lever1Workspace.ABmax.ToString();
            lblLever1Min.Text = workspace.Lever1Workspace.ABmin.ToString();
            lblLever1Zero.Text = workspace.Lever1Workspace.ABzero.ToString();
            lblLever2Max.Text = workspace.Lever2Workspace.ABmax.ToString();
            lblLever2Min.Text = workspace.Lever2Workspace.ABmin.ToString();
            lblLever2Zero.Text = workspace.Lever2Workspace.ABzero.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            directionPanel.IsZeroEnabled = true;
        }


        private void ToogleLeverNameLablesAndRadiobuttons(bool showLabels)
        {
            Control remove1 = showLabels ? rbHorizontalLever : (Control)lblHorizontalLever;
            Control remove2 = showLabels ? rbLever1 : (Control)lblLever1;
            Control remove3 = showLabels ? rbLever2 : (Control)lblLever2;

            Control add1 = !showLabels ? rbHorizontalLever : (Control)lblHorizontalLever;
            Control add2 = !showLabels ? rbLever1 : (Control)lblLever1;
            Control add3 = !showLabels ? rbLever2 : (Control)lblLever2;

            tlpManualControl.Controls.Remove(remove1);
            tlpManualControl.Controls.Remove(remove2);
            tlpManualControl.Controls.Remove(remove3);

            tlpManualControl.Controls.Add(add1, 0, 0);
            tlpManualControl.Controls.Add(add2, 1, 0);
            tlpManualControl.Controls.Add(add3, 2, 0);
        }

        public void SetWorkspaces(RobotWorkspace[] workspaces)
        {
            lstWorkspaces.Items.Clear();
            lstWorkspaces.Items.AddRange(workspaces);
        }
    }
}
