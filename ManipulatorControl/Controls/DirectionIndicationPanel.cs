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
    public partial class DirectionIndicationPanel : TableLayoutPanel, ICoordinateDirection
    {
        public DirectionIndicationPanel()
        {
            InitializeComponent();

            xZeroIndicator.IndicatorColor = Color.Tomato;
            yZeroIndicator.IndicatorColor = Color.Tomato;
            zZeroIndicator.IndicatorColor = Color.Tomato;

        }

        private CoordinateDirections directions;

        public CoordinateDirections Directions
        {
            get
            {
                return directions;
            }
            set
            {
                if (value.HasFlag(CoordinateDirections.None) || value == 0)
                {
                    OffAllIndicators();
                    directions = CoordinateDirections.None;
                    return;
                }
                if (value.HasFlag(CoordinateDirections.XNone))
                {
                    SetIndicatorState(false, xPositiveIndicator, xNegativeIndicator, xZeroIndicator);
                }
                if (value.HasFlag(CoordinateDirections.YNone))
                {
                    SetIndicatorState(false, yPositiveIndicator, yNegativeIndicator, yZeroIndicator);
                }
                if (value.HasFlag(CoordinateDirections.ZNone))
                {
                    SetIndicatorState(false, zPositiveIndicator, zNegativeIndicator, zZeroIndicator);
                }
                if (value.HasFlag(CoordinateDirections.XNegative))
                {
                    if (!value.HasFlag(CoordinateDirections.XNone))
                        SetIndicatorState(xNegativeIndicator);
                    else value ^= CoordinateDirections.XNegative;
                }
                if (value.HasFlag(CoordinateDirections.YNegative))
                {
                    if (!value.HasFlag(CoordinateDirections.YNone))
                        SetIndicatorState(yNegativeIndicator);
                    else value ^= CoordinateDirections.YNegative;
                }
                if (value.HasFlag(CoordinateDirections.ZNegative))
                {
                    if (!value.HasFlag(CoordinateDirections.ZNone))
                        SetIndicatorState(zNegativeIndicator);
                    else value ^= CoordinateDirections.ZNegative;
                }
                if (value.HasFlag(CoordinateDirections.XPositive))
                {
                    if (!value.HasFlag(CoordinateDirections.XNone))
                        SetIndicatorState(xPositiveIndicator);
                    else value ^= CoordinateDirections.XPositive;
                }
                if (value.HasFlag(CoordinateDirections.YPositive))
                {
                    if (!value.HasFlag(CoordinateDirections.YNone))
                        SetIndicatorState(yPositiveIndicator);
                    else value ^= CoordinateDirections.YPositive;
                }
                if (value.HasFlag(CoordinateDirections.ZPositive))
                {
                    if (!value.HasFlag(CoordinateDirections.ZNone))
                        SetIndicatorState(zPositiveIndicator);
                    else value ^= CoordinateDirections.ZPositive;
                }
                if (value.HasFlag(CoordinateDirections.XZero))
                {
                    if (!value.HasFlag(CoordinateDirections.XNone))
                        SetIndicatorState(xZeroIndicator);
                    else value ^= CoordinateDirections.XZero;
                }
                if (value.HasFlag(CoordinateDirections.YZero))
                {
                    if (!value.HasFlag(CoordinateDirections.YNone))
                        SetIndicatorState(yZeroIndicator);
                    else value ^= CoordinateDirections.YZero;
                }
                if (value.HasFlag(CoordinateDirections.ZZero))
                {
                    if (!value.HasFlag(CoordinateDirections.ZNone))
                        SetIndicatorState(zZeroIndicator);
                    else value ^= CoordinateDirections.ZZero;
                }
                if (value.HasFlag(CoordinateDirections.OnXZero))
                    xZeroIndicator.IndicatorColor = Color.Blue;
                if (value.HasFlag(CoordinateDirections.OnYZero))
                    yZeroIndicator.IndicatorColor = Color.Blue;
               if (value.HasFlag(CoordinateDirections.OnZZero))
                    zZeroIndicator.IndicatorColor = Color.Blue;

                directions = value;
            }
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

        public void InicateOnZero(CoordinateDirections dir)
        {
            if (dir.HasFlag(CoordinateDirections.XZero))
                xZeroIndicator.IndicatorColor = Color.Blue;
            else if (dir.HasFlag(CoordinateDirections.YZero))
                yZeroIndicator.IndicatorColor = Color.Blue;
            else if (dir.HasFlag(CoordinateDirections.ZZero))
                zZeroIndicator.IndicatorColor = Color.Blue;
            else
                Directions = dir;
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

        private void OffAllIndicators()
        {
            foreach (var control in Controls)
            {
                if (control is Indicator)
                    SetIndicatorState(control as Indicator, false);
            }
        }
    }
}
