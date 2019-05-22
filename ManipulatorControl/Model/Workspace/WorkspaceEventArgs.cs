using System;

namespace ManipulatorControl.Model
{
    public class WorkspaceEventArgs: EventArgs
    {
        public LeverType LeverType { get; set; }

        public MovableValueType ValueType { get; set; }

        public WorkspaceEventArgs(LeverType leverType, MovableValueType valueType)
        {
            LeverType = leverType;
            ValueType = valueType;
        }
    }
}
