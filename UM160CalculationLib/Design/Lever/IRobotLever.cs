namespace UM160CalculationLib
{
    public interface IRobotLever : IPartMovable
    {
        IWorkspace Workspace { get; set; }

        bool IsABIncreasesOnStepperCW { get; set; }
    }
}
