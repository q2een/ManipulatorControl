using System;

namespace ManipulatorControl.BL.Workspace
{
    public class EditWorkspaceEventArgs: EventArgs
    {
        public LeverType LeverType { get; set; }

        public MovableValueType ValueType { get; set; }

        public EditWorkspaceEventArgs(LeverType leverType, MovableValueType valueType)
        {
            LeverType = leverType;
            ValueType = valueType;
        }
    }
}
