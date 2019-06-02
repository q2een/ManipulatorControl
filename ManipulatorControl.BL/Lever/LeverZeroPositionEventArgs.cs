using System;

namespace ManipulatorControl.BL
{
    public class LeverZeroPositionEventArgs : EventArgs
    {
        public LeverType LeverType { get; private set; }

        public bool IsOnZeroPosition { get; private set; }

        public LeverZeroPositionEventArgs(LeverType leverType, bool isOnZeroPosition)
        {
            LeverType = leverType;
            IsOnZeroPosition = isOnZeroPosition;                
        }                                                                             
    }
}
