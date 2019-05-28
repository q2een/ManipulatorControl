namespace ManipulatorControl
{
    partial class DirectionIndicationPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.xPositiveIndicator = new ManipulatorControl.Indicator();
            this.yPositiveIndicator = new ManipulatorControl.Indicator();
            this.zPositiveIndicator = new ManipulatorControl.Indicator();
            this.xNegativeIndicator = new ManipulatorControl.Indicator();
            this.yNegativeIndicator = new ManipulatorControl.Indicator();
            this.zNegativeIndicator = new ManipulatorControl.Indicator();
            this.xZeroIndicator = new ManipulatorControl.Indicator();
            this.yZeroIndicator = new ManipulatorControl.Indicator();
            this.zZeroIndicator = new ManipulatorControl.Indicator();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(40, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(169, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 40);
            this.label2.TabIndex = 0;
            this.label2.Text = "Y";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(298, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 40);
            this.label3.TabIndex = 0;
            this.label3.Text = "Z";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(0, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 100);
            this.label4.TabIndex = 0;
            this.label4.Text = "+";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(0, 140);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 100);
            this.label5.TabIndex = 0;
            this.label5.Text = "—";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(0, 240);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 101);
            this.label6.TabIndex = 0;
            this.label6.Text = "0";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xPositiveIndicator
            // 
            this.xPositiveIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPositiveIndicator.DisabledColor = System.Drawing.Color.DarkGray;
            this.xPositiveIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPositiveIndicator.IndicatorColor = System.Drawing.Color.Tomato;
            this.xPositiveIndicator.Location = new System.Drawing.Point(40, 40);
            this.xPositiveIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.xPositiveIndicator.Name = "xPositiveIndicator";
            this.xPositiveIndicator.Size = new System.Drawing.Size(129, 100);
            this.xPositiveIndicator.TabIndex = 1;
            // 
            // yPositiveIndicator
            // 
            this.yPositiveIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yPositiveIndicator.DisabledColor = System.Drawing.Color.DarkGray;
            this.yPositiveIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yPositiveIndicator.IndicatorColor = System.Drawing.Color.Tomato;
            this.yPositiveIndicator.Location = new System.Drawing.Point(169, 40);
            this.yPositiveIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.yPositiveIndicator.Name = "yPositiveIndicator";
            this.yPositiveIndicator.Size = new System.Drawing.Size(129, 100);
            this.yPositiveIndicator.TabIndex = 2;
            // 
            // zPositiveIndicator
            // 
            this.zPositiveIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zPositiveIndicator.DisabledColor = System.Drawing.Color.DarkGray;
            this.zPositiveIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zPositiveIndicator.IndicatorColor = System.Drawing.Color.Tomato;
            this.zPositiveIndicator.Location = new System.Drawing.Point(298, 40);
            this.zPositiveIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.zPositiveIndicator.Name = "zPositiveIndicator";
            this.zPositiveIndicator.Size = new System.Drawing.Size(130, 100);
            this.zPositiveIndicator.TabIndex = 3;
            // 
            // xNegativeIndicator
            // 
            this.xNegativeIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNegativeIndicator.DisabledColor = System.Drawing.Color.DarkGray;
            this.xNegativeIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xNegativeIndicator.IndicatorColor = System.Drawing.Color.Tomato;
            this.xNegativeIndicator.Location = new System.Drawing.Point(40, 140);
            this.xNegativeIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.xNegativeIndicator.Name = "xNegativeIndicator";
            this.xNegativeIndicator.Size = new System.Drawing.Size(129, 100);
            this.xNegativeIndicator.TabIndex = 4;
            // 
            // yNegativeIndicator
            // 
            this.yNegativeIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yNegativeIndicator.DisabledColor = System.Drawing.Color.DarkGray;
            this.yNegativeIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yNegativeIndicator.IndicatorColor = System.Drawing.Color.Tomato;
            this.yNegativeIndicator.Location = new System.Drawing.Point(169, 140);
            this.yNegativeIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.yNegativeIndicator.Name = "yNegativeIndicator";
            this.yNegativeIndicator.Size = new System.Drawing.Size(129, 100);
            this.yNegativeIndicator.TabIndex = 5;
            // 
            // zNegativeIndicator
            // 
            this.zNegativeIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zNegativeIndicator.DisabledColor = System.Drawing.Color.DarkGray;
            this.zNegativeIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zNegativeIndicator.IndicatorColor = System.Drawing.Color.Tomato;
            this.zNegativeIndicator.Location = new System.Drawing.Point(298, 140);
            this.zNegativeIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.zNegativeIndicator.Name = "zNegativeIndicator";
            this.zNegativeIndicator.Size = new System.Drawing.Size(130, 100);
            this.zNegativeIndicator.TabIndex = 6;
            // 
            // xZeroIndicator
            // 
            this.xZeroIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xZeroIndicator.DisabledColor = System.Drawing.Color.DarkGray;
            this.xZeroIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xZeroIndicator.IndicatorColor = System.Drawing.Color.DarkGray;
            this.xZeroIndicator.Location = new System.Drawing.Point(40, 240);
            this.xZeroIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.xZeroIndicator.Name = "xZeroIndicator";
            this.xZeroIndicator.Size = new System.Drawing.Size(129, 101);
            this.xZeroIndicator.TabIndex = 7;
            // 
            // yZeroIndicator
            // 
            this.yZeroIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yZeroIndicator.DisabledColor = System.Drawing.Color.DarkGray;
            this.yZeroIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yZeroIndicator.IndicatorColor = System.Drawing.Color.DarkGray;
            this.yZeroIndicator.Location = new System.Drawing.Point(169, 240);
            this.yZeroIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.yZeroIndicator.Name = "yZeroIndicator";
            this.yZeroIndicator.Size = new System.Drawing.Size(129, 101);
            this.yZeroIndicator.TabIndex = 8;
            // 
            // zZeroIndicator
            // 
            this.zZeroIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zZeroIndicator.DisabledColor = System.Drawing.Color.DarkGray;
            this.zZeroIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zZeroIndicator.IndicatorColor = System.Drawing.Color.DarkGray;
            this.zZeroIndicator.Location = new System.Drawing.Point(298, 240);
            this.zZeroIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.zZeroIndicator.Name = "zZeroIndicator";
            this.zZeroIndicator.Size = new System.Drawing.Size(130, 101);
            this.zZeroIndicator.TabIndex = 9;
            // 
            // DirectionIndicationPanel
            // 
            this.ColumnCount = 4;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Controls.Add(this.label1, 1, 0);
            this.Controls.Add(this.label2, 2, 0);
            this.Controls.Add(this.label3, 3, 0);
            this.Controls.Add(this.xPositiveIndicator, 1, 1);
            this.Controls.Add(this.yPositiveIndicator, 2, 1);
            this.Controls.Add(this.zPositiveIndicator, 3, 1);
            this.Controls.Add(this.xNegativeIndicator, 1, 2);
            this.Controls.Add(this.yNegativeIndicator, 2, 2);
            this.Controls.Add(this.zNegativeIndicator, 3, 2);
            this.Controls.Add(this.xZeroIndicator, 1, 3);
            this.Controls.Add(this.yZeroIndicator, 2, 3);
            this.Controls.Add(this.zZeroIndicator, 3, 3);
            this.Controls.Add(this.label4, 0, 1);
            this.Controls.Add(this.label5, 0, 2);
            this.Controls.Add(this.label6, 0, 3);
            this.Location = new System.Drawing.Point(0, 27);
            this.RowCount = 4;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.Size = new System.Drawing.Size(428, 341);
            this.TabStop = true;                                                                          
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DirectionIndicationPanel_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Indicator xZeroIndicator;
        private Indicator yZeroIndicator;
        private Indicator zZeroIndicator;
        private Indicator xPositiveIndicator;
        private Indicator yPositiveIndicator;
        private Indicator zPositiveIndicator;
        private Indicator xNegativeIndicator;
        private Indicator yNegativeIndicator;
        private Indicator zNegativeIndicator;
    }
}
