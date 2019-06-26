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
#pragma warning disable 1591
    public partial class DirectionPanel : UserControl
    {
        public DirectionPanel()
        {
            InitializeComponent();
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }


        public void SetZeroPositionState(bool isXYZero, bool isZZero)
        {
            lblXZero.BackColor = isXYZero ? Color.Blue : Color.DarkGray;
            lblYZero.BackColor = isXYZero ? Color.Blue : Color.DarkGray;

            lblZZero.BackColor = isZZero ? Color.Blue : Color.DarkGray;
        }

        private void SetIndicatorState(Label indicator, bool isRunning = true)
        {
            indicator.BackColor = isRunning ? Color.GreenYellow : Color.Tomato;
        }

        private void SetIndicatorState(bool isRunning, params Label[] indicators)
        {
            foreach (var indicator in indicators)
                indicator.BackColor = isRunning ? Color.GreenYellow : Color.Tomato;
        }

        public void SetLocation(bool isRunning, double x, double y, double z)
        {
            if (isRunning)
            {
                SetIndicatorState(X, x, lblXPos, lblXNeg);
                SetIndicatorState(Y, y, lblYPos, lblYNeg);
                SetIndicatorState(Z, z, lblZPos, lblZNeg);
            }
            else
                OffAllExcept(lblXZero, lblYZero, lblZZero);
            
            X = x;
            Y = y;
            Z = z;
        }

        private void SetIndicatorState(double position, double newPosition, Label positive, Label negative)
        {
            if (position == newPosition)
                return;

            var isPositiveDirection = IsPositiveDirection(position, newPosition);

            SetIndicatorState(positive, isPositiveDirection);
            SetIndicatorState(negative, !isPositiveDirection);
        }

        private bool IsPositiveDirection(double position, double newPosition)
        {
            return position < newPosition;
        }

        private void OffAllExcept(params Label[] indicators)
        {
            foreach (var control in new[] { lblXPos, lblXNeg, lblYPos, lblYNeg, lblZPos, lblZNeg, lblXZero, lblYZero, lblZZero })
            {
                if (!indicators.Contains(control))
                    SetIndicatorState(control, false);
            }
        }

        private void OffAllIndicators()
        {
            OffAllExcept();
        }
    }
}
