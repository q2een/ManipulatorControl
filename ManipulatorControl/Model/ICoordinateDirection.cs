using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManipulatorControl
{
    public interface ICoordinateDirection
    {
        CoordinateDirections Directions { get; set; }
    }
}
