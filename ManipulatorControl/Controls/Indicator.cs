using System;
using System.Drawing;
using System.Windows.Forms;

namespace ManipulatorControl
{
    /// <summary>
    /// Предоставляет элемент управления для индикации.
    /// </summary>
    public class Indicator: UserControl
    {   
        private Color color;

        private bool enabled;

        public new bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                this.enabled = value; 
                Invalidate();
            }
        }

        public Color DisabledColor { get; set; }

        /// <summary>
        /// Возвращает или задает цвет инидикатора.
        /// </summary>
        public Color IndicatorColor
        {
            get
            {
                return this.color;
            }
            set
            {
                if (value == this.color)
                    return;

                this.color = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Предоставляет элемент управления для индикации с заданным цветом <paramref name="defaultColor"/>.
        /// </summary>
        public Indicator(Color defaultColor)
        {
            ResizeRedraw = true;
            TabStop = true;
            IndicatorColor = defaultColor;
            Enabled = true;
            DisabledColor = Color.DarkGray;
        }

        /// <summary>
        /// Предоставляет элемент управления для индикации
        /// </summary>
        public Indicator():this(Color.DarkGray)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(BackColor);
            DrawCircle(e.Graphics, new SolidBrush(Enabled ? IndicatorColor : DisabledColor), e.ClipRectangle);
        }

        private void DrawCircle(Graphics g, Brush brush, Rectangle rect)
        {
            var centerX = rect.Width / 2.0f;
            var centerY = rect.Height / 2.0f;
            var radius = Math.Min(centerX, centerY)-7.5f;

            g.FillEllipse(brush, centerX - radius, centerY - radius,
              radius + radius, radius + radius); 
        }

        public void Redraw()
        {
            Invalidate();
            Update();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "Indicator";
            this.ResumeLayout(false);

        }
    }
}
