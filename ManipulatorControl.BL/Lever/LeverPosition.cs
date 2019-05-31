using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManipulatorControl.BL
{
    public class LeverPosition : EventArgs
    {
        public LeverType Lever { get; private set; }

        public double Position{ get; set; }

        public LeverPosition(LeverType lever, double position)
        {
            Lever = lever;
            Position = position;
        }
    }
}
