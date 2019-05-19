using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM160CalculationLib;

namespace ManipulatorControl.Model
{
    public class RobotWorkspace
    {
        public string Name { get; set; }

        public IPartMovable Lever1Workspace { get; set; }

        public IPartMovable Lever2Workspace { get; set; }

        public IPartMovable HorizontalLeverWorkspace { get; set; }
    }
}
