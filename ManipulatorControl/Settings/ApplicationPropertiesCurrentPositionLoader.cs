using System;
using ManipulatorControl.BL;

namespace ManipulatorControl.Settings
{
    class ApplicationPropertiesCurrentPositionLoader : ICurrentPositionLoader
    {
        public double GetCurrentPosition(LeverType leverType)
        {
            if (leverType == LeverType.Horizontal)
                return Properties.Settings.Default.HorizontalLeverAB;
            if (leverType == LeverType.Lever1)
                return Properties.Settings.Default.Lever1AB;
            if (leverType == LeverType.Lever2)
                return Properties.Settings.Default.Lever2AB;

            throw new NotImplementedException("Получение текущего положения для данного плеча не реализовано");
        }

        public void SaveCurrentPosition(LeverType leverType, double currentPosition)
        {
            switch(leverType)
            {
                case LeverType.Horizontal:
                    Properties.Settings.Default.HorizontalLeverAB = currentPosition;  
                    break;
                case LeverType.Lever1:
                    Properties.Settings.Default.Lever1AB = currentPosition; 
                    break;
                case LeverType.Lever2:
                    Properties.Settings.Default.Lever2AB = currentPosition;
                    break;
                default:
                    throw new NotImplementedException("Cохранение текущего положения для данного плеча не реализовано");
            }

            Properties.Settings.Default.Save();
        }
    }
}
