namespace ManipulatorControl
{
    partial class DesignParametersTabControl
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.pageDesign = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbLC = new System.Windows.Forms.TextBox();
            this.tbL2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.tbL1 = new System.Windows.Forms.TextBox();
            this.pageLever1 = new System.Windows.Forms.TabPage();
            this.pageLever2 = new System.Windows.Forms.TabPage();
            this.pageHorizontal = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbRo = new System.Windows.Forms.TextBox();
            this.tbABmax = new System.Windows.Forms.TextBox();
            this.tbABmin = new System.Windows.Forms.TextBox();
            this.tbAB = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.cmbIncreases = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.designLever1 = new ManipulatorControl.LeverDesignParameters();
            this.designLever2 = new ManipulatorControl.LeverDesignParameters();
            this.tabs.SuspendLayout();
            this.pageDesign.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pageLever1.SuspendLayout();
            this.pageLever2.SuspendLayout();
            this.pageHorizontal.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.pageDesign);
            this.tabs.Controls.Add(this.pageLever1);
            this.tabs.Controls.Add(this.pageLever2);
            this.tabs.Controls.Add(this.pageHorizontal);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(743, 491);
            this.tabs.TabIndex = 1;
            // 
            // pageDesign
            // 
            this.pageDesign.Controls.Add(this.tableLayoutPanel2);
            this.pageDesign.Location = new System.Drawing.Point(4, 27);
            this.pageDesign.Name = "pageDesign";
            this.pageDesign.Size = new System.Drawing.Size(735, 460);
            this.pageDesign.TabIndex = 0;
            this.pageDesign.Text = "Общие";
            this.pageDesign.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tbLC, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbL2, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label16, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label17, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label19, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label20, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label21, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label34, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label35, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label36, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbL1, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(735, 460);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tbLC
            // 
            this.tbLC.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbLC.Location = new System.Drawing.Point(590, 143);
            this.tbLC.MaxLength = 5;
            this.tbLC.Name = "tbLC";
            this.tbLC.Size = new System.Drawing.Size(140, 24);
            this.tbLC.TabIndex = 11;
            this.tbLC.Text = "0";
            this.tbLC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitsOnly_KeyPress);
            // 
            // tbL2
            // 
            this.tbL2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbL2.Location = new System.Drawing.Point(590, 97);
            this.tbL2.MaxLength = 5;
            this.tbL2.Name = "tbL2";
            this.tbL2.Size = new System.Drawing.Size(140, 24);
            this.tbL2.TabIndex = 8;
            this.tbL2.Text = "0";
            this.tbL2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitsOnly_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(587, 2);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(146, 44);
            this.label16.TabIndex = 2;
            this.label16.Text = "Значение";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(498, 2);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 44);
            this.label17.TabIndex = 1;
            this.label17.Text = "Обознач.";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(2, 2);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(494, 44);
            this.label18.TabIndex = 0;
            this.label18.Text = "Параметр";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(5, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(488, 44);
            this.label19.TabIndex = 3;
            this.label19.Text = "Длина плеча 1, мм.";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(5, 94);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(488, 44);
            this.label20.TabIndex = 6;
            this.label20.Text = "Длина плеча 2, мм.";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Location = new System.Drawing.Point(5, 140);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(488, 44);
            this.label21.TabIndex = 9;
            this.label21.Text = "Расстояние от центра схвата до точки его подвеса на плече 2, мм.";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label34.Location = new System.Drawing.Point(501, 140);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(81, 44);
            this.label34.TabIndex = 10;
            this.label34.Text = "Lc";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label35.Location = new System.Drawing.Point(501, 94);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(81, 44);
            this.label35.TabIndex = 7;
            this.label35.Text = "L2";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label36.Location = new System.Drawing.Point(501, 48);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(81, 44);
            this.label36.TabIndex = 4;
            this.label36.Text = "L1";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbL1
            // 
            this.tbL1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbL1.Location = new System.Drawing.Point(590, 51);
            this.tbL1.MaxLength = 5;
            this.tbL1.Name = "tbL1";
            this.tbL1.Size = new System.Drawing.Size(140, 24);
            this.tbL1.TabIndex = 5;
            this.tbL1.Text = "0";
            this.tbL1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitsOnly_KeyPress);
            // 
            // pageLever1
            // 
            this.pageLever1.Controls.Add(this.designLever1);
            this.pageLever1.Location = new System.Drawing.Point(4, 27);
            this.pageLever1.Name = "pageLever1";
            this.pageLever1.Size = new System.Drawing.Size(735, 460);
            this.pageLever1.TabIndex = 1;
            this.pageLever1.Text = "Плечо 1";
            this.pageLever1.UseVisualStyleBackColor = true;
            // 
            // pageLever2
            // 
            this.pageLever2.Controls.Add(this.designLever2);
            this.pageLever2.Location = new System.Drawing.Point(4, 27);
            this.pageLever2.Name = "pageLever2";
            this.pageLever2.Size = new System.Drawing.Size(735, 460);
            this.pageLever2.TabIndex = 2;
            this.pageLever2.Text = "Плечо 2";
            this.pageLever2.UseVisualStyleBackColor = true;
            // 
            // pageHorizontal
            // 
            this.pageHorizontal.Controls.Add(this.tableLayoutPanel3);
            this.pageHorizontal.Location = new System.Drawing.Point(4, 27);
            this.pageHorizontal.Name = "pageHorizontal";
            this.pageHorizontal.Size = new System.Drawing.Size(735, 460);
            this.pageHorizontal.TabIndex = 3;
            this.pageHorizontal.Text = "Горизонтальное плечо";
            this.pageHorizontal.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tbRo, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.tbABmax, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.tbABmin, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.tbAB, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label22, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label23, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label24, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label27, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label28, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label29, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label30, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label40, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label41, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label42, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label43, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbIncreases, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 5);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(735, 460);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tbRo
            // 
            this.tbRo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbRo.Location = new System.Drawing.Point(590, 189);
            this.tbRo.MaxLength = 5;
            this.tbRo.Name = "tbRo";
            this.tbRo.Size = new System.Drawing.Size(140, 24);
            this.tbRo.TabIndex = 20;
            this.tbRo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyValidatingDecimal_KeyPress);
            // 
            // tbABmax
            // 
            this.tbABmax.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbABmax.Location = new System.Drawing.Point(590, 143);
            this.tbABmax.MaxLength = 5;
            this.tbABmax.Name = "tbABmax";
            this.tbABmax.Size = new System.Drawing.Size(140, 24);
            this.tbABmax.TabIndex = 17;
            this.tbABmax.Text = "0";
            this.tbABmax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitsOnly_KeyPress);
            // 
            // tbABmin
            // 
            this.tbABmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbABmin.Location = new System.Drawing.Point(590, 97);
            this.tbABmin.MaxLength = 5;
            this.tbABmin.Name = "tbABmin";
            this.tbABmin.Size = new System.Drawing.Size(140, 24);
            this.tbABmin.TabIndex = 14;
            this.tbABmin.Text = "0";
            this.tbABmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitsOnly_KeyPress);
            // 
            // tbAB
            // 
            this.tbAB.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbAB.Location = new System.Drawing.Point(590, 51);
            this.tbAB.MaxLength = 5;
            this.tbAB.Name = "tbAB";
            this.tbAB.Size = new System.Drawing.Size(140, 24);
            this.tbAB.TabIndex = 11;
            this.tbAB.Text = "0";
            this.tbAB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitsOnly_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Location = new System.Drawing.Point(587, 2);
            this.label22.Margin = new System.Windows.Forms.Padding(0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(146, 44);
            this.label22.TabIndex = 2;
            this.label22.Text = "Значение";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Location = new System.Drawing.Point(498, 2);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 44);
            this.label23.TabIndex = 1;
            this.label23.Text = "Обознач.";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Location = new System.Drawing.Point(2, 2);
            this.label24.Margin = new System.Windows.Forms.Padding(0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(494, 44);
            this.label24.TabIndex = 0;
            this.label24.Text = "Параметр";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label27.Location = new System.Drawing.Point(5, 48);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(488, 44);
            this.label27.TabIndex = 9;
            this.label27.Text = "Текущее расстояние от оси подвеса ходового винта до точки крепления плеча к гайке" +
    " ходового винта, мм";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label28.Location = new System.Drawing.Point(5, 94);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(488, 44);
            this.label28.TabIndex = 12;
            this.label28.Text = "Минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к г" +
    "айке ходового винта, мм";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label29.Location = new System.Drawing.Point(5, 140);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(488, 44);
            this.label29.TabIndex = 15;
            this.label29.Text = "Максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к " +
    "гайке ходового винта, мм";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label30.Location = new System.Drawing.Point(5, 186);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(488, 44);
            this.label30.TabIndex = 18;
            this.label30.Text = "Количество шагов шагового двигателя необходимых для изменения значения текущего п" +
    "оложения на 1мм";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label40.Location = new System.Drawing.Point(501, 186);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(81, 44);
            this.label40.TabIndex = 19;
            this.label40.Text = "С";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label41.Location = new System.Drawing.Point(501, 140);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(81, 44);
            this.label41.TabIndex = 16;
            this.label41.Text = "ABmax ";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label42.Location = new System.Drawing.Point(501, 94);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(81, 44);
            this.label42.TabIndex = 13;
            this.label42.Text = "ABmin ";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label43.Location = new System.Drawing.Point(501, 48);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(81, 44);
            this.label43.TabIndex = 10;
            this.label43.Text = "AB";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbIncreases
            // 
            this.cmbIncreases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbIncreases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIncreases.FormattingEnabled = true;
            this.cmbIncreases.Items.AddRange(new object[] {
            "Увеличивается",
            "Уменьшается"});
            this.cmbIncreases.Location = new System.Drawing.Point(590, 235);
            this.cmbIncreases.Name = "cmbIncreases";
            this.cmbIncreases.Size = new System.Drawing.Size(140, 26);
            this.cmbIncreases.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 54);
            this.label1.TabIndex = 33;
            this.label1.Text = "При вращении ротора шагового двигателя по часовой стрелке расстояние от оси подве" +
    "са ходового винта до точки крепления плеча к гайке ходового винта...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // designLever1
            // 
            this.designLever1.AB = 0;
            this.designLever1.ABmax = 0;
            this.designLever1.ABmin = 0;
            this.designLever1.ABZero = null;
            this.designLever1.Alpha = 0D;
            this.designLever1.AO = 0;
            this.designLever1.Beta = 0D;
            this.designLever1.BO = 0;
            this.designLever1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designLever1.IsABIncreasesOnStepperCW = false;
            this.designLever1.Location = new System.Drawing.Point(0, 0);
            this.designLever1.Margin = new System.Windows.Forms.Padding(4);
            this.designLever1.Name = "designLever1";
            this.designLever1.P = 0;
            this.designLever1.Ro = 0D;
            this.designLever1.Size = new System.Drawing.Size(735, 460);
            this.designLever1.TabIndex = 0;
            // 
            // designLever2
            // 
            this.designLever2.AB = 0;
            this.designLever2.ABmax = 0;
            this.designLever2.ABmin = 0;
            this.designLever2.ABZero = null;
            this.designLever2.Alpha = 0D;
            this.designLever2.AO = 0;
            this.designLever2.Beta = 0D;
            this.designLever2.BO = 0;
            this.designLever2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designLever2.IsABIncreasesOnStepperCW = false;
            this.designLever2.Location = new System.Drawing.Point(0, 0);
            this.designLever2.Margin = new System.Windows.Forms.Padding(4);
            this.designLever2.Name = "designLever2";
            this.designLever2.P = 0;
            this.designLever2.Ro = 0D;
            this.designLever2.Size = new System.Drawing.Size(735, 460);
            this.designLever2.TabIndex = 0;
            // 
            // DesignParametersTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabs);
            this.Name = "DesignParametersTabControl";
            this.Size = new System.Drawing.Size(743, 491);
            this.tabs.ResumeLayout(false);
            this.pageDesign.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pageLever1.ResumeLayout(false);
            this.pageLever2.ResumeLayout(false);
            this.pageHorizontal.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage pageDesign;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbLC;
        private System.Windows.Forms.TextBox tbL2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox tbL1;
        private System.Windows.Forms.TabPage pageLever1;
        private LeverDesignParameters designLever1;
        private System.Windows.Forms.TabPage pageLever2;
        private LeverDesignParameters designLever2;
        private System.Windows.Forms.TabPage pageHorizontal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox tbRo;
        private System.Windows.Forms.TextBox tbABmax;
        private System.Windows.Forms.TextBox tbABmin;
        private System.Windows.Forms.TextBox tbAB;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ComboBox cmbIncreases;
        private System.Windows.Forms.Label label1;
    }
}
