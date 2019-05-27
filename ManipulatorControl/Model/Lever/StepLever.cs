using System;

namespace ManipulatorControl
{
    public class StepLever : EventArgs
    {
        public LeverType Lever { get; private set; }

        public long StepsCount { get; set; }

        public StepLever(LeverType lever, long stepsCount)
        {
            Lever = lever;
            StepsCount = stepsCount;
        }
    }
}
