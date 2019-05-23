using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManipulatorControl.Workspace
{
    public class WorkspaceEventArgs: EventArgs
    {
        public int Index { get; set; }

        public string Name { get; set; }
    }
}
