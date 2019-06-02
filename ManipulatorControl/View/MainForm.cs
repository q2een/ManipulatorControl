using GCodeParser;
using ManipulatorControl.BL;
using ManipulatorControl.BL.Workspace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManipulatorControl
{
    public partial class MainForm : Form, IManipulatorControlView
    {
        private bool isHotKeyMode, isManualControlMode, isEditWorkspaceMode;

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

        public bool IsEditWorkspaceMode
        {
            get
            {
                return isEditWorkspaceMode;
            }
            private set
            {
                if (value == isEditWorkspaceMode)
                    return;

                isEditWorkspaceMode = value;

                gbWorkspaceInfo.Visible = value;  
                ToogleLeverNameLablesAndRadiobuttons(!value);

                tabControlType.SelectedTab = value ? tpManualControl : tpWorkspaces;

                gCodesControlMI.Visible = !value; 
                rbHorizontalLever.Checked = true;

                if (!value)
                {
                    tlpManualControl.Invalidate();
                    tlpManualControl.Update();
                }
            }
        }

        private LeverType GetEditWorkspaceModeActiveLever()
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
        private ManualControlItem activeControlItem;

        public event EventHandler OnViewClosing = delegate { };

        public event EventHandler<StepLever> ManualControlStart = delegate { };
        public event EventHandler<StepLever> ManualControlStop = delegate { };
        public event EventHandler InvokeStepperAbort = delegate { };
        public event EventHandler InvokeStepperStop = delegate { };
        public event EventHandler RunGCodeInterpreter = delegate { };
        public event EventHandler OpenSettings = delegate { };

        #region События для редактирования рабочих зон робота.

        public event EventHandler<EditWorkspaceEventArgs> InvokeWorkspaceValueChange = delegate { };
        public event EventHandler<WorkspaceEventArgs> InvokeSetEditWorkspaceMode = delegate { };
        public event EventHandler<WorkspaceEventArgs> InvokeCloseEditWorkspaceMode = delegate { };
        public event EventHandler<WorkspaceEventArgs> InvokeSaveWorkspaceValues = delegate { };
        public event EventHandler<WorkspaceEventArgs> InvokeRemoveWorkspace = delegate { };
        public event EventHandler<WorkspaceEventArgs> InvokeAddWorkspace = delegate { };
        public event EventHandler<WorkspaceEventArgs> InvokeRenameWorkspace = delegate { };
        public event EventHandler<WorkspaceEventArgs> InvokeSetActiveWorkspace = delegate { };
        public event EventHandler<EditWorkspaceEventArgs> OnActiveEditingLeverChanged = delegate { };

        #endregion

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
            IsEditWorkspaceMode = false;

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
            workspaceTSMI.Visible = tabControlType.SelectedTab == tpWorkspaces || IsEditWorkspaceMode;

            if (tabControlType.SelectedTab != tpManualControl && tabControlType.SelectedTab != tpGCodes)
                return;

            if(IsEditWorkspaceMode && tabControlType.SelectedTab == tpGCodes)
            {
                tabControlType.SelectedTab = tpManualControl;
                return;
            }

            IsManualControlMode = tabControlType.SelectedTab == tpManualControl; 
        }

        private void buttonsTypeControlMI_Click(object sender, EventArgs e)
        {
            IsManualControlMode = (sender as ToolStripMenuItem) == manualControlMI;
        }

        #region Редактирование рабочих зон робота.

        public void SetRobotWorkspaceParams(RobotWorkspace workspace)
        {
            if (workspace == null)
                return;

            this.Invoke(new Action(() =>
            {
                var lever = workspace.GetLeverByType(GetEditWorkspaceModeActiveLever());

                lblWorkspaceABmax.Text = lever.ABmax.ToString();
                lblWorkspaceABmin.Text = lever.ABmin.ToString();
                lblWorkspaceABZero.Text = lever.ABzero.ToString();
            }));
        }

        public void SetCurrentEditWorkspaceModeLeverPosition(LeverType leverType, double currentValue)
        {
            if (GetEditWorkspaceModeActiveLever() != leverType)
                return;

            this.Invoke(new Action(() =>
            {
                lblWorkspaceAB.Text = currentValue.ToString();
            }));
        }

        public void SetWorkspaces(IEnumerable<RobotWorkspace> workspaces, int activeWorkspaceIndex = 0)
        {
            lstWorkspaces.Items.Clear();
            lstWorkspaces.Items.AddRange(workspaces.ToArray());

            lstWorkspaces.SelectedIndex = workspaces.Count() == 0 ? -1 : (workspaces.Count() < activeWorkspaceIndex ? 0 : activeWorkspaceIndex);
        }

        public void SetEditWorkspaceMode(bool enable, RobotWorkspace workspace, MovableValueType editValues)
        {
            gbWorkspaceInfo.Text = "Рабочая зона: " + (enable ? workspace.Name : "");
            IsEditWorkspaceMode = enable;

            lstWorkspaces.Enabled = !enable;

            var hasNotNoneFlag = !editValues.HasFlag(MovableValueType.None);

            setMaxValueMI.Visible = hasNotNoneFlag && editValues.HasFlag(MovableValueType.Max);
            setMinValueMI.Visible = hasNotNoneFlag && editValues.HasFlag(MovableValueType.Min);
            setZeroValueMI.Visible = hasNotNoneFlag && editValues.HasFlag(MovableValueType.Zero);
            editValuesSeparatorMI.Visible = hasNotNoneFlag;

            setAsActiveWorkspaceMI.Visible = !enable;
            editWorkspaceValuesMI.Visible = !enable;

            editWorkspaceSeparatorMI.Visible = !enable;
            removeWorkspaceMI.Visible = !enable;
            addWorkspaceMI.Visible = !enable;
            renameWorkspace.Visible = !enable;

            saveWorkspaceValuesMI.Visible = enable;
            closeEditWorkspaceModeMI.Visible = enable;
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

            if (!showLabels)
            {
                rbLever1.Checked = false;
                rbHorizontalLever.Checked = false;
                rbLever2.Checked = false;
            }
        }

        private void TableHeaderRadiobuttons_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            
            tlpManualControl.Invalidate();
            tlpManualControl.Update();

            var index = rb == rbHorizontalLever ? 0 : (sender == rbLever1 ? 1 : 2);  
            var width = tlpManualControl.Width * (tlpManualControl.ColumnStyles[0].Width / 100.0f);

            tlpManualControl.CreateGraphics().FillRectangle(Brushes.DarkGray, width * index, rb.Location.Y + rb.Height, width, tlpManualControl.Height);

            OnActiveEditingLeverChanged(this, new EditWorkspaceEventArgs(GetEditWorkspaceModeActiveLever(), MovableValueType.None));
        }
         
        private void lstWorkspaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            var workspace = lstWorkspaces.SelectedItem as RobotWorkspace;

            workspaceTSMI.Visible = (tabControlType.SelectedTab == tpWorkspaces || IsEditWorkspaceMode) && workspace != null;

            if (workspace == null)
                return;

            lblHorizontalMax.Text = workspace.HorizontalLever.ABmax.ToString();
            lblHorizontalMin.Text = workspace.HorizontalLever.ABmin.ToString();
            lblHorizontalZero.Text = workspace.HorizontalLever.ABzero.ToString();
            lblLever1Max.Text = workspace.Lever1.ABmax.ToString();
            lblLever1Min.Text = workspace.Lever1.ABmin.ToString();
            lblLever1Zero.Text = workspace.Lever1.ABzero.ToString();
            lblLever2Max.Text = workspace.Lever2.ABmax.ToString();
            lblLever2Min.Text = workspace.Lever2.ABmin.ToString();
            lblLever2Zero.Text = workspace.Lever2.ABzero.ToString();
        }

        private void editWorkspaceValuesMI_Click(object sender, EventArgs e)
        {
            var index = lstWorkspaces.SelectedIndex;

            if (index == -1)
                return;

            InvokeSetEditWorkspaceMode(this, new WorkspaceEventArgs() { Index = index });
        }

        private void saveWorkspaceValuesMI_Click(object sender, EventArgs e)
        {
            InvokeSaveWorkspaceValues(this, null);
        }

        private void InvokeWorkspaceValueChangeMI_Click(object sender, EventArgs e)
        {
            var mi = sender as ToolStripMenuItem;

            if (mi == null)
                return;

            var valueType = mi == setMaxValueMI ? MovableValueType.Max : (mi == setMinValueMI ? MovableValueType.Min : MovableValueType.Zero);

            InvokeWorkspaceValueChange(this, new EditWorkspaceEventArgs(GetEditWorkspaceModeActiveLever(), valueType));
        }

        private void closeEditWorkspaceMode_Click(object sender, EventArgs e)
        {
            InvokeCloseEditWorkspaceMode(this, null);
        }

        private void removeWorkspaceMI_Click(object sender, EventArgs e)
        {
            InvokeRemoveWorkspace(this, new WorkspaceEventArgs(lstWorkspaces.SelectedIndex));
        }

        private void addWorkspaceMI_Click(object sender, EventArgs e)
        {
            var input = new InputMessageBox();

            if (input.ShowDialog() != DialogResult.OK)
                return;

            InvokeAddWorkspace(this, new WorkspaceEventArgs(input.Input));
        }

        private void renameWorkspace_Click(object sender, EventArgs e)
        {
            var workspace = lstWorkspaces.SelectedItem as RobotWorkspace;

            if (workspace == null)
                return;
            
            var input = new InputMessageBox() { Input = workspace.Name };

            if (input.ShowDialog() != DialogResult.OK)
                return;

            InvokeRenameWorkspace(this, new WorkspaceEventArgs(input.Input, lstWorkspaces.SelectedIndex));
        }

        private void setAsActiveWorkspaceMI_Click(object sender, EventArgs e)
        {
            InvokeSetActiveWorkspace(this, new WorkspaceEventArgs(lstWorkspaces.SelectedIndex));
        }
        
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnViewClosing(this, EventArgs.Empty);
        }

        public void SetCurrentLocation(bool isRunning, double x, double y, double z)
        {
            var action = new Action(() =>
            {
                statusLblCurrentPosition.Text = string.Format("X: {0:f2}  Y: {1:f2}  Z: {2:f2}", x, y, z);
                directionPanel.SetLocation(isRunning, x, y, z);
            });

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        public void SetZeroPositionState(bool isXYZero, bool isZZero)
        {
            directionPanel.SetZeroPositionState(isXYZero, isZZero);
        }

        public void SetCurrentPosition(LeverPosition position)
        {
            var action = new Action(() =>
            {
                if (position.Lever == LeverType.Horizontal)
                    lblHorizontalCurrent.Text = position.Position.ToString();

                if (position.Lever == LeverType.Lever1)
                    lblLever1Current.Text = position.Position.ToString();

                if (position.Lever == LeverType.Lever2)
                    lblLever2Current.Text = position.Position.ToString();
            });

            if (this.InvokeRequired)
                this.Invoke(action);
            else
                action();

        }
    }
}
