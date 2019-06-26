using ManipulatorControl.BL;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ManipulatorControl
{
#pragma warning disable 1591
    public class ManualControlItem
    {
        public LeverType Type { get; set; }

        public ManualUserControls PositiveDirection { get; set; }

        public ManualUserControls NegativeDirection { get; set; }

        public ManualUserControls NullDirection { get; set; }

        public Keys[] ControlKeys
        {
            get
            {
                return new[] { PositiveDirection.Key, NegativeDirection.Key, NullDirection.Key };
            }
        }

        public Button[] ControlButtons
        {
            get
            {
                return new[] { PositiveDirection.Button, NegativeDirection.Button, NullDirection.Button };
            }
        }

        public ManualUserControls Active { get; set; }

        public StepLever StepLever
        {
            get
            {
                return new StepLever(Type, Active);   
            }
        }

        public event EventHandler OnInvokeStart = delegate { };
        public event EventHandler OnInvokeStop = delegate { };

        public ManualControlItem(LeverType type, Keys keyPos, Keys keyNeg, Keys keyNull, Button btnPos, Button btnNeg, Button btnNull)
        {
            Type = type;
            PositiveDirection = new ManualUserControls(btnPos, keyPos, true);
            NegativeDirection = new ManualUserControls(btnNeg, keyNeg, false);
            NullDirection = new ManualUserControls(btnNull, keyNull, null);

            foreach (var btn in ControlButtons)
            {
                btn.Paint += Button_Paint;
                btn.MouseDown += Button_MouseDown;
                btn.MouseUp += Button_MouseUp;
                btn.MouseLeave += Button_MouseLeave;
            }

            timer.Tick += Timer_Tick;
        }

        public void Invalidate(bool isHotKeysMode)
        {
            this.isHotKeysMode = isHotKeysMode;

            foreach (var btn in ControlButtons)
            {
                btn.Enabled = !isHotKeysMode;
                btn.Invalidate();
            }
        }

        public void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (!isHotKeysMode || Active != null)
                return;

            if (!ControlKeys.Contains(e.KeyCode))
                return;

            Active = GetEntityByKey(e.KeyCode);

            timer.Start();
        }

        public void HandleKeyUp(object sender, KeyEventArgs e)
        {
            if (!isHotKeysMode || Active == null)
                return;

            if (e.KeyCode != Active.Key)
                return;

            if (!timer.Enabled)  
                OnInvokeStop(this, EventArgs.Empty);

            timer.Stop();

            Active.Button.Invalidate(); 
            Active = null;
        }

        private Keys GetButtonHotKey(Button btn)
        {
            if (btn == NullDirection.Button)
                return NullDirection.Key;

            return (btn == PositiveDirection.Button ? PositiveDirection : NegativeDirection).Key;
        }

        private Button GetButtonByHotKey(Keys key)
        {
            if (key == NullDirection.Key)
                return NullDirection.Button;

            return (key == PositiveDirection.Key ? PositiveDirection : NegativeDirection).Button;
        }

        private ManualUserControls GetEntityByButton(Button btn)
        {
            if (btn == NullDirection.Button)
                return NullDirection;

            return btn == PositiveDirection.Button ? PositiveDirection : NegativeDirection;
        }

        private ManualUserControls GetEntityByKey(Keys key)
        {
            return GetEntityByButton(GetButtonByHotKey(key));
        }

        private void MarkAsActive()
        {
            if (Active == null)
                return;

            var btn = Active.Button;
            btn.CreateGraphics().DrawRectangle(new Pen(Color.Blue, 3), 3, 3, btn.Width - 6, btn.Height - 6);
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || Active != null)
                return;

            Active = GetEntityByButton(sender as Button);
            timer.Start();
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || Active == null)
                return;

            var button = sender as Button;

            if (button != Active.Button)
                return;

            if (!timer.Enabled)
                OnInvokeStop(this, EventArgs.Empty);

            timer.Stop();

            Active.Button.Invalidate(); 
            Active = null;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            // Устранение бага, когда после нажатия на левую клавишу над кнопкой увести курсор за пределы 
            // кнопки, нажать на правую кнопку, а потом отпустить левую.
            if (Active != null)
                Button_MouseUp(sender, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            OnInvokeStart(this, EventArgs.Empty);

            MarkAsActive();

            timer.Stop();
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            if (!isHotKeysMode)
                return;

            var key = GetButtonHotKey(sender as Button);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            using (var drawFont = new Font("Arial", 10))
            {
                var stringSize = e.Graphics.MeasureString(key.ToString(), drawFont);
                e.Graphics.FillRectangle(Brushes.LemonChiffon, 6, 6, stringSize.Width, stringSize.Height);
                e.Graphics.DrawString(key.ToString(), drawFont, Brushes.Black, 6, 8);
            }
        }

        #region Поля.

        private bool isHotKeysMode = false;

        private Timer timer = new Timer() { Interval = 1000 };

        #endregion
    }
}
