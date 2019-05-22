using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM160CalculationLib;

namespace ManipulatorControl.Model
{
    public class RobotWorkspace
    {
        public string Name { get; set; }

        public IPartMovable Lever1Workspace { get; set; }

        public IPartMovable Lever2Workspace { get; set; }

        public IPartMovable HorizontalLeverWorkspace { get; set; }

        public IPartMovable GetLeverByType(LeverType type)
        {
            switch(type)
            {
                case LeverType.Horizontal:
                    return HorizontalLeverWorkspace;
                case LeverType.Lever1:
                    return Lever1Workspace;
                case LeverType.Lever2:
                    return Lever2Workspace;
                default:
                    throw new NotImplementedException();                         
            }
        }


        public void SetValue(LeverType type, MovableValueType valueType)
        {
            var lever = GetLeverByType(type);

            switch(valueType)
            {
                case MovableValueType.Max:
                    lever.ABmax = lever.AB;
                    break;

                case MovableValueType.Min:
                    lever.ABmin = lever.AB;
                    break;

                case MovableValueType.Zero:
                    lever.ABzero = lever.AB;
                    break;

                case MovableValueType.None:

                    // Сохранение: 

                    break;

                default: throw new NotImplementedException();   
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
