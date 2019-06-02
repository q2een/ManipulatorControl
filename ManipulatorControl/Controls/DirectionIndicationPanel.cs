using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManipulatorControl
{
    public partial class DirectionIndicationPanel : TableLayoutPanel
    {

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public DirectionIndicationPanel()
        {
            InitializeComponent();

            xZeroIndicator.Enabled = true;
            yZeroIndicator.Enabled = true;
            zZeroIndicator.Enabled = true;

        }

        public bool IsZeroEnabled
        {
            get
            {
                return xZeroIndicator.Enabled && yZeroIndicator.Enabled && zZeroIndicator.Enabled;
            }
            set
            {
                xZeroIndicator.Enabled = value;
                yZeroIndicator.Enabled = value;
                zZeroIndicator.Enabled = value;
            }
        }

        public void SetZeroPositionState(bool isXYZero, bool isZZero)
        {
            xZeroIndicator.IndicatorColor = isXYZero ? Color.Blue : Color.DarkGray;
            yZeroIndicator.IndicatorColor = isXYZero ? Color.Blue : Color.DarkGray;

            zZeroIndicator.IndicatorColor = isZZero ? Color.Blue : Color.DarkGray;
        }

        private void SetIndicatorState(Indicator indicator, bool isRunning = true)
        {
            indicator.IndicatorColor = isRunning ? Color.GreenYellow : Color.Tomato;
        }

        private void SetIndicatorState(bool isRunning, params Indicator[] indicators)
        {
            foreach (var indicator in indicators)
                indicator.IndicatorColor = isRunning ? Color.GreenYellow : Color.Tomato;
        }

        public void SetLocation(bool isRunning, double x, double y, double z)
        {
            if (isRunning)
            {
                SetIndicatorState(X, x, xPositiveIndicator, xNegativeIndicator);
                SetIndicatorState(Y, y, yPositiveIndicator, yNegativeIndicator);
                SetIndicatorState(Z, z, zPositiveIndicator, zNegativeIndicator);
            }
            else
                OffAllExcept(xZeroIndicator, yZeroIndicator, zZeroIndicator);

            X = x;
            Y = y;
            Z = z;
        }

        private void SetIndicatorState(double position, double newPosition, Indicator positive, Indicator negative)
        {
            if (position == newPosition)
                return;

            var isPositiveDirection = IsPositiveDirection(position, newPosition);

            System.Diagnostics.Debug.WriteLine(isPositiveDirection);

            SetIndicatorState(positive, isPositiveDirection);
            SetIndicatorState(negative, !isPositiveDirection);
        }

        private bool IsPositiveDirection(double position, double newPosition)
        {
            return position < newPosition;
        }

        private void OffAllExcept(params Indicator[] indicators)
        {
            foreach (var control in Controls)
            {
                var indicator = control as Indicator;

                if (indicator != null && !indicators.Contains(indicator))
                    SetIndicatorState(indicator, false);
            }
        }

        private void OffAllIndicators()
        {
            OffAllExcept();
        }

        private void DirectionIndicationPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var control in Controls)
            {
                var indicator = control as Indicator;

                if (indicator != null)
                    indicator.Redraw();
            }
        }
    }
}
