namespace ManipulatorControl.Controls
{
    #pragma warning disable 1591
    partial class DesignParametersControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tabLinks = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tpLever1 = new System.Windows.Forms.TabPage();
            this.tpLever2 = new System.Windows.Forms.TabPage();
            this.tpHorizontal = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbAdditional = new System.Windows.Forms.GroupBox();
            this.panelAdditional = new System.Windows.Forms.Panel();
            this.cmbAbIncreases = new System.Windows.Forms.ComboBox();
            this.lblAbIncreases = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tabLinks.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbAdditional.SuspendLayout();
            this.panelAdditional.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::ManipulatorControl.Properties.Resources.scheme;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 401);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(394, 274);
            this.dgv.TabIndex = 2;
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
            // 
            // tabLinks
            // 
            this.tabLinks.Controls.Add(this.tpGeneral);
            this.tabLinks.Controls.Add(this.tpLever1);
            this.tabLinks.Controls.Add(this.tpLever2);
            this.tabLinks.Controls.Add(this.tpHorizontal);
            this.tabLinks.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabLinks.ItemSize = new System.Drawing.Size(58, 30);
            this.tabLinks.Location = new System.Drawing.Point(232, 0);
            this.tabLinks.Name = "tabLinks";
            this.tabLinks.SelectedIndex = 0;
            this.tabLinks.Size = new System.Drawing.Size(394, 27);
            this.tabLinks.TabIndex = 3;
            this.tabLinks.SelectedIndexChanged += new System.EventHandler(this.tabLinks_SelectedIndexChanged);
            // 
            // tpGeneral
            // 
            this.tpGeneral.Location = new System.Drawing.Point(4, 34);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(386, 0);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "Общие";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // tpLever1
            // 
            this.tpLever1.Location = new System.Drawing.Point(4, 34);
            this.tpLever1.Name = "tpLever1";
            this.tpLever1.Padding = new System.Windows.Forms.Padding(3);
            this.tpLever1.Size = new System.Drawing.Size(386, 0);
            this.tpLever1.TabIndex = 1;
            this.tpLever1.Text = "Плечо";
            this.tpLever1.UseVisualStyleBackColor = true;
            // 
            // tpLever2
            // 
            this.tpLever2.Location = new System.Drawing.Point(4, 34);
            this.tpLever2.Name = "tpLever2";
            this.tpLever2.Size = new System.Drawing.Size(386, 0);
            this.tpLever2.TabIndex = 2;
            this.tpLever2.Text = "Предплечье";
            this.tpLever2.UseVisualStyleBackColor = true;
            // 
            // tpHorizontal
            // 
            this.tpHorizontal.Location = new System.Drawing.Point(4, 34);
            this.tpHorizontal.Name = "tpHorizontal";
            this.tpHorizontal.Size = new System.Drawing.Size(386, 0);
            this.tpHorizontal.TabIndex = 3;
            this.tpHorizontal.Text = "Каретка";
            this.tpHorizontal.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Controls.Add(this.gbAdditional);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(232, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 374);
            this.panel1.TabIndex = 4;
            // 
            // gbAdditional
            // 
            this.gbAdditional.Controls.Add(this.panelAdditional);
            this.gbAdditional.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbAdditional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbAdditional.Location = new System.Drawing.Point(0, 274);
            this.gbAdditional.Name = "gbAdditional";
            this.gbAdditional.Size = new System.Drawing.Size(394, 100);
            this.gbAdditional.TabIndex = 4;
            this.gbAdditional.TabStop = false;
            this.gbAdditional.Text = "Дополнительные параметры";
            // 
            // panelAdditional
            // 
            this.panelAdditional.Controls.Add(this.cmbAbIncreases);
            this.panelAdditional.Controls.Add(this.lblAbIncreases);
            this.panelAdditional.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdditional.Location = new System.Drawing.Point(3, 18);
            this.panelAdditional.Name = "panelAdditional";
            this.panelAdditional.Size = new System.Drawing.Size(388, 79);
            this.panelAdditional.TabIndex = 3;
            // 
            // cmbAbIncreases
            // 
            this.cmbAbIncreases.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbAbIncreases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAbIncreases.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbAbIncreases.FormattingEnabled = true;
            this.cmbAbIncreases.Items.AddRange(new object[] {
            "Увеличивается",
            "Уменьшается"});
            this.cmbAbIncreases.Location = new System.Drawing.Point(0, 56);
            this.cmbAbIncreases.Name = "cmbAbIncreases";
            this.cmbAbIncreases.Size = new System.Drawing.Size(388, 24);
            this.cmbAbIncreases.TabIndex = 1;
            this.cmbAbIncreases.SelectedIndexChanged += new System.EventHandler(this.cmbAbIncreases_SelectedIndexChanged);
            // 
            // lblAbIncreases
            // 
            this.lblAbIncreases.BackColor = System.Drawing.Color.Transparent;
            this.lblAbIncreases.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAbIncreases.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAbIncreases.Location = new System.Drawing.Point(0, 0);
            this.lblAbIncreases.Name = "lblAbIncreases";
            this.lblAbIncreases.Size = new System.Drawing.Size(388, 56);
            this.lblAbIncreases.TabIndex = 0;
            this.lblAbIncreases.Text = "При вращении ротора шагового двигателя по часовой стрелке расстояние от оси подве" +
    "са ходового винта до точки крепления плеча к гайке ходового винта...";
            // 
            // DesignParametersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabLinks);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DesignParametersControl";
            this.Size = new System.Drawing.Size(626, 401);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tabLinks.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbAdditional.ResumeLayout(false);
            this.panelAdditional.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TabControl tabLinks;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpLever1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelAdditional;
        private System.Windows.Forms.Label lblAbIncreases;
        private System.Windows.Forms.ComboBox cmbAbIncreases;
        private System.Windows.Forms.GroupBox gbAdditional;
        private System.Windows.Forms.TabPage tpLever2;
        private System.Windows.Forms.TabPage tpHorizontal;
    }
}
