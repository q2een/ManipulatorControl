namespace UM160CalculationLib
{
    public interface IRobotLever : IPartMovable
    {
        IPartMovable Workspace { get; set; }
    }
}
