﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManipulatorControl.BL
{
    public struct Location
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }


        public Location(double x, double y, double z):this()
        {
            X = x;
            Y = y;
            Z = z;
        }         
    }
}
