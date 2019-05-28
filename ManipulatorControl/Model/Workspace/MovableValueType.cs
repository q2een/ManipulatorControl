using System;

namespace ManipulatorControl.Workspace
{
    [Flags]
    public enum MovableValueType
    {
        None = 1,
        Max = 2,
        Min = 4,
        Zero = 8,
    }
}
