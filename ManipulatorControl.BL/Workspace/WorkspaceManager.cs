using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManipulatorControl.BL.Workspace
{
    public class WorkspaceManager
    {
        private int editingWorkspaceIndex = -1;
        private List<RobotWorkspace> robotWorkspaces = new List<RobotWorkspace>();
        private RobotWorkspace activeWorkspace, editingWorkspace;

    }
}
