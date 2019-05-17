namespace ManipulatorControl.Controls
{
    partial class StepperSettingsPanel
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.cmbLptPins = new System.Windows.Forms.ComboBox();
            this.cmbLeverType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSecAccel = new System.Windows.Forms.TextBox();
            this.tbAccel = new System.Windows.Forms.TextBox();
            this.tbSpeed = new System.Windows.Forms.TextBox();
            this.cbIsLog0 = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.cmbLptPins);
            this.gbMain.Controls.Add(this.cmbLeverType);
            this.gbMain.Controls.Add(this.label7);
            this.gbMain.Controls.Add(this.label5);
            this.gbMain.Controls.Add(this.label4);
            this.gbMain.Controls.Add(this.label8);
            this.gbMain.Controls.Add(this.label2);
            this.gbMain.Controls.Add(this.label6);
            this.gbMain.Controls.Add(this.label3);
            this.gbMain.Controls.Add(this.label1);
            this.gbMain.Controls.Add(this.tbSecAccel);
            this.gbMain.Controls.Add(this.tbAccel);
            this.gbMain.Controls.Add(this.tbSpeed);
            this.gbMain.Controls.Add(this.cbIsLog0);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbMain.Location = new System.Drawing.Point(0, 0);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(299, 207);
            this.gbMain.TabIndex = 0;
            this.gbMain.TabStop = false;
            // 
            // cmbLptPins
            // 
            this.cmbLptPins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLptPins.FormattingEnabled = true;
            this.cmbLptPins.Location = new System.Drawing.Point(96, 48);
            this.cmbLptPins.Name = "cmbLptPins";
            this.cmbLptPins.Size = new System.Drawing.Size(164, 24);
            this.cmbLptPins.TabIndex = 1;
            // 
            // cmbLeverType
            // 
            this.cmbLeverType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeverType.FormattingEnabled = true;
            this.cmbLeverType.Location = new System.Drawing.Point(96, 15);
            this.cmbLeverType.Name = "cmbLeverType";
            this.cmbLeverType.Size = new System.Drawing.Size(164, 24);
            this.cmbLeverType.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "мс";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "шаг/с*c";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "шаг/с";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(43, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "в мс";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Ускорение:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "LPT Pins:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Плечо:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Скорость:";
            // 
            // tbSecAccel
            // 
            this.tbSecAccel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSecAccel.Location = new System.Drawing.Point(98, 170);
            this.tbSecAccel.MaxLength = 4;
            this.tbSecAccel.Name = "tbSecAccel";
            this.tbSecAccel.Size = new System.Drawing.Size(100, 22);
            this.tbSecAccel.TabIndex = 5;
            this.tbSecAccel.TextChanged += new System.EventHandler(this.tbSecAccel_TextChanged);
            this.tbSecAccel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSecAccel_KeyPress);
            // 
            // tbAccel
            // 
            this.tbAccel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorProvider.SetIconPadding(this.tbAccel, -10);
            this.tbAccel.Location = new System.Drawing.Point(98, 142);
            this.tbAccel.MaxLength = 7;
            this.tbAccel.Name = "tbAccel";
            this.tbAccel.Size = new System.Drawing.Size(100, 22);
            this.tbAccel.TabIndex = 4;
            this.tbAccel.TextChanged += new System.EventHandler(this.tbAccel_TextChanged);
            this.tbAccel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyValidating_KeyPress);
            this.tbAccel.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorProvider.SetIconPadding(this.tbSpeed, -10);
            this.tbSpeed.Location = new System.Drawing.Point(98, 114);
            this.tbSpeed.MaxLength = 6;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(100, 22);
            this.tbSpeed.TabIndex = 3;
            this.tbSpeed.TextChanged += new System.EventHandler(this.tbSpeed_TextChanged);
            this.tbSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyValidating_KeyPress);
            this.tbSpeed.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating);
            // 
            // cbIsLog0
            // 
            this.cbIsLog0.AutoSize = true;
            this.cbIsLog0.Checked = true;
            this.cbIsLog0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsLog0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbIsLog0.Location = new System.Drawing.Point(9, 84);
            this.cbIsLog0.Name = "cbIsLog0";
            this.cbIsLog0.Size = new System.Drawing.Size(286, 20);
            this.cbIsLog0.TabIndex = 2;
            this.cbIsLog0.Text = "Лог.0 для движения по часовой стрелке";
            this.cbIsLog0.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // StepperSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMain);
            this.Name = "StepperSettingsPanel";
            this.Size = new System.Drawing.Size(299, 207);
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSecAccel;
        private System.Windows.Forms.TextBox tbAccel;
        private System.Windows.Forms.TextBox tbSpeed;
        private System.Windows.Forms.CheckBox cbIsLog0;
        private System.Windows.Forms.ComboBox cmbLptPins;
        private System.Windows.Forms.ComboBox cmbLeverType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
