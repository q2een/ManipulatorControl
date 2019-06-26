using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace ManipulatorControl
{
#pragma warning disable 1591
    /// <summary>
    /// <c>EditorCodeBox</c> - Элемент управления, для редактирования Gcode-текста с нумерацией строк.
    /// </summary>
    public partial class EditorCodeBox: UserControl
    {
        #region Свойства элемента управления.

        /// <summary>
        /// Возвращает используемый при отображении текст в элементе управления.
        /// </summary>
        public new Font Font
        {
            get
            {
                return richTextBox.Font;
            }
        }

        /// <summary>
        /// Получает или задает размер шрифта в пунктах.
        /// </summary>
        public byte FontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                fontSize = value;
                var linesFont = LineNumberTextBox.Font;
                LineNumberTextBox.Font = richTextBox.Font = new Font(linesFont.FontFamily, value, linesFont.Style);
            }
        }
     
        /// <summary>
        /// Получает или задает значение, указывающее, является ли текст в текстовом поле доступным только для чтения.
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return richTextBox.ReadOnly;
            }
            set
            {
                richTextBox.ReadOnly = value;
            }
        }

        /// <summary>
        /// Получает или задает текущий текст в поле форматированного текста.
        /// </summary>
        public override string Text
        {
            get
            {
                return richTextBox.Text;
            }
            set
            {
                richTextBox.Text = value;
            }
        }

        /// <summary>
        /// Указывает включен ли элемент управления.
        /// </summary>
        public bool Enable 
        {
            get
            {
                return richTextBoxPanel.Enabled && linesPanel.Enabled;
            }
            set 
            {
                richTextBoxPanel.Enabled = linesPanel.Enabled = value; 
            }
        }

        /// <summary>
        /// Получает или задает видимость нумерации строк.
        /// </summary>
        [DefaultValue(true)]
        public bool EnableLineNumbering
        {
            get
            {
                return linesPanel.Visible;
            }
            set
            {
                linesPanel.Visible = value;
            }
        }

        /// <summary>
        /// Показывает, переносятся ли автоматически в начало следующей строки слова
        /// текста по достижении границы многострочного текстового поля.
        /// </summary>
        public bool WordWrap
        {
            get 
            {
                return richTextBox.WordWrap;
            }
            set 
            {
                richTextBox.WordWrap = value;
            }
        }

        /// <summary>
        /// Получает или задает строки текста в элементе управления.
        /// </summary>
        public string[] Lines 
        {
            get
            {
                return richTextBox.Lines;
            }
            set
            {
                richTextBox.Lines = value;
            }
        }

        /// <summary>
        /// Получает или задает цвет фона элемента управления для вода текста.
        /// </summary>
        public override Color BackColor
        {
            get
            {
                return richTextBox.BackColor;
            }
            set
            {
                richTextBox.BackColor = value;
                richTextBoxPanel.BackColor = value;
            }
        }

        /// <summary>
        /// Получает или задает цвет текста в элементе управления.
        /// </summary>
        public override Color ForeColor
        {
            get
            {
                return richTextBox.ForeColor;
            }
            set
            {
                richTextBox.ForeColor = value;
                richTextBoxPanel.ForeColor = value;
            }
        }

        /// <summary>
        /// Получает или задает цвет фона элемента управления содержащего строки.
        /// </summary>
        public Color LineNumbersBackColor
        {
            get
            {
                return LineNumberTextBox.BackColor;
            }
            set
            {
                LineNumberTextBox.BackColor = value;
                linesPanel.BackColor = value;
            }
        }

        /// <summary>
        /// Получает или задает цвет текста элемента управления содержащего строки.
        /// </summary>
        public Color LineNumbersForeColor
        {
            get
            {
                return LineNumberTextBox.ForeColor;
            }
            set
            {
                LineNumberTextBox.ForeColor = value;
            }
        }

        /// <summary>
        /// Возвращает или задает контекстное меню, сопоставленное с элементом управления.
        /// </summary>
        public override ContextMenu ContextMenu
        {
            get
            {
                return richTextBox.ContextMenu;
            }

            set
            {
                richTextBox.ContextMenu = value;
            }
        }

        /// <summary>
        /// Получает или задает тип полос прокрутки.
        /// </summary>
        public RichTextBoxScrollBars ScrollBars
        {
            get
            {
                return richTextBox.ScrollBars;
            }
            set
            {
                richTextBox.ScrollBars = value;
            }
        }

        #endregion

        #region Конструкторы.

        /// <summary>
        /// <c>EditorCodeBox</c> - Элемент управления, для редактирования Gcode-текста с нумерацией строк.
        /// </summary>
        public EditorCodeBox()
        {
            InitializeComponent();
            SetDefaultViewSettings();
        }

        #endregion

        #region Методы.

        /// <summary>
        /// Устанавливает стандартные цвета элемента управления
        /// </summary>
        public void SetDefaultViewSettings()
        {
            this.BackColor = Color.FromArgb(25, 25, 25);
            LineNumberTextBox.BackColor = Color.White;
            LineNumberTextBox.ForeColor = Color.Black;            
            linesPanel.Visible = true;
        }
        
        /// <summary>
        /// Устанавливает курсор на начало строки с номером<paramref name="lineNumber"/>.
        /// </summary>
        public void SetCursorOnLineStart(int lineNumber)
        {
            if (lineNumber < 0)
                return;

            richTextBox.Select();
            richTextBox.Select(richTextBox.GetFirstCharIndexFromLine(lineNumber), 0);
        } 

        /// <summary>
        /// Возвращет номер строки на которой расопложена точка <c>point</c>.
        /// </summary>
        /// <param name="point">Точка относительно элемента управления</param>
        /// <returns>Номер строки</returns>
        protected int GetLineIndexByPoint(Point point)
        {
            int currIndex = richTextBox.GetCharIndexFromPosition(point);
            return richTextBox.GetLineFromCharIndex(currIndex);
        }

        #endregion

        #region Приватные методы.

        /// <summary>
        /// Возвращает размер, необходимый для номера строки.
        /// </summary>
        /// <returns>Размер, необходимый для номера строки.</returns>
        private int CalculateLineNumberWidth()
        {
            int lineCount = richTextBox.Lines.Length;

            return (lineCount <= 99 ? 20 : lineCount <= 999 ? 30 : 50) + (int)richTextBox.Font.Size;
        }

        /// <summary>
        /// Добавляет номера строк в элемент управления.
        /// </summary>
        private void AddLineNumbers()
        {
            int firstLine = GetLineIndexByPoint(new Point(0, 0)) + 1;
            int lastLine = GetLineIndexByPoint(new Point(ClientRectangle.Width, ClientRectangle.Height)) + 2;

            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            linesPanel.Width = CalculateLineNumberWidth();

            LineNumberTextBox.Text = string.Join("\n", Enumerable.Range(firstLine, lastLine).Select(i => i + ""));
        }

        #endregion

        #region События

        protected void EditorCodeBox_Load(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox.Font;
            richTextBox.Select();
            AddLineNumbers();
        }

        protected void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = richTextBox.GetPositionFromCharIndex(richTextBox.SelectionStart);

            if (pt.X == 1) 
                AddLineNumbers();
        }

        protected void richTextBox_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        protected void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox.Text == "")
            {
                AddLineNumbers();
            }
                              

            var cursorPosition = richTextBox.SelectionStart;

            richTextBox.Select(cursorPosition, 0);
        }

        protected void richTextBox_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox.Font;
            richTextBox.Select();
            AddLineNumbers();
        }

        protected void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBox.Select();
            LineNumberTextBox.DeselectAll();
        }

        protected void EditorCodeBox_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        protected void LineNumberTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (richTextBox.Lines.Count() == 0)
                return;

            int firstcharindex = richTextBox.GetCharIndexFromPosition(new Point(0, e.Location.Y));
            int currentline = richTextBox.GetLineFromCharIndex(firstcharindex);

            string currentlinetext = richTextBox.Lines[currentline];
            richTextBox.Select(firstcharindex, currentlinetext.Length);
        }

        #endregion

        #region Поля.

        private byte fontSize = 14;

        #endregion

        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                ((RichTextBox)sender).Paste(DataFormats.GetFormat("Text"));
                e.Handled = true;
            }
        }
    }
}
