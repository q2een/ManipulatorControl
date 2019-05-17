namespace ManipulatorControl
{
    public struct StepLever
    {
        public LeverType Lever { get; private set; }

        public long StepsCount { get; set; }

        public StepLever(LeverType lever, long stepsCount) : this()
        {
            Lever = lever;
            StepsCount = stepsCount;
        }
    }
}
