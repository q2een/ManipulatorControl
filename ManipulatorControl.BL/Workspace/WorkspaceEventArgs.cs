using System;

namespace ManipulatorControl.BL.Workspace
{
    public class WorkspaceEventArgs: EventArgs
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public WorkspaceEventArgs()
        {

        }

        public WorkspaceEventArgs(string name)
        {
            Name = name;
        }

        public WorkspaceEventArgs(int index)
        {
            Index = index;            
        }

        public WorkspaceEventArgs(string name, int index):this(name)
        {
            Index = index;
        }
    }
}
