﻿namespace ManipulatorControl
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.controlTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.manualControlMI = new System.Windows.Forms.ToolStripMenuItem();
            this.gCodesControlMI = new System.Windows.Forms.ToolStripMenuItem();
            this.controlTypeSeparatorMI = new System.Windows.Forms.ToolStripSeparator();
            this.buttonsControlMI = new System.Windows.Forms.ToolStripMenuItem();
            this.hotKeysControlMI = new System.Windows.Forms.ToolStripMenuItem();
            this.interpreteSeparatorMI = new System.Windows.Forms.ToolStripSeparator();
            this.interpreteGCodesMI = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMI = new System.Windows.Forms.ToolStripMenuItem();
            this.workspaceTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsActiveWorkspaceMI = new System.Windows.Forms.ToolStripMenuItem();
            this.editWorkspaceValuesMI = new System.Windows.Forms.ToolStripMenuItem();
            this.editWorkspaceSeparatorMI = new System.Windows.Forms.ToolStripSeparator();
            this.addWorkspaceMI = new System.Windows.Forms.ToolStripMenuItem();
            this.renameWorkspace = new System.Windows.Forms.ToolStripMenuItem();
            this.removeWorkspaceMI = new System.Windows.Forms.ToolStripMenuItem();
            this.setMaxValueMI = new System.Windows.Forms.ToolStripMenuItem();
            this.setMinValueMI = new System.Windows.Forms.ToolStripMenuItem();
            this.setZeroValueMI = new System.Windows.Forms.ToolStripMenuItem();
            this.editValuesSeparatorMI = new System.Windows.Forms.ToolStripSeparator();
            this.saveWorkspaceValuesMI = new System.Windows.Forms.ToolStripMenuItem();
            this.closeEditWorkspaceModeMI = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblCurrentPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnXPos = new System.Windows.Forms.Button();
            this.btnXNeg = new System.Windows.Forms.Button();
            this.btnYPos = new System.Windows.Forms.Button();
            this.btnZPos = new System.Windows.Forms.Button();
            this.btnZNeg = new System.Windows.Forms.Button();
            this.btnYNeg = new System.Windows.Forms.Button();
            this.tlpManualControl = new System.Windows.Forms.TableLayoutPanel();
            this.lblHorizontalLever = new System.Windows.Forms.Label();
            this.lblLever1 = new System.Windows.Forms.Label();
            this.lblLever2 = new System.Windows.Forms.Label();
            this.btnZNull = new System.Windows.Forms.Button();
            this.btnYNull = new System.Windows.Forms.Button();
            this.btnXNull = new System.Windows.Forms.Button();
            this.gbErrors = new System.Windows.Forms.GroupBox();
            this.lstErrors = new System.Windows.Forms.ListBox();
            this.tabControlType = new System.Windows.Forms.TabControl();
            this.tpManualControl = new System.Windows.Forms.TabPage();
            this.gbWorkspaceInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWorkspaceABmax = new System.Windows.Forms.Label();
            this.lblWorkspaceABmin = new System.Windows.Forms.Label();
            this.lblWorkspaceABZero = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWorkspaceAB = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tpGCodes = new System.Windows.Forms.TabPage();
            this.gCodesBox = new ManipulatorControl.EditorCodeBox();
            this.tpWorkspaces = new System.Windows.Forms.TabPage();
            this.tlpWorkspaceInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblHorizontalMax = new System.Windows.Forms.Label();
            this.lblLever1Max = new System.Windows.Forms.Label();
            this.lblLever2Max = new System.Windows.Forms.Label();
            this.lblHorizontalMin = new System.Windows.Forms.Label();
            this.lblLever1Min = new System.Windows.Forms.Label();
            this.lblLever2Min = new System.Windows.Forms.Label();
            this.lblHorizontalZero = new System.Windows.Forms.Label();
            this.lblLever1Zero = new System.Windows.Forms.Label();
            this.lblLever2Zero = new System.Windows.Forms.Label();
            this.lstWorkspaces = new System.Windows.Forms.ListBox();
            this.rbHorizontalLever = new System.Windows.Forms.RadioButton();
            this.rbLever1 = new System.Windows.Forms.RadioButton();
            this.rbLever2 = new System.Windows.Forms.RadioButton();
            this.rightSidePanel = new System.Windows.Forms.Panel();
            this.directionPanel = new ManipulatorControl.DirectionIndicationPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblHorizontalCurrent = new System.Windows.Forms.Label();
            this.lblLever1Current = new System.Windows.Forms.Label();
            this.lblLever2Current = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpManualControl.SuspendLayout();
            this.gbErrors.SuspendLayout();
            this.tabControlType.SuspendLayout();
            this.tpManualControl.SuspendLayout();
            this.gbWorkspaceInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tpGCodes.SuspendLayout();
            this.tpWorkspaces.SuspendLayout();
            this.tlpWorkspaceInfo.SuspendLayout();
            this.rightSidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlTSMI,
            this.settingsMI,
            this.workspaceTSMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(929, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // controlTSMI
            // 
            this.controlTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualControlMI,
            this.gCodesControlMI,
            this.controlTypeSeparatorMI,
            this.buttonsControlMI,
            this.hotKeysControlMI,
            this.interpreteSeparatorMI,
            this.interpreteGCodesMI});
            this.controlTSMI.Name = "controlTSMI";
            this.controlTSMI.Size = new System.Drawing.Size(85, 20);
            this.controlTSMI.Text = "Управление";
            // 
            // manualControlMI
            // 
            this.manualControlMI.Checked = true;
            this.manualControlMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.manualControlMI.Name = "manualControlMI";
            this.manualControlMI.Size = new System.Drawing.Size(307, 22);
            this.manualControlMI.Text = "Ручное управление";
            this.manualControlMI.Click += new System.EventHandler(this.buttonsTypeControlMI_Click);
            // 
            // gCodesControlMI
            // 
            this.gCodesControlMI.Name = "gCodesControlMI";
            this.gCodesControlMI.Size = new System.Drawing.Size(307, 22);
            this.gCodesControlMI.Text = "G коды";
            this.gCodesControlMI.Click += new System.EventHandler(this.buttonsTypeControlMI_Click);
            // 
            // controlTypeSeparatorMI
            // 
            this.controlTypeSeparatorMI.Name = "controlTypeSeparatorMI";
            this.controlTypeSeparatorMI.Size = new System.Drawing.Size(304, 6);
            // 
            // buttonsControlMI
            // 
            this.buttonsControlMI.Checked = true;
            this.buttonsControlMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buttonsControlMI.Name = "buttonsControlMI";
            this.buttonsControlMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.buttonsControlMI.Size = new System.Drawing.Size(307, 22);
            this.buttonsControlMI.Text = "Управление кнопками";
            this.buttonsControlMI.Click += new System.EventHandler(this.buttonsControlMI_Click);
            // 
            // hotKeysControlMI
            // 
            this.hotKeysControlMI.Name = "hotKeysControlMI";
            this.hotKeysControlMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.hotKeysControlMI.Size = new System.Drawing.Size(307, 22);
            this.hotKeysControlMI.Text = "Управление горячими клавишами";
            this.hotKeysControlMI.Click += new System.EventHandler(this.buttonsControlMI_Click);
            // 
            // interpreteSeparatorMI
            // 
            this.interpreteSeparatorMI.Name = "interpreteSeparatorMI";
            this.interpreteSeparatorMI.Size = new System.Drawing.Size(304, 6);
            // 
            // interpreteGCodesMI
            // 
            this.interpreteGCodesMI.Name = "interpreteGCodesMI";
            this.interpreteGCodesMI.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.interpreteGCodesMI.Size = new System.Drawing.Size(307, 22);
            this.interpreteGCodesMI.Text = "Выполнить G коды";
            // 
            // settingsMI
            // 
            this.settingsMI.Name = "settingsMI";
            this.settingsMI.Size = new System.Drawing.Size(83, 20);
            this.settingsMI.Text = "Параметры";
            // 
            // workspaceTSMI
            // 
            this.workspaceTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsActiveWorkspaceMI,
            this.editWorkspaceValuesMI,
            this.editWorkspaceSeparatorMI,
            this.addWorkspaceMI,
            this.renameWorkspace,
            this.removeWorkspaceMI,
            this.setMaxValueMI,
            this.setMinValueMI,
            this.setZeroValueMI,
            this.editValuesSeparatorMI,
            this.saveWorkspaceValuesMI,
            this.closeEditWorkspaceModeMI});
            this.workspaceTSMI.Name = "workspaceTSMI";
            this.workspaceTSMI.Size = new System.Drawing.Size(93, 20);
            this.workspaceTSMI.Text = "Рабочая зона";
            this.workspaceTSMI.Visible = false;
            // 
            // setAsActiveWorkspaceMI
            // 
            this.setAsActiveWorkspaceMI.Name = "setAsActiveWorkspaceMI";
            this.setAsActiveWorkspaceMI.Size = new System.Drawing.Size(266, 22);
            this.setAsActiveWorkspaceMI.Text = "Установить";
            this.setAsActiveWorkspaceMI.Click += new System.EventHandler(this.setAsActiveWorkspaceMI_Click);
            // 
            // editWorkspaceValuesMI
            // 
            this.editWorkspaceValuesMI.Name = "editWorkspaceValuesMI";
            this.editWorkspaceValuesMI.Size = new System.Drawing.Size(266, 22);
            this.editWorkspaceValuesMI.Text = "Изменить значения";
            this.editWorkspaceValuesMI.Click += new System.EventHandler(this.editWorkspaceValuesMI_Click);
            // 
            // editWorkspaceSeparatorMI
            // 
            this.editWorkspaceSeparatorMI.Name = "editWorkspaceSeparatorMI";
            this.editWorkspaceSeparatorMI.Size = new System.Drawing.Size(263, 6);
            // 
            // addWorkspaceMI
            // 
            this.addWorkspaceMI.Name = "addWorkspaceMI";
            this.addWorkspaceMI.Size = new System.Drawing.Size(266, 22);
            this.addWorkspaceMI.Text = "Добавить";
            this.addWorkspaceMI.Click += new System.EventHandler(this.addWorkspaceMI_Click);
            // 
            // renameWorkspace
            // 
            this.renameWorkspace.Name = "renameWorkspace";
            this.renameWorkspace.Size = new System.Drawing.Size(266, 22);
            this.renameWorkspace.Text = "Переименовать";
            this.renameWorkspace.Click += new System.EventHandler(this.renameWorkspace_Click);
            // 
            // removeWorkspaceMI
            // 
            this.removeWorkspaceMI.Name = "removeWorkspaceMI";
            this.removeWorkspaceMI.Size = new System.Drawing.Size(266, 22);
            this.removeWorkspaceMI.Text = "Удалить";
            this.removeWorkspaceMI.Click += new System.EventHandler(this.removeWorkspaceMI_Click);
            // 
            // setMaxValueMI
            // 
            this.setMaxValueMI.Name = "setMaxValueMI";
            this.setMaxValueMI.Size = new System.Drawing.Size(266, 22);
            this.setMaxValueMI.Text = "Установить максимальный предел";
            this.setMaxValueMI.Visible = false;
            this.setMaxValueMI.Click += new System.EventHandler(this.InvokeWorkspaceValueChangeMI_Click);
            // 
            // setMinValueMI
            // 
            this.setMinValueMI.Name = "setMinValueMI";
            this.setMinValueMI.Size = new System.Drawing.Size(266, 22);
            this.setMinValueMI.Text = "Установить минимальный предел";
            this.setMinValueMI.Visible = false;
            this.setMinValueMI.Click += new System.EventHandler(this.InvokeWorkspaceValueChangeMI_Click);
            // 
            // setZeroValueMI
            // 
            this.setZeroValueMI.Name = "setZeroValueMI";
            this.setZeroValueMI.Size = new System.Drawing.Size(266, 22);
            this.setZeroValueMI.Text = "Установить ноль";
            this.setZeroValueMI.Visible = false;
            this.setZeroValueMI.Click += new System.EventHandler(this.InvokeWorkspaceValueChangeMI_Click);
            // 
            // editValuesSeparatorMI
            // 
            this.editValuesSeparatorMI.Name = "editValuesSeparatorMI";
            this.editValuesSeparatorMI.Size = new System.Drawing.Size(263, 6);
            this.editValuesSeparatorMI.Visible = false;
            // 
            // saveWorkspaceValuesMI
            // 
            this.saveWorkspaceValuesMI.Name = "saveWorkspaceValuesMI";
            this.saveWorkspaceValuesMI.Size = new System.Drawing.Size(266, 22);
            this.saveWorkspaceValuesMI.Text = "Сохранить изменения";
            this.saveWorkspaceValuesMI.Visible = false;
            this.saveWorkspaceValuesMI.Click += new System.EventHandler(this.saveWorkspaceValuesMI_Click);
            // 
            // closeEditWorkspaceModeMI
            // 
            this.closeEditWorkspaceModeMI.Name = "closeEditWorkspaceModeMI";
            this.closeEditWorkspaceModeMI.Size = new System.Drawing.Size(266, 22);
            this.closeEditWorkspaceModeMI.Text = "Отменить изменения";
            this.closeEditWorkspaceModeMI.Visible = false;
            this.closeEditWorkspaceModeMI.Click += new System.EventHandler(this.closeEditWorkspaceMode_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusLblCurrentPosition});
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(929, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(161, 17);
            this.toolStripStatusLabel1.Text = "Текущее положение схвата:";
            // 
            // statusLblCurrentPosition
            // 
            this.statusLblCurrentPosition.Name = "statusLblCurrentPosition";
            this.statusLblCurrentPosition.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnAbort);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(10, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 95);
            this.panel1.TabIndex = 2;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Coral;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(34, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 54);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "СТОП";
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.Red;
            this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbort.Location = new System.Drawing.Point(237, 20);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(120, 54);
            this.btnAbort.TabIndex = 3;
            this.btnAbort.Text = "ПРЕРВАТЬ";
            this.btnAbort.UseVisualStyleBackColor = false;
            // 
            // btnXPos
            // 
            this.btnXPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnXPos.Image = global::ManipulatorControl.Properties.Resources.arrow_up;
            this.btnXPos.Location = new System.Drawing.Point(361, 37);
            this.btnXPos.Margin = new System.Windows.Forms.Padding(7);
            this.btnXPos.Name = "btnXPos";
            this.btnXPos.Size = new System.Drawing.Size(165, 65);
            this.btnXPos.TabIndex = 9;
            this.btnXPos.Text = "↑";
            this.btnXPos.UseVisualStyleBackColor = true;
            // 
            // btnXNeg
            // 
            this.btnXNeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnXNeg.Image = ((System.Drawing.Image)(resources.GetObject("btnXNeg.Image")));
            this.btnXNeg.Location = new System.Drawing.Point(361, 116);
            this.btnXNeg.Margin = new System.Windows.Forms.Padding(7);
            this.btnXNeg.Name = "btnXNeg";
            this.btnXNeg.Size = new System.Drawing.Size(165, 65);
            this.btnXNeg.TabIndex = 10;
            this.btnXNeg.Text = "↓";
            this.btnXNeg.UseVisualStyleBackColor = true;
            // 
            // btnYPos
            // 
            this.btnYPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnYPos.Image = global::ManipulatorControl.Properties.Resources.arrow_up;
            this.btnYPos.Location = new System.Drawing.Point(184, 37);
            this.btnYPos.Margin = new System.Windows.Forms.Padding(7);
            this.btnYPos.Name = "btnYPos";
            this.btnYPos.Size = new System.Drawing.Size(163, 65);
            this.btnYPos.TabIndex = 6;
            this.btnYPos.Text = "↑";
            this.btnYPos.UseVisualStyleBackColor = true;
            // 
            // btnZPos
            // 
            this.btnZPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZPos.Image = global::ManipulatorControl.Properties.Resources.arrow_right;
            this.btnZPos.Location = new System.Drawing.Point(7, 37);
            this.btnZPos.Margin = new System.Windows.Forms.Padding(7);
            this.btnZPos.Name = "btnZPos";
            this.btnZPos.Size = new System.Drawing.Size(163, 65);
            this.btnZPos.TabIndex = 3;
            this.btnZPos.Text = "→";
            this.btnZPos.UseVisualStyleBackColor = true;
            // 
            // btnZNeg
            // 
            this.btnZNeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZNeg.Image = global::ManipulatorControl.Properties.Resources.arrow_left;
            this.btnZNeg.Location = new System.Drawing.Point(7, 116);
            this.btnZNeg.Margin = new System.Windows.Forms.Padding(7);
            this.btnZNeg.Name = "btnZNeg";
            this.btnZNeg.Size = new System.Drawing.Size(163, 65);
            this.btnZNeg.TabIndex = 4;
            this.btnZNeg.Text = "←";
            this.btnZNeg.UseVisualStyleBackColor = true;
            // 
            // btnYNeg
            // 
            this.btnYNeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnYNeg.Image = ((System.Drawing.Image)(resources.GetObject("btnYNeg.Image")));
            this.btnYNeg.Location = new System.Drawing.Point(184, 116);
            this.btnYNeg.Margin = new System.Windows.Forms.Padding(7);
            this.btnYNeg.Name = "btnYNeg";
            this.btnYNeg.Size = new System.Drawing.Size(163, 65);
            this.btnYNeg.TabIndex = 7;
            this.btnYNeg.Text = "↓";
            this.btnYNeg.UseVisualStyleBackColor = true;
            // 
            // tlpManualControl
            // 
            this.tlpManualControl.ColumnCount = 3;
            this.tlpManualControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpManualControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpManualControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpManualControl.Controls.Add(this.lblHorizontalLever, 0, 0);
            this.tlpManualControl.Controls.Add(this.lblLever1, 1, 0);
            this.tlpManualControl.Controls.Add(this.lblLever2, 2, 0);
            this.tlpManualControl.Controls.Add(this.btnXPos, 2, 1);
            this.tlpManualControl.Controls.Add(this.btnYPos, 1, 1);
            this.tlpManualControl.Controls.Add(this.btnZNeg, 0, 2);
            this.tlpManualControl.Controls.Add(this.btnYNeg, 1, 2);
            this.tlpManualControl.Controls.Add(this.btnZPos, 0, 1);
            this.tlpManualControl.Controls.Add(this.btnXNeg, 2, 2);
            this.tlpManualControl.Controls.Add(this.btnZNull, 0, 3);
            this.tlpManualControl.Controls.Add(this.btnYNull, 1, 3);
            this.tlpManualControl.Controls.Add(this.btnXNull, 2, 3);
            this.tlpManualControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpManualControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tlpManualControl.Location = new System.Drawing.Point(3, 3);
            this.tlpManualControl.Name = "tlpManualControl";
            this.tlpManualControl.RowCount = 4;
            this.tlpManualControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpManualControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpManualControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpManualControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpManualControl.Size = new System.Drawing.Size(533, 267);
            this.tlpManualControl.TabIndex = 0;
            // 
            // lblHorizontalLever
            // 
            this.lblHorizontalLever.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHorizontalLever.Location = new System.Drawing.Point(3, 0);
            this.lblHorizontalLever.Name = "lblHorizontalLever";
            this.lblHorizontalLever.Size = new System.Drawing.Size(171, 30);
            this.lblHorizontalLever.TabIndex = 0;
            this.lblHorizontalLever.Text = "Каретка робота";
            this.lblHorizontalLever.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLever1
            // 
            this.lblLever1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLever1.Location = new System.Drawing.Point(180, 0);
            this.lblLever1.Name = "lblLever1";
            this.lblLever1.Size = new System.Drawing.Size(171, 30);
            this.lblLever1.TabIndex = 1;
            this.lblLever1.Text = "Плечо";
            this.lblLever1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLever2
            // 
            this.lblLever2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLever2.Location = new System.Drawing.Point(357, 0);
            this.lblLever2.Name = "lblLever2";
            this.lblLever2.Size = new System.Drawing.Size(173, 30);
            this.lblLever2.TabIndex = 2;
            this.lblLever2.Text = "Предплечье";
            this.lblLever2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZNull
            // 
            this.btnZNull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZNull.Location = new System.Drawing.Point(7, 195);
            this.btnZNull.Margin = new System.Windows.Forms.Padding(7);
            this.btnZNull.Name = "btnZNull";
            this.btnZNull.Size = new System.Drawing.Size(163, 65);
            this.btnZNull.TabIndex = 5;
            this.btnZNull.Text = "0";
            this.btnZNull.UseVisualStyleBackColor = true;
            // 
            // btnYNull
            // 
            this.btnYNull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnYNull.Location = new System.Drawing.Point(184, 195);
            this.btnYNull.Margin = new System.Windows.Forms.Padding(7);
            this.btnYNull.Name = "btnYNull";
            this.btnYNull.Size = new System.Drawing.Size(163, 65);
            this.btnYNull.TabIndex = 8;
            this.btnYNull.Text = "0";
            this.btnYNull.UseVisualStyleBackColor = true;
            // 
            // btnXNull
            // 
            this.btnXNull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnXNull.Location = new System.Drawing.Point(361, 195);
            this.btnXNull.Margin = new System.Windows.Forms.Padding(7);
            this.btnXNull.Name = "btnXNull";
            this.btnXNull.Size = new System.Drawing.Size(165, 65);
            this.btnXNull.TabIndex = 11;
            this.btnXNull.Text = "0";
            this.btnXNull.UseVisualStyleBackColor = true;
            // 
            // gbErrors
            // 
            this.gbErrors.Controls.Add(this.lstErrors);
            this.gbErrors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbErrors.Location = new System.Drawing.Point(3, 305);
            this.gbErrors.Name = "gbErrors";
            this.gbErrors.Padding = new System.Windows.Forms.Padding(1);
            this.gbErrors.Size = new System.Drawing.Size(533, 145);
            this.gbErrors.TabIndex = 0;
            this.gbErrors.TabStop = false;
            this.gbErrors.Text = "Ошибки";
            this.gbErrors.Visible = false;
            // 
            // lstErrors
            // 
            this.lstErrors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstErrors.FormattingEnabled = true;
            this.lstErrors.ItemHeight = 18;
            this.lstErrors.Location = new System.Drawing.Point(1, 18);
            this.lstErrors.Name = "lstErrors";
            this.lstErrors.Size = new System.Drawing.Size(531, 126);
            this.lstErrors.TabIndex = 0;
            this.lstErrors.DoubleClick += new System.EventHandler(this.lstErrors_DoubleClick);
            // 
            // tabControlType
            // 
            this.tabControlType.Controls.Add(this.tpManualControl);
            this.tabControlType.Controls.Add(this.tpGCodes);
            this.tabControlType.Controls.Add(this.tpWorkspaces);
            this.tabControlType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlType.ItemSize = new System.Drawing.Size(80, 30);
            this.tabControlType.Location = new System.Drawing.Point(0, 24);
            this.tabControlType.MinimumSize = new System.Drawing.Size(530, 490);
            this.tabControlType.Name = "tabControlType";
            this.tabControlType.SelectedIndex = 0;
            this.tabControlType.Size = new System.Drawing.Size(547, 491);
            this.tabControlType.TabIndex = 6;
            this.tabControlType.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlType_Selected);
            // 
            // tpManualControl
            // 
            this.tpManualControl.Controls.Add(this.gbWorkspaceInfo);
            this.tpManualControl.Controls.Add(this.tlpManualControl);
            this.tpManualControl.Location = new System.Drawing.Point(4, 34);
            this.tpManualControl.Name = "tpManualControl";
            this.tpManualControl.Padding = new System.Windows.Forms.Padding(3);
            this.tpManualControl.Size = new System.Drawing.Size(539, 453);
            this.tpManualControl.TabIndex = 0;
            this.tpManualControl.Text = "Ручное управление";
            this.tpManualControl.UseVisualStyleBackColor = true;
            // 
            // gbWorkspaceInfo
            // 
            this.gbWorkspaceInfo.Controls.Add(this.tableLayoutPanel1);
            this.gbWorkspaceInfo.Controls.Add(this.panel2);
            this.gbWorkspaceInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbWorkspaceInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbWorkspaceInfo.Location = new System.Drawing.Point(3, 276);
            this.gbWorkspaceInfo.Name = "gbWorkspaceInfo";
            this.gbWorkspaceInfo.Padding = new System.Windows.Forms.Padding(10);
            this.gbWorkspaceInfo.Size = new System.Drawing.Size(533, 174);
            this.gbWorkspaceInfo.TabIndex = 1;
            this.gbWorkspaceInfo.TabStop = false;
            this.gbWorkspaceInfo.Text = "Рабочая зона";
            this.gbWorkspaceInfo.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWorkspaceABmax, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblWorkspaceABmin, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblWorkspaceABZero, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(148, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(375, 137);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(4, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(217, 33);
            this.label12.TabIndex = 7;
            this.label12.Text = "Нулевое значение";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(4, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(217, 33);
            this.label11.TabIndex = 6;
            this.label11.Text = "Минимальное значение";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(4, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(217, 33);
            this.label10.TabIndex = 5;
            this.label10.Text = "Максимальное значение";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(228, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 33);
            this.label7.TabIndex = 2;
            this.label7.Text = "Значение";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(4, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 33);
            this.label6.TabIndex = 1;
            this.label6.Text = "Параметр";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkspaceABmax
            // 
            this.lblWorkspaceABmax.AutoSize = true;
            this.lblWorkspaceABmax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkspaceABmax.Location = new System.Drawing.Point(228, 35);
            this.lblWorkspaceABmax.Name = "lblWorkspaceABmax";
            this.lblWorkspaceABmax.Size = new System.Drawing.Size(143, 33);
            this.lblWorkspaceABmax.TabIndex = 3;
            this.lblWorkspaceABmax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkspaceABmin
            // 
            this.lblWorkspaceABmin.AutoSize = true;
            this.lblWorkspaceABmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkspaceABmin.Location = new System.Drawing.Point(228, 69);
            this.lblWorkspaceABmin.Name = "lblWorkspaceABmin";
            this.lblWorkspaceABmin.Size = new System.Drawing.Size(143, 33);
            this.lblWorkspaceABmin.TabIndex = 0;
            this.lblWorkspaceABmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkspaceABZero
            // 
            this.lblWorkspaceABZero.AutoSize = true;
            this.lblWorkspaceABZero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkspaceABZero.Location = new System.Drawing.Point(228, 103);
            this.lblWorkspaceABZero.Name = "lblWorkspaceABZero";
            this.lblWorkspaceABZero.Size = new System.Drawing.Size(143, 33);
            this.lblWorkspaceABZero.TabIndex = 4;
            this.lblWorkspaceABZero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblWorkspaceAB);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(10, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(138, 137);
            this.panel2.TabIndex = 8;
            // 
            // lblWorkspaceAB
            // 
            this.lblWorkspaceAB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkspaceAB.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWorkspaceAB.Location = new System.Drawing.Point(0, 36);
            this.lblWorkspaceAB.Name = "lblWorkspaceAB";
            this.lblWorkspaceAB.Size = new System.Drawing.Size(138, 101);
            this.lblWorkspaceAB.TabIndex = 3;
            this.lblWorkspaceAB.Text = "320";
            this.lblWorkspaceAB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 36);
            this.label13.TabIndex = 7;
            this.label13.Text = "Текущее \r\nзначение:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpGCodes
            // 
            this.tpGCodes.Controls.Add(this.gCodesBox);
            this.tpGCodes.Controls.Add(this.gbErrors);
            this.tpGCodes.Location = new System.Drawing.Point(4, 34);
            this.tpGCodes.Name = "tpGCodes";
            this.tpGCodes.Padding = new System.Windows.Forms.Padding(3);
            this.tpGCodes.Size = new System.Drawing.Size(539, 453);
            this.tpGCodes.TabIndex = 1;
            this.tpGCodes.Text = "Выполнение G-кодов";
            this.tpGCodes.UseVisualStyleBackColor = true;
            // 
            // gCodesBox
            // 
            this.gCodesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCodesBox.Enable = true;
            this.gCodesBox.EnableLineNumbering = false;
            this.gCodesBox.FontSize = ((byte)(14));
            this.gCodesBox.LineNumbersBackColor = System.Drawing.Color.White;
            this.gCodesBox.LineNumbersForeColor = System.Drawing.Color.Black;
            this.gCodesBox.Lines = new string[0];
            this.gCodesBox.Location = new System.Drawing.Point(3, 3);
            this.gCodesBox.Name = "gCodesBox";
            this.gCodesBox.ReadOnly = false;
            this.gCodesBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.gCodesBox.Size = new System.Drawing.Size(533, 302);
            this.gCodesBox.TabIndex = 1;
            this.gCodesBox.WordWrap = false;
            // 
            // tpWorkspaces
            // 
            this.tpWorkspaces.Controls.Add(this.tlpWorkspaceInfo);
            this.tpWorkspaces.Controls.Add(this.lstWorkspaces);
            this.tpWorkspaces.Location = new System.Drawing.Point(4, 34);
            this.tpWorkspaces.Name = "tpWorkspaces";
            this.tpWorkspaces.Size = new System.Drawing.Size(539, 453);
            this.tpWorkspaces.TabIndex = 2;
            this.tpWorkspaces.Text = "Рабочие зоны";
            this.tpWorkspaces.UseVisualStyleBackColor = true;
            // 
            // tlpWorkspaceInfo
            // 
            this.tlpWorkspaceInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpWorkspaceInfo.ColumnCount = 4;
            this.tlpWorkspaceInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpWorkspaceInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpWorkspaceInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpWorkspaceInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpWorkspaceInfo.Controls.Add(this.label9, 0, 4);
            this.tlpWorkspaceInfo.Controls.Add(this.label1, 0, 1);
            this.tlpWorkspaceInfo.Controls.Add(this.label2, 0, 2);
            this.tlpWorkspaceInfo.Controls.Add(this.label3, 0, 3);
            this.tlpWorkspaceInfo.Controls.Add(this.label4, 1, 0);
            this.tlpWorkspaceInfo.Controls.Add(this.label5, 2, 0);
            this.tlpWorkspaceInfo.Controls.Add(this.label8, 3, 0);
            this.tlpWorkspaceInfo.Controls.Add(this.lblHorizontalMax, 1, 1);
            this.tlpWorkspaceInfo.Controls.Add(this.lblLever1Max, 2, 1);
            this.tlpWorkspaceInfo.Controls.Add(this.lblLever2Max, 3, 1);
            this.tlpWorkspaceInfo.Controls.Add(this.lblHorizontalMin, 1, 2);
            this.tlpWorkspaceInfo.Controls.Add(this.lblLever1Min, 2, 2);
            this.tlpWorkspaceInfo.Controls.Add(this.lblLever2Min, 3, 2);
            this.tlpWorkspaceInfo.Controls.Add(this.lblHorizontalZero, 1, 3);
            this.tlpWorkspaceInfo.Controls.Add(this.lblLever1Zero, 2, 3);
            this.tlpWorkspaceInfo.Controls.Add(this.lblLever2Zero, 3, 3);
            this.tlpWorkspaceInfo.Controls.Add(this.lblHorizontalCurrent, 1, 4);
            this.tlpWorkspaceInfo.Controls.Add(this.lblLever1Current, 2, 4);
            this.tlpWorkspaceInfo.Controls.Add(this.lblLever2Current, 3, 4);
            this.tlpWorkspaceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpWorkspaceInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tlpWorkspaceInfo.Location = new System.Drawing.Point(0, 180);
            this.tlpWorkspaceInfo.Name = "tlpWorkspaceInfo";
            this.tlpWorkspaceInfo.RowCount = 5;
            this.tlpWorkspaceInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpWorkspaceInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpWorkspaceInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpWorkspaceInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpWorkspaceInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpWorkspaceInfo.Size = new System.Drawing.Size(539, 273);
            this.tlpWorkspaceInfo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Максимальное значение";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 53);
            this.label2.TabIndex = 0;
            this.label2.Text = "Минимальное значение";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 53);
            this.label3.TabIndex = 0;
            this.label3.Text = "Нулевое значение";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(138, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 53);
            this.label4.TabIndex = 0;
            this.label4.Text = "Каретка робота";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(272, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 53);
            this.label5.TabIndex = 0;
            this.label5.Text = "Плечо";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(406, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 53);
            this.label8.TabIndex = 0;
            this.label8.Text = "Предплечье";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHorizontalMax
            // 
            this.lblHorizontalMax.AutoSize = true;
            this.lblHorizontalMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHorizontalMax.Location = new System.Drawing.Point(135, 55);
            this.lblHorizontalMax.Margin = new System.Windows.Forms.Padding(0);
            this.lblHorizontalMax.Name = "lblHorizontalMax";
            this.lblHorizontalMax.Size = new System.Drawing.Size(133, 53);
            this.lblHorizontalMax.TabIndex = 1;
            this.lblHorizontalMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLever1Max
            // 
            this.lblLever1Max.AutoSize = true;
            this.lblLever1Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLever1Max.Location = new System.Drawing.Point(269, 55);
            this.lblLever1Max.Margin = new System.Windows.Forms.Padding(0);
            this.lblLever1Max.Name = "lblLever1Max";
            this.lblLever1Max.Size = new System.Drawing.Size(133, 53);
            this.lblLever1Max.TabIndex = 1;
            this.lblLever1Max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLever2Max
            // 
            this.lblLever2Max.AutoSize = true;
            this.lblLever2Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLever2Max.Location = new System.Drawing.Point(403, 55);
            this.lblLever2Max.Margin = new System.Windows.Forms.Padding(0);
            this.lblLever2Max.Name = "lblLever2Max";
            this.lblLever2Max.Size = new System.Drawing.Size(135, 53);
            this.lblLever2Max.TabIndex = 1;
            this.lblLever2Max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHorizontalMin
            // 
            this.lblHorizontalMin.AutoSize = true;
            this.lblHorizontalMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHorizontalMin.Location = new System.Drawing.Point(135, 109);
            this.lblHorizontalMin.Margin = new System.Windows.Forms.Padding(0);
            this.lblHorizontalMin.Name = "lblHorizontalMin";
            this.lblHorizontalMin.Size = new System.Drawing.Size(133, 53);
            this.lblHorizontalMin.TabIndex = 1;
            this.lblHorizontalMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLever1Min
            // 
            this.lblLever1Min.AutoSize = true;
            this.lblLever1Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLever1Min.Location = new System.Drawing.Point(269, 109);
            this.lblLever1Min.Margin = new System.Windows.Forms.Padding(0);
            this.lblLever1Min.Name = "lblLever1Min";
            this.lblLever1Min.Size = new System.Drawing.Size(133, 53);
            this.lblLever1Min.TabIndex = 1;
            this.lblLever1Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLever2Min
            // 
            this.lblLever2Min.AutoSize = true;
            this.lblLever2Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLever2Min.Location = new System.Drawing.Point(403, 109);
            this.lblLever2Min.Margin = new System.Windows.Forms.Padding(0);
            this.lblLever2Min.Name = "lblLever2Min";
            this.lblLever2Min.Size = new System.Drawing.Size(135, 53);
            this.lblLever2Min.TabIndex = 1;
            this.lblLever2Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHorizontalZero
            // 
            this.lblHorizontalZero.AutoSize = true;
            this.lblHorizontalZero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHorizontalZero.Location = new System.Drawing.Point(135, 163);
            this.lblHorizontalZero.Margin = new System.Windows.Forms.Padding(0);
            this.lblHorizontalZero.Name = "lblHorizontalZero";
            this.lblHorizontalZero.Size = new System.Drawing.Size(133, 53);
            this.lblHorizontalZero.TabIndex = 1;
            this.lblHorizontalZero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLever1Zero
            // 
            this.lblLever1Zero.AutoSize = true;
            this.lblLever1Zero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLever1Zero.Location = new System.Drawing.Point(269, 163);
            this.lblLever1Zero.Margin = new System.Windows.Forms.Padding(0);
            this.lblLever1Zero.Name = "lblLever1Zero";
            this.lblLever1Zero.Size = new System.Drawing.Size(133, 53);
            this.lblLever1Zero.TabIndex = 1;
            this.lblLever1Zero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLever2Zero
            // 
            this.lblLever2Zero.AutoSize = true;
            this.lblLever2Zero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLever2Zero.Location = new System.Drawing.Point(403, 163);
            this.lblLever2Zero.Margin = new System.Windows.Forms.Padding(0);
            this.lblLever2Zero.Name = "lblLever2Zero";
            this.lblLever2Zero.Size = new System.Drawing.Size(135, 53);
            this.lblLever2Zero.TabIndex = 1;
            this.lblLever2Zero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstWorkspaces
            // 
            this.lstWorkspaces.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstWorkspaces.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstWorkspaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstWorkspaces.FormattingEnabled = true;
            this.lstWorkspaces.ItemHeight = 20;
            this.lstWorkspaces.Location = new System.Drawing.Point(0, 0);
            this.lstWorkspaces.Name = "lstWorkspaces";
            this.lstWorkspaces.Size = new System.Drawing.Size(539, 180);
            this.lstWorkspaces.TabIndex = 0;
            this.lstWorkspaces.SelectedIndexChanged += new System.EventHandler(this.lstWorkspaces_SelectedIndexChanged);
            // 
            // rbHorizontalLever
            // 
            this.rbHorizontalLever.AutoSize = true;
            this.rbHorizontalLever.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbHorizontalLever.Location = new System.Drawing.Point(0, 0);
            this.rbHorizontalLever.Name = "rbHorizontalLever";
            this.rbHorizontalLever.Size = new System.Drawing.Size(32, 17);
            this.rbHorizontalLever.TabIndex = 7;
            this.rbHorizontalLever.TabStop = true;
            this.rbHorizontalLever.Text = this.lblHorizontalLever.Text;
            this.rbHorizontalLever.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbHorizontalLever.UseVisualStyleBackColor = true;
            this.rbHorizontalLever.CheckedChanged += new System.EventHandler(this.TableHeaderRadiobuttons_CheckedChanged);
            // 
            // rbLever1
            // 
            this.rbLever1.AutoSize = true;
            this.rbLever1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbLever1.Location = new System.Drawing.Point(0, 0);
            this.rbLever1.Name = "rbLever1";
            this.rbLever1.Size = new System.Drawing.Size(65, 17);
            this.rbLever1.TabIndex = 7;
            this.rbLever1.TabStop = true;
            this.rbLever1.Text = this.lblLever1.Text;
            this.rbLever1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbLever1.UseVisualStyleBackColor = true;
            this.rbLever1.CheckedChanged += new System.EventHandler(this.TableHeaderRadiobuttons_CheckedChanged);
            // 
            // rbLever2
            // 
            this.rbLever2.AutoSize = true;
            this.rbLever2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbLever2.Location = new System.Drawing.Point(0, 0);
            this.rbLever2.Name = "rbLever2";
            this.rbLever2.Size = new System.Drawing.Size(65, 17);
            this.rbLever2.TabIndex = 7;
            this.rbLever2.TabStop = true;
            this.rbLever2.Text = this.lblLever2.Text;
            this.rbLever2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbLever2.UseVisualStyleBackColor = true;
            this.rbLever2.CheckedChanged += new System.EventHandler(this.TableHeaderRadiobuttons_CheckedChanged);
            // 
            // rightSidePanel
            // 
            this.rightSidePanel.Controls.Add(this.panel1);
            this.rightSidePanel.Controls.Add(this.directionPanel);
            this.rightSidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightSidePanel.Location = new System.Drawing.Point(547, 24);
            this.rightSidePanel.MinimumSize = new System.Drawing.Size(380, 490);
            this.rightSidePanel.Name = "rightSidePanel";
            this.rightSidePanel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.rightSidePanel.Size = new System.Drawing.Size(382, 491);
            this.rightSidePanel.TabIndex = 7;
            // 
            // directionPanel
            // 
            this.directionPanel.ColumnCount = 4;
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.directionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.directionPanel.IsZeroEnabled = true;
            this.directionPanel.Location = new System.Drawing.Point(10, 0);
            this.directionPanel.Name = "directionPanel";
            this.directionPanel.RowCount = 4;
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.directionPanel.Size = new System.Drawing.Size(362, 198);
            this.directionPanel.TabIndex = 0;
            this.directionPanel.TabStop = true;
            this.directionPanel.X = 0D;
            this.directionPanel.Y = 0D;
            this.directionPanel.Z = 0D;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(4, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 55);
            this.label9.TabIndex = 2;
            this.label9.Text = "Текущее значение";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHorizontalCurrent
            // 
            this.lblHorizontalCurrent.AutoSize = true;
            this.lblHorizontalCurrent.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblHorizontalCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHorizontalCurrent.Location = new System.Drawing.Point(135, 217);
            this.lblHorizontalCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.lblHorizontalCurrent.Name = "lblHorizontalCurrent";
            this.lblHorizontalCurrent.Size = new System.Drawing.Size(133, 55);
            this.lblHorizontalCurrent.TabIndex = 1;
            this.lblHorizontalCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLever1Current
            // 
            this.lblLever1Current.AutoSize = true;
            this.lblLever1Current.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblLever1Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLever1Current.Location = new System.Drawing.Point(269, 217);
            this.lblLever1Current.Margin = new System.Windows.Forms.Padding(0);
            this.lblLever1Current.Name = "lblLever1Current";
            this.lblLever1Current.Size = new System.Drawing.Size(133, 55);
            this.lblLever1Current.TabIndex = 1;
            this.lblLever1Current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLever2Current
            // 
            this.lblLever2Current.AutoSize = true;
            this.lblLever2Current.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblLever2Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLever2Current.Location = new System.Drawing.Point(403, 217);
            this.lblLever2Current.Margin = new System.Windows.Forms.Padding(0);
            this.lblLever2Current.Name = "lblLever2Current";
            this.lblLever2Current.Size = new System.Drawing.Size(135, 55);
            this.lblLever2Current.TabIndex = 1;
            this.lblLever2Current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 537);
            this.Controls.Add(this.tabControlType);
            this.Controls.Add(this.rightSidePanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Робот-манипулятор УМ-160";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tlpManualControl.ResumeLayout(false);
            this.gbErrors.ResumeLayout(false);
            this.tabControlType.ResumeLayout(false);
            this.tpManualControl.ResumeLayout(false);
            this.gbWorkspaceInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tpGCodes.ResumeLayout(false);
            this.tpWorkspaces.ResumeLayout(false);
            this.tlpWorkspaceInfo.ResumeLayout(false);
            this.tlpWorkspaceInfo.PerformLayout();
            this.rightSidePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        DirectionIndicationPanel directionPanel;
        private System.Windows.Forms.Button btnXPos;
        private System.Windows.Forms.Button btnXNeg;
        private System.Windows.Forms.Button btnYPos;
        private System.Windows.Forms.Button btnZPos;
        private System.Windows.Forms.Button btnZNeg;
        private System.Windows.Forms.Button btnYNeg;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.ToolStripMenuItem controlTSMI;
        private System.Windows.Forms.ToolStripMenuItem buttonsControlMI;
        private System.Windows.Forms.ToolStripMenuItem hotKeysControlMI;
        private System.Windows.Forms.TableLayoutPanel tlpManualControl;
        private System.Windows.Forms.Label lblHorizontalLever;
        private System.Windows.Forms.Label lblLever1;
        private System.Windows.Forms.Label lblLever2;
        private System.Windows.Forms.Button btnZNull;
        private System.Windows.Forms.Button btnYNull;
        private System.Windows.Forms.Button btnXNull;
        private EditorCodeBox gCodesBox;
        private System.Windows.Forms.GroupBox gbErrors;
        private System.Windows.Forms.ListBox lstErrors;
        private System.Windows.Forms.ToolStripMenuItem interpreteGCodesMI;
        private System.Windows.Forms.ToolStripMenuItem manualControlMI;
        private System.Windows.Forms.ToolStripMenuItem gCodesControlMI;
        private System.Windows.Forms.ToolStripSeparator controlTypeSeparatorMI;
        private System.Windows.Forms.ToolStripSeparator interpreteSeparatorMI;
        private System.Windows.Forms.TabControl tabControlType;
        private System.Windows.Forms.TabPage tpManualControl;
        private System.Windows.Forms.TabPage tpGCodes;
        private System.Windows.Forms.ToolStripMenuItem settingsMI;
        private System.Windows.Forms.ToolStripMenuItem workspaceTSMI;
        private System.Windows.Forms.ToolStripMenuItem setMaxValueMI;
        private System.Windows.Forms.ToolStripMenuItem setMinValueMI;
        private System.Windows.Forms.ToolStripMenuItem setZeroValueMI;
        private System.Windows.Forms.Label lblWorkspaceAB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblWorkspaceABmax;
        private System.Windows.Forms.Label lblWorkspaceABmin;
        private System.Windows.Forms.Label lblWorkspaceABZero;
        private System.Windows.Forms.GroupBox gbWorkspaceInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbHorizontalLever;
        private System.Windows.Forms.RadioButton rbLever1;
        private System.Windows.Forms.RadioButton rbLever2;
        private System.Windows.Forms.TabPage tpWorkspaces;
        private System.Windows.Forms.TableLayoutPanel tlpWorkspaceInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblHorizontalMax;
        private System.Windows.Forms.Label lblLever1Max;
        private System.Windows.Forms.Label lblLever2Max;
        private System.Windows.Forms.Label lblHorizontalMin;
        private System.Windows.Forms.Label lblLever1Min;
        private System.Windows.Forms.Label lblLever2Min;
        private System.Windows.Forms.Label lblHorizontalZero;
        private System.Windows.Forms.Label lblLever1Zero;
        private System.Windows.Forms.Label lblLever2Zero;
        private System.Windows.Forms.ListBox lstWorkspaces;
        private System.Windows.Forms.ToolStripMenuItem renameWorkspace;
        private System.Windows.Forms.ToolStripMenuItem editWorkspaceValuesMI;
        private System.Windows.Forms.ToolStripMenuItem saveWorkspaceValuesMI;
        private System.Windows.Forms.ToolStripMenuItem addWorkspaceMI;
        private System.Windows.Forms.ToolStripMenuItem setAsActiveWorkspaceMI;
        private System.Windows.Forms.ToolStripMenuItem removeWorkspaceMI;
        private System.Windows.Forms.ToolStripSeparator editWorkspaceSeparatorMI;
        private System.Windows.Forms.ToolStripSeparator editValuesSeparatorMI;
        private System.Windows.Forms.ToolStripMenuItem closeEditWorkspaceModeMI;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLblCurrentPosition;
        private System.Windows.Forms.Panel rightSidePanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblHorizontalCurrent;
        private System.Windows.Forms.Label lblLever1Current;
        private System.Windows.Forms.Label lblLever2Current;
    }
}

