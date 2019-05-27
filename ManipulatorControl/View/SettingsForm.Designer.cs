namespace ManipulatorControl
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.pagePinSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbCEnable = new System.Windows.Forms.ComboBox();
            this.lblCEnable = new System.Windows.Forms.Label();
            this.cmbCDir = new System.Windows.Forms.ComboBox();
            this.lblCDir = new System.Windows.Forms.Label();
            this.cmbCStep = new System.Windows.Forms.ComboBox();
            this.lblCStep = new System.Windows.Forms.Label();
            this.cmbZEnable = new System.Windows.Forms.ComboBox();
            this.lblZEnable = new System.Windows.Forms.Label();
            this.cmbZDir = new System.Windows.Forms.ComboBox();
            this.lblZDir = new System.Windows.Forms.Label();
            this.cmbZStep = new System.Windows.Forms.ComboBox();
            this.lblZStep = new System.Windows.Forms.Label();
            this.cmbYEnable = new System.Windows.Forms.ComboBox();
            this.lblYEnable = new System.Windows.Forms.Label();
            this.cmbYDir = new System.Windows.Forms.ComboBox();
            this.lblYDir = new System.Windows.Forms.Label();
            this.cmbYStep = new System.Windows.Forms.ComboBox();
            this.lblYStep = new System.Windows.Forms.Label();
            this.cmbXEnable = new System.Windows.Forms.ComboBox();
            this.lblXEnable = new System.Windows.Forms.Label();
            this.cmbXDir = new System.Windows.Forms.ComboBox();
            this.lblXDir = new System.Windows.Forms.Label();
            this.cmbXStep = new System.Windows.Forms.ComboBox();
            this.lblXStep = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pageStepperSettings = new System.Windows.Forms.TabPage();
            this.stepperSettingsPanel3 = new ManipulatorControl.Controls.StepperSettingsPanel();
            this.stepperSettingsPanel2 = new ManipulatorControl.Controls.StepperSettingsPanel();
            this.stepperSettingsPanel1 = new ManipulatorControl.Controls.StepperSettingsPanel();
            this.pageDesignParameters = new System.Windows.Forms.TabPage();
            this.designParametersTabs = new ManipulatorControl.DesignParametersTabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabSettings.SuspendLayout();
            this.pagePinSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pageStepperSettings.SuspendLayout();
            this.pageDesignParameters.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.pagePinSettings);
            this.tabSettings.Controls.Add(this.pageStepperSettings);
            this.tabSettings.Controls.Add(this.pageDesignParameters);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabSettings.ItemSize = new System.Drawing.Size(81, 30);
            this.tabSettings.Location = new System.Drawing.Point(0, 0);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(0);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(761, 538);
            this.tabSettings.TabIndex = 0;
            // 
            // pagePinSettings
            // 
            this.pagePinSettings.Controls.Add(this.tableLayoutPanel1);
            this.pagePinSettings.Location = new System.Drawing.Point(4, 34);
            this.pagePinSettings.Name = "pagePinSettings";
            this.pagePinSettings.Padding = new System.Windows.Forms.Padding(3);
            this.pagePinSettings.Size = new System.Drawing.Size(753, 500);
            this.pagePinSettings.TabIndex = 0;
            this.pagePinSettings.Text = "Назначения PIN ";
            this.pagePinSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.cmbCEnable, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.cmbCDir, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.cmbCStep, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.cmbZEnable, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.cmbZDir, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.cmbZStep, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.cmbYEnable, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmbYDir, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmbYStep, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbXEnable, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbXDir, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbXStep, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label13, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblXStep, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblXDir, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblXEnable, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblYStep, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblYDir, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblYEnable, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblZStep, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblZDir, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblZEnable, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblCStep, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblCDir, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.lblCEnable, 2, 12);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(747, 494);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmbCEnable
            // 
            this.cmbCEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCEnable.FormattingEnabled = true;
            this.cmbCEnable.Location = new System.Drawing.Point(252, 447);
            this.cmbCEnable.Name = "cmbCEnable";
            this.cmbCEnable.Size = new System.Drawing.Size(243, 24);
            this.cmbCEnable.TabIndex = 1;
            this.cmbCEnable.Tag = this.lblCEnable;
            this.cmbCEnable.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblCEnable
            // 
            this.lblCEnable.AutoSize = true;
            this.lblCEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCEnable.Location = new System.Drawing.Point(501, 444);
            this.lblCEnable.Name = "lblCEnable";
            this.lblCEnable.Size = new System.Drawing.Size(243, 50);
            this.lblCEnable.TabIndex = 3;
            this.lblCEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCDir
            // 
            this.cmbCDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCDir.FormattingEnabled = true;
            this.cmbCDir.Location = new System.Drawing.Point(252, 410);
            this.cmbCDir.Name = "cmbCDir";
            this.cmbCDir.Size = new System.Drawing.Size(243, 24);
            this.cmbCDir.TabIndex = 1;
            this.cmbCDir.Tag = this.lblCDir;
            this.cmbCDir.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblCDir
            // 
            this.lblCDir.AutoSize = true;
            this.lblCDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCDir.Location = new System.Drawing.Point(501, 407);
            this.lblCDir.Name = "lblCDir";
            this.lblCDir.Size = new System.Drawing.Size(243, 37);
            this.lblCDir.TabIndex = 3;
            this.lblCDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCStep
            // 
            this.cmbCStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCStep.FormattingEnabled = true;
            this.cmbCStep.Location = new System.Drawing.Point(252, 373);
            this.cmbCStep.Name = "cmbCStep";
            this.cmbCStep.Size = new System.Drawing.Size(243, 24);
            this.cmbCStep.TabIndex = 1;
            this.cmbCStep.Tag = this.lblCStep;
            this.cmbCStep.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblCStep
            // 
            this.lblCStep.AutoSize = true;
            this.lblCStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCStep.Location = new System.Drawing.Point(501, 370);
            this.lblCStep.Name = "lblCStep";
            this.lblCStep.Size = new System.Drawing.Size(243, 37);
            this.lblCStep.TabIndex = 3;
            this.lblCStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbZEnable
            // 
            this.cmbZEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbZEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZEnable.FormattingEnabled = true;
            this.cmbZEnable.Location = new System.Drawing.Point(252, 336);
            this.cmbZEnable.Name = "cmbZEnable";
            this.cmbZEnable.Size = new System.Drawing.Size(243, 24);
            this.cmbZEnable.TabIndex = 1;
            this.cmbZEnable.Tag = this.lblZEnable;
            this.cmbZEnable.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblZEnable
            // 
            this.lblZEnable.AutoSize = true;
            this.lblZEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZEnable.Location = new System.Drawing.Point(501, 333);
            this.lblZEnable.Name = "lblZEnable";
            this.lblZEnable.Size = new System.Drawing.Size(243, 37);
            this.lblZEnable.TabIndex = 3;
            this.lblZEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbZDir
            // 
            this.cmbZDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbZDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZDir.FormattingEnabled = true;
            this.cmbZDir.Location = new System.Drawing.Point(252, 299);
            this.cmbZDir.Name = "cmbZDir";
            this.cmbZDir.Size = new System.Drawing.Size(243, 24);
            this.cmbZDir.TabIndex = 1;
            this.cmbZDir.Tag = this.lblZDir;
            this.cmbZDir.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblZDir
            // 
            this.lblZDir.AutoSize = true;
            this.lblZDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZDir.Location = new System.Drawing.Point(501, 296);
            this.lblZDir.Name = "lblZDir";
            this.lblZDir.Size = new System.Drawing.Size(243, 37);
            this.lblZDir.TabIndex = 3;
            this.lblZDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbZStep
            // 
            this.cmbZStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbZStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZStep.FormattingEnabled = true;
            this.cmbZStep.Location = new System.Drawing.Point(252, 262);
            this.cmbZStep.Name = "cmbZStep";
            this.cmbZStep.Size = new System.Drawing.Size(243, 24);
            this.cmbZStep.TabIndex = 1;
            this.cmbZStep.Tag = this.lblZStep;
            this.cmbZStep.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblZStep
            // 
            this.lblZStep.AutoSize = true;
            this.lblZStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZStep.Location = new System.Drawing.Point(501, 259);
            this.lblZStep.Name = "lblZStep";
            this.lblZStep.Size = new System.Drawing.Size(243, 37);
            this.lblZStep.TabIndex = 3;
            this.lblZStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbYEnable
            // 
            this.cmbYEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbYEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYEnable.FormattingEnabled = true;
            this.cmbYEnable.Location = new System.Drawing.Point(252, 225);
            this.cmbYEnable.Name = "cmbYEnable";
            this.cmbYEnable.Size = new System.Drawing.Size(243, 24);
            this.cmbYEnable.TabIndex = 1;
            this.cmbYEnable.Tag = this.lblYEnable;
            this.cmbYEnable.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblYEnable
            // 
            this.lblYEnable.AutoSize = true;
            this.lblYEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYEnable.Location = new System.Drawing.Point(501, 222);
            this.lblYEnable.Name = "lblYEnable";
            this.lblYEnable.Size = new System.Drawing.Size(243, 37);
            this.lblYEnable.TabIndex = 3;
            this.lblYEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbYDir
            // 
            this.cmbYDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbYDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYDir.FormattingEnabled = true;
            this.cmbYDir.Location = new System.Drawing.Point(252, 188);
            this.cmbYDir.Name = "cmbYDir";
            this.cmbYDir.Size = new System.Drawing.Size(243, 24);
            this.cmbYDir.TabIndex = 1;
            this.cmbYDir.Tag = this.lblYDir;
            this.cmbYDir.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblYDir
            // 
            this.lblYDir.AutoSize = true;
            this.lblYDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYDir.Location = new System.Drawing.Point(501, 185);
            this.lblYDir.Name = "lblYDir";
            this.lblYDir.Size = new System.Drawing.Size(243, 37);
            this.lblYDir.TabIndex = 3;
            this.lblYDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbYStep
            // 
            this.cmbYStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbYStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYStep.FormattingEnabled = true;
            this.cmbYStep.Location = new System.Drawing.Point(252, 151);
            this.cmbYStep.Name = "cmbYStep";
            this.cmbYStep.Size = new System.Drawing.Size(243, 24);
            this.cmbYStep.TabIndex = 1;
            this.cmbYStep.Tag = this.lblYStep;
            this.cmbYStep.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblYStep
            // 
            this.lblYStep.AutoSize = true;
            this.lblYStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYStep.Location = new System.Drawing.Point(501, 148);
            this.lblYStep.Name = "lblYStep";
            this.lblYStep.Size = new System.Drawing.Size(243, 37);
            this.lblYStep.TabIndex = 3;
            this.lblYStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbXEnable
            // 
            this.cmbXEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbXEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXEnable.FormattingEnabled = true;
            this.cmbXEnable.Location = new System.Drawing.Point(252, 114);
            this.cmbXEnable.Name = "cmbXEnable";
            this.cmbXEnable.Size = new System.Drawing.Size(243, 24);
            this.cmbXEnable.TabIndex = 1;
            this.cmbXEnable.Tag = this.lblXEnable;
            this.cmbXEnable.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblXEnable
            // 
            this.lblXEnable.AutoSize = true;
            this.lblXEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblXEnable.Location = new System.Drawing.Point(501, 111);
            this.lblXEnable.Name = "lblXEnable";
            this.lblXEnable.Size = new System.Drawing.Size(243, 37);
            this.lblXEnable.TabIndex = 3;
            this.lblXEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbXDir
            // 
            this.cmbXDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbXDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXDir.FormattingEnabled = true;
            this.cmbXDir.Location = new System.Drawing.Point(252, 77);
            this.cmbXDir.Name = "cmbXDir";
            this.cmbXDir.Size = new System.Drawing.Size(243, 24);
            this.cmbXDir.TabIndex = 1;
            this.cmbXDir.Tag = this.lblXDir;
            this.cmbXDir.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblXDir
            // 
            this.lblXDir.AutoSize = true;
            this.lblXDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblXDir.Location = new System.Drawing.Point(501, 74);
            this.lblXDir.Name = "lblXDir";
            this.lblXDir.Size = new System.Drawing.Size(243, 37);
            this.lblXDir.TabIndex = 3;
            this.lblXDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbXStep
            // 
            this.cmbXStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbXStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXStep.FormattingEnabled = true;
            this.cmbXStep.Location = new System.Drawing.Point(252, 40);
            this.cmbXStep.Name = "cmbXStep";
            this.cmbXStep.Size = new System.Drawing.Size(243, 24);
            this.cmbXStep.TabIndex = 1;
            this.cmbXStep.Tag = this.lblXStep;
            this.cmbXStep.SelectedIndexChanged += new System.EventHandler(this.StepDirCmb_SelectedIndexChanged);
            // 
            // lblXStep
            // 
            this.lblXStep.AutoSize = true;
            this.lblXStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblXStep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblXStep.Location = new System.Drawing.Point(501, 37);
            this.lblXStep.Name = "lblXStep";
            this.lblXStep.Size = new System.Drawing.Size(243, 37);
            this.lblXStep.TabIndex = 3;
            this.lblXStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 444);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "C ENABLE";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 407);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "C DIR";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 370);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "C STEP";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Z ENABLE";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Z DIR";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Z STEP";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Y ENABLE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Y DIR";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Y STEP";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "X ENABLE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "X DIR";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "X STEP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Menu;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(252, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(243, 37);
            this.label13.TabIndex = 2;
            this.label13.Text = "Номер PIN";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Menu;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(243, 37);
            this.label14.TabIndex = 2;
            this.label14.Text = "Параметр";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Menu;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(501, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(243, 37);
            this.label15.TabIndex = 2;
            this.label15.Text = "Текущее значение";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageStepperSettings
            // 
            this.pageStepperSettings.Controls.Add(this.stepperSettingsPanel3);
            this.pageStepperSettings.Controls.Add(this.stepperSettingsPanel2);
            this.pageStepperSettings.Controls.Add(this.stepperSettingsPanel1);
            this.pageStepperSettings.Location = new System.Drawing.Point(4, 34);
            this.pageStepperSettings.Name = "pageStepperSettings";
            this.pageStepperSettings.Padding = new System.Windows.Forms.Padding(3);
            this.pageStepperSettings.Size = new System.Drawing.Size(753, 500);
            this.pageStepperSettings.TabIndex = 1;
            this.pageStepperSettings.Text = "Шаговые двигатели";
            this.pageStepperSettings.UseVisualStyleBackColor = true;
            // 
            // stepperSettingsPanel3
            // 
            this.stepperSettingsPanel3.Acceleration = 0F;
            this.stepperSettingsPanel3.AccelerationInMS = 0;
            this.stepperSettingsPanel3.CWDirectionIsLogicalZero = true;
            this.stepperSettingsPanel3.LeverType = ManipulatorControl.LeverType.Lever1;
            this.stepperSettingsPanel3.Location = new System.Drawing.Point(9, 253);
            this.stepperSettingsPanel3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.stepperSettingsPanel3.Name = "stepperSettingsPanel3";
            this.stepperSettingsPanel3.Size = new System.Drawing.Size(363, 242);
            this.stepperSettingsPanel3.Speed = 0F;
            this.stepperSettingsPanel3.Stepper = null;
            this.stepperSettingsPanel3.TabIndex = 0;
            // 
            // stepperSettingsPanel2
            // 
            this.stepperSettingsPanel2.Acceleration = 0F;
            this.stepperSettingsPanel2.AccelerationInMS = 0;
            this.stepperSettingsPanel2.CWDirectionIsLogicalZero = true;
            this.stepperSettingsPanel2.LeverType = ManipulatorControl.LeverType.Lever1;
            this.stepperSettingsPanel2.Location = new System.Drawing.Point(389, 4);
            this.stepperSettingsPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.stepperSettingsPanel2.Name = "stepperSettingsPanel2";
            this.stepperSettingsPanel2.Size = new System.Drawing.Size(354, 244);
            this.stepperSettingsPanel2.Speed = 0F;
            this.stepperSettingsPanel2.Stepper = null;
            this.stepperSettingsPanel2.TabIndex = 0;
            // 
            // stepperSettingsPanel1
            // 
            this.stepperSettingsPanel1.Acceleration = 0F;
            this.stepperSettingsPanel1.AccelerationInMS = 0;
            this.stepperSettingsPanel1.CWDirectionIsLogicalZero = true;
            this.stepperSettingsPanel1.LeverType = ManipulatorControl.LeverType.Lever1;
            this.stepperSettingsPanel1.Location = new System.Drawing.Point(9, 4);
            this.stepperSettingsPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.stepperSettingsPanel1.Name = "stepperSettingsPanel1";
            this.stepperSettingsPanel1.Size = new System.Drawing.Size(363, 243);
            this.stepperSettingsPanel1.Speed = 0F;
            this.stepperSettingsPanel1.Stepper = null;
            this.stepperSettingsPanel1.TabIndex = 0;
            // 
            // pageDesignParameters
            // 
            this.pageDesignParameters.Controls.Add(this.designParametersTabs);
            this.pageDesignParameters.Location = new System.Drawing.Point(4, 34);
            this.pageDesignParameters.Name = "pageDesignParameters";
            this.pageDesignParameters.Padding = new System.Windows.Forms.Padding(3);
            this.pageDesignParameters.Size = new System.Drawing.Size(753, 500);
            this.pageDesignParameters.TabIndex = 2;
            this.pageDesignParameters.Text = "Конструктивные параметры";
            this.pageDesignParameters.UseVisualStyleBackColor = true;
            // 
            // designParametersTabs
            // 
            this.designParametersTabs.AB = 0;
            this.designParametersTabs.ABmax = 0;
            this.designParametersTabs.ABmin = 0;
            this.designParametersTabs.ABZero = null;
            this.designParametersTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designParametersTabs.IsABIncreasesOnStepperCW = false;
            this.designParametersTabs.L1 = 0;
            this.designParametersTabs.L2 = 0;
            this.designParametersTabs.Lc = 0;
            this.designParametersTabs.Location = new System.Drawing.Point(3, 3);
            this.designParametersTabs.Margin = new System.Windows.Forms.Padding(4);
            this.designParametersTabs.Name = "designParametersTabs";
            this.designParametersTabs.Ro = 0D;
            this.designParametersTabs.Size = new System.Drawing.Size(747, 494);
            this.designParametersTabs.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 538);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 55);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 30);
            this.button2.TabIndex = 0;
            this.button2.Text = "По умолчанию";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(561, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(666, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 30);
            this.button3.TabIndex = 0;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 593);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsForm";
            this.Text = "Параметры";
            this.tabSettings.ResumeLayout(false);
            this.pagePinSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pageStepperSettings.ResumeLayout(false);
            this.pageDesignParameters.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage pagePinSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbCEnable;
        private System.Windows.Forms.Label lblCEnable;
        private System.Windows.Forms.ComboBox cmbCDir;
        private System.Windows.Forms.Label lblCDir;
        private System.Windows.Forms.ComboBox cmbCStep;
        private System.Windows.Forms.Label lblCStep;
        private System.Windows.Forms.ComboBox cmbZEnable;
        private System.Windows.Forms.Label lblZEnable;
        private System.Windows.Forms.ComboBox cmbZDir;
        private System.Windows.Forms.Label lblZDir;
        private System.Windows.Forms.ComboBox cmbZStep;
        private System.Windows.Forms.Label lblZStep;
        private System.Windows.Forms.ComboBox cmbYEnable;
        private System.Windows.Forms.Label lblYEnable;
        private System.Windows.Forms.ComboBox cmbYDir;
        private System.Windows.Forms.Label lblYDir;
        private System.Windows.Forms.ComboBox cmbYStep;
        private System.Windows.Forms.Label lblYStep;
        private System.Windows.Forms.ComboBox cmbXEnable;
        private System.Windows.Forms.Label lblXEnable;
        private System.Windows.Forms.ComboBox cmbXDir;
        private System.Windows.Forms.Label lblXDir;
        private System.Windows.Forms.ComboBox cmbXStep;
        private System.Windows.Forms.Label lblXStep;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage pageStepperSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Controls.StepperSettingsPanel stepperSettingsPanel3;
        private Controls.StepperSettingsPanel stepperSettingsPanel2;
        private Controls.StepperSettingsPanel stepperSettingsPanel1;
        private System.Windows.Forms.TabPage pageDesignParameters;
        private DesignParametersTabControl designParametersTabs;
        private System.Windows.Forms.Button button3;
    }
}