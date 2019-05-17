using System;

namespace ManipulatorControl
{
    [Flags]
    public enum CoordinateDirections
    {
        None = 1,
        XNone = 2,
        XPositive = 4,
        XNegative = 8,
        XZero = 16,
        YNone = 32,
        YPositive = 64,
        YNegative = 128,
        YZero = 256,
        ZNone = 512,
        ZPositive = 1024,
        ZNegative = 2048,
        ZZero = 4096,
        OnXZero = 8192,
        OnYZero = 16384,
        OnZZero = 32768
    }
}
