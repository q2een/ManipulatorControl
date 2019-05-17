namespace ManipulatorControl
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnZNull = new System.Windows.Forms.Button();
            this.btnYNull = new System.Windows.Forms.Button();
            this.btnXNull = new System.Windows.Forms.Button();
            this.gbErrors = new System.Windows.Forms.GroupBox();
            this.lstErrors = new System.Windows.Forms.ListBox();
            this.tabControlType = new System.Windows.Forms.TabControl();
            this.tpManualControl = new System.Windows.Forms.TabPage();
            this.tpGCodes = new System.Windows.Forms.TabPage();
            this.gCodesBox = new ManipulatorControl.EditorCodeBox();
            this.directionPanel = new ManipulatorControl.DirectionIndicationPanel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpManualControl.SuspendLayout();
            this.gbErrors.SuspendLayout();
            this.tabControlType.SuspendLayout();
            this.tpManualControl.SuspendLayout();
            this.tpGCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlTSMI,
            this.settingsMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 24);
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
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 513);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1006, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnAbort);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(600, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 95);
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
            this.btnXPos.Location = new System.Drawing.Point(387, 37);
            this.btnXPos.Margin = new System.Windows.Forms.Padding(7);
            this.btnXPos.Name = "btnXPos";
            this.btnXPos.Size = new System.Drawing.Size(178, 76);
            this.btnXPos.TabIndex = 9;
            this.btnXPos.Text = "+";
            this.btnXPos.UseVisualStyleBackColor = true;
            // 
            // btnXNeg
            // 
            this.btnXNeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnXNeg.Location = new System.Drawing.Point(387, 127);
            this.btnXNeg.Margin = new System.Windows.Forms.Padding(7);
            this.btnXNeg.Name = "btnXNeg";
            this.btnXNeg.Size = new System.Drawing.Size(178, 76);
            this.btnXNeg.TabIndex = 10;
            this.btnXNeg.Text = "-";
            this.btnXNeg.UseVisualStyleBackColor = true;
            // 
            // btnYPos
            // 
            this.btnYPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnYPos.Location = new System.Drawing.Point(197, 37);
            this.btnYPos.Margin = new System.Windows.Forms.Padding(7);
            this.btnYPos.Name = "btnYPos";
            this.btnYPos.Size = new System.Drawing.Size(176, 76);
            this.btnYPos.TabIndex = 6;
            this.btnYPos.Text = "+";
            this.btnYPos.UseVisualStyleBackColor = true;
            // 
            // btnZPos
            // 
            this.btnZPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZPos.Location = new System.Drawing.Point(7, 37);
            this.btnZPos.Margin = new System.Windows.Forms.Padding(7);
            this.btnZPos.Name = "btnZPos";
            this.btnZPos.Size = new System.Drawing.Size(176, 76);
            this.btnZPos.TabIndex = 3;
            this.btnZPos.Text = "+";
            this.btnZPos.UseVisualStyleBackColor = true;
            // 
            // btnZNeg
            // 
            this.btnZNeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZNeg.Location = new System.Drawing.Point(7, 127);
            this.btnZNeg.Margin = new System.Windows.Forms.Padding(7);
            this.btnZNeg.Name = "btnZNeg";
            this.btnZNeg.Size = new System.Drawing.Size(176, 76);
            this.btnZNeg.TabIndex = 4;
            this.btnZNeg.Text = "-";
            this.btnZNeg.UseVisualStyleBackColor = true;
            // 
            // btnYNeg
            // 
            this.btnYNeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnYNeg.Location = new System.Drawing.Point(197, 127);
            this.btnYNeg.Margin = new System.Windows.Forms.Padding(7);
            this.btnYNeg.Name = "btnYNeg";
            this.btnYNeg.Size = new System.Drawing.Size(176, 76);
            this.btnYNeg.TabIndex = 7;
            this.btnYNeg.Text = "-";
            this.btnYNeg.UseVisualStyleBackColor = true;
            // 
            // tlpManualControl
            // 
            this.tlpManualControl.ColumnCount = 3;
            this.tlpManualControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpManualControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpManualControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpManualControl.Controls.Add(this.label1, 0, 0);
            this.tlpManualControl.Controls.Add(this.label2, 1, 0);
            this.tlpManualControl.Controls.Add(this.label3, 2, 0);
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
            this.tlpManualControl.Size = new System.Drawing.Size(572, 300);
            this.tlpManualControl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Z";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(193, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Плечо 1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(383, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Плечо 2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZNull
            // 
            this.btnZNull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZNull.Location = new System.Drawing.Point(7, 217);
            this.btnZNull.Margin = new System.Windows.Forms.Padding(7);
            this.btnZNull.Name = "btnZNull";
            this.btnZNull.Size = new System.Drawing.Size(176, 76);
            this.btnZNull.TabIndex = 5;
            this.btnZNull.Text = "0";
            this.btnZNull.UseVisualStyleBackColor = true;
            // 
            // btnYNull
            // 
            this.btnYNull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnYNull.Location = new System.Drawing.Point(197, 217);
            this.btnYNull.Margin = new System.Windows.Forms.Padding(7);
            this.btnYNull.Name = "btnYNull";
            this.btnYNull.Size = new System.Drawing.Size(176, 76);
            this.btnYNull.TabIndex = 8;
            this.btnYNull.Text = "0";
            this.btnYNull.UseVisualStyleBackColor = true;
            // 
            // btnXNull
            // 
            this.btnXNull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnXNull.Location = new System.Drawing.Point(387, 217);
            this.btnXNull.Margin = new System.Windows.Forms.Padding(7);
            this.btnXNull.Name = "btnXNull";
            this.btnXNull.Size = new System.Drawing.Size(178, 76);
            this.btnXNull.TabIndex = 11;
            this.btnXNull.Text = "0";
            this.btnXNull.UseVisualStyleBackColor = true;
            // 
            // gbErrors
            // 
            this.gbErrors.Controls.Add(this.lstErrors);
            this.gbErrors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbErrors.Location = new System.Drawing.Point(3, 303);
            this.gbErrors.Name = "gbErrors";
            this.gbErrors.Padding = new System.Windows.Forms.Padding(1);
            this.gbErrors.Size = new System.Drawing.Size(572, 145);
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
            this.lstErrors.Size = new System.Drawing.Size(570, 126);
            this.lstErrors.TabIndex = 0;
            this.lstErrors.DoubleClick += new System.EventHandler(this.lstErrors_DoubleClick);
            // 
            // tabControlType
            // 
            this.tabControlType.Controls.Add(this.tpManualControl);
            this.tabControlType.Controls.Add(this.tpGCodes);
            this.tabControlType.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControlType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlType.ItemSize = new System.Drawing.Size(80, 30);
            this.tabControlType.Location = new System.Drawing.Point(0, 24);
            this.tabControlType.Name = "tabControlType";
            this.tabControlType.SelectedIndex = 0;
            this.tabControlType.Size = new System.Drawing.Size(586, 489);
            this.tabControlType.TabIndex = 6;
            this.tabControlType.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlType_Selected);
            // 
            // tpManualControl
            // 
            this.tpManualControl.Controls.Add(this.tlpManualControl);
            this.tpManualControl.Location = new System.Drawing.Point(4, 34);
            this.tpManualControl.Name = "tpManualControl";
            this.tpManualControl.Padding = new System.Windows.Forms.Padding(3);
            this.tpManualControl.Size = new System.Drawing.Size(578, 451);
            this.tpManualControl.TabIndex = 0;
            this.tpManualControl.Text = "Ручное управление";
            this.tpManualControl.UseVisualStyleBackColor = true;
            // 
            // tpGCodes
            // 
            this.tpGCodes.Controls.Add(this.gCodesBox);
            this.tpGCodes.Controls.Add(this.gbErrors);
            this.tpGCodes.Location = new System.Drawing.Point(4, 34);
            this.tpGCodes.Name = "tpGCodes";
            this.tpGCodes.Padding = new System.Windows.Forms.Padding(3);
            this.tpGCodes.Size = new System.Drawing.Size(578, 451);
            this.tpGCodes.TabIndex = 1;
            this.tpGCodes.Text = "Выполнение G-кодов";
            this.tpGCodes.UseVisualStyleBackColor = true;
            // 
            // gCodesBox
            // 
            this.gCodesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCodesBox.Enable = true;
            this.gCodesBox.FontSize = ((byte)(14));
            this.gCodesBox.LineNumbersBackColor = System.Drawing.Color.White;
            this.gCodesBox.LineNumbersForeColor = System.Drawing.Color.Black;
            this.gCodesBox.Lines = new string[0];
            this.gCodesBox.Location = new System.Drawing.Point(3, 3);
            this.gCodesBox.Name = "gCodesBox";
            this.gCodesBox.ReadOnly = false;
            this.gCodesBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.gCodesBox.Size = new System.Drawing.Size(572, 300);
            this.gCodesBox.TabIndex = 1;
            this.gCodesBox.WordWrap = false;
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
            this.directionPanel.IsZeroEnabled = false;
            this.directionPanel.Location = new System.Drawing.Point(600, 58);
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
            this.directionPanel.Size = new System.Drawing.Size(357, 176);
            this.directionPanel.TabIndex = 0;
            this.directionPanel.TabStop = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 535);
            this.Controls.Add(this.tabControlType);
            this.Controls.Add(this.directionPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Робот-манипулятор УМ-160";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tlpManualControl.ResumeLayout(false);
            this.gbErrors.ResumeLayout(false);
            this.tabControlType.ResumeLayout(false);
            this.tpManualControl.ResumeLayout(false);
            this.tpGCodes.ResumeLayout(false);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
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
    }
}

