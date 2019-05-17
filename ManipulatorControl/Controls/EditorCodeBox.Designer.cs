namespace ManipulatorControl
{
    partial class EditorCodeBox
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
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.LineNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.linesPanel = new System.Windows.Forms.Panel();
            this.richTextBoxPanel = new System.Windows.Forms.Panel();
            this.linesPanel.SuspendLayout();
            this.richTextBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.AcceptsTab = true;
            this.richTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox.ForeColor = System.Drawing.Color.White;
            this.richTextBox.Location = new System.Drawing.Point(0, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(465, 355);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            this.richTextBox.WordWrap = false;
            this.richTextBox.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
            this.richTextBox.VScroll += new System.EventHandler(this.richTextBox_VScroll);
            this.richTextBox.FontChanged += new System.EventHandler(this.richTextBox_FontChanged);
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            this.richTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyDown);
            // 
            // LineNumberTextBox
            // 
            this.LineNumberTextBox.BackColor = System.Drawing.Color.White;
            this.LineNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineNumberTextBox.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LineNumberTextBox.ForeColor = System.Drawing.Color.Black;
            this.LineNumberTextBox.Location = new System.Drawing.Point(0, 2);
            this.LineNumberTextBox.Name = "LineNumberTextBox";
            this.LineNumberTextBox.ReadOnly = true;
            this.LineNumberTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LineNumberTextBox.Size = new System.Drawing.Size(69, 355);
            this.LineNumberTextBox.TabIndex = 3;
            this.LineNumberTextBox.TabStop = false;
            this.LineNumberTextBox.Text = "";
            this.LineNumberTextBox.WordWrap = false;
            this.LineNumberTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LineNumberTextBox_MouseDoubleClick);
            this.LineNumberTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LineNumberTextBox_MouseDown);
            // 
            // linesPanel
            // 
            this.linesPanel.BackColor = System.Drawing.Color.White;
            this.linesPanel.Controls.Add(this.LineNumberTextBox);
            this.linesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.linesPanel.Location = new System.Drawing.Point(0, 0);
            this.linesPanel.Margin = new System.Windows.Forms.Padding(0);
            this.linesPanel.Name = "linesPanel";
            this.linesPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.linesPanel.Size = new System.Drawing.Size(69, 357);
            this.linesPanel.TabIndex = 4;
            // 
            // richTextBoxPanel
            // 
            this.richTextBoxPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.richTextBoxPanel.Controls.Add(this.richTextBox);
            this.richTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxPanel.Location = new System.Drawing.Point(69, 0);
            this.richTextBoxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBoxPanel.Name = "richTextBoxPanel";
            this.richTextBoxPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.richTextBoxPanel.Size = new System.Drawing.Size(465, 357);
            this.richTextBoxPanel.TabIndex = 5;
            // 
            // EditorCodeBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxPanel);
            this.Controls.Add(this.linesPanel);
            this.Name = "EditorCodeBox";
            this.Size = new System.Drawing.Size(534, 357);
            this.Load += new System.EventHandler(this.EditorCodeBox_Load);
            this.Resize += new System.EventHandler(this.EditorCodeBox_Resize);
            this.linesPanel.ResumeLayout(false);
            this.richTextBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.RichTextBox LineNumberTextBox;
        private System.Windows.Forms.Panel linesPanel;
        private System.Windows.Forms.Panel richTextBoxPanel;
    }
}
