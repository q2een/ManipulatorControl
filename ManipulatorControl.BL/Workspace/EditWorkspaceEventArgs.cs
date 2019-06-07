using System;

namespace ManipulatorControl.BL.Workspace
{
    public class EditWorkspaceEventArgs: EventArgs
    {
        public LeverType LeverType { get; set; }

        public MovableValueTypes ValueType { get; set; }

        public EditWorkspaceEventArgs(LeverType leverType, MovableValueTypes valueType)
        {
            LeverType = leverType;
            ValueType = valueType;
        }
    }
}
