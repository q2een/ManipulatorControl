using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManipulatorControl.Model
{
    public static class Extensions
    {
        public static string ToString(LeverType type)
        {
            if (type == LeverType.Horizontal)
                return "Горизонтальное";
            if (type == LeverType.Lever1)
                return "Плечо 1";
            if (type == LeverType.Lever2)
                return "Плечо 2";

            throw new NotImplementedException();
        }
    }
}
