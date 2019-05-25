using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM160CalculationLib;

namespace ManipulatorControl.Workspace
{
    public class RobotWorkspace : ICloneable
    {
        public string Name { get; set; }

        public IPartMovable Lever1Workspace { get; set; }

        public IPartMovable Lever2Workspace { get; set; }

        public IPartMovable HorizontalLeverWorkspace { get; set; }

        public RobotWorkspace(string name)
        {
            Name = name;
        }

        public IEnumerable<KeyValuePair<LeverType, DesignParametersException>> GetDesignParametersExceptions()
        {
            var horizontal = LeverWorkspace.GetDesignParametersException(HorizontalLeverWorkspace);
            if (horizontal != null)
                yield return new KeyValuePair<LeverType, DesignParametersException>(LeverType.Horizontal, horizontal);

            var lever1 = LeverWorkspace.GetDesignParametersException(Lever1Workspace);
            if (lever1 != null)
                yield return new KeyValuePair<LeverType, DesignParametersException>(LeverType.Lever1, lever1);

            var lever2 = LeverWorkspace.GetDesignParametersException(Lever2Workspace);
            if (lever2 != null)
                yield return new KeyValuePair<LeverType, DesignParametersException>(LeverType.Lever2, lever2);
        }

        public object Clone()
        {
            var workspace = new RobotWorkspace(this.Name);
            workspace.HorizontalLeverWorkspace = (IPartMovable)this.HorizontalLeverWorkspace.Clone();
            workspace.Lever1Workspace = (IPartMovable)this.Lever1Workspace.Clone();
            workspace.Lever2Workspace = (IPartMovable)this.Lever2Workspace.Clone();

            return workspace;
        }

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
