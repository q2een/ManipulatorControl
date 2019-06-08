using ManipulatorControl.BL;

namespace ManipulatorControl.Settings
{
    public interface ICurrentPositionLoader
    {
        double GetCurrentPosition(LeverType leverType);

        void SaveCurrentPosition(LeverType leverType, double currentPosition);
    }
}
