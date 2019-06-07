﻿using System;
using System.Collections.Generic;
using UM160CalculationLib;

namespace ManipulatorControl.BL.Workspace
{
    public class RobotWorkspace : ICloneable
    {
        public string Name { get; set; }

        public IWorkspace Lever1 { get; set; }

        public IWorkspace Lever2 { get; set; }

        public IWorkspace HorizontalLever { get; set; }

        public RobotWorkspace(string name)
        {
            Name = name;
        }

        public IEnumerable<KeyValuePair<LeverType, DesignParametersException>> GetDesignParametersExceptions(DesignParameters parameters)
        {
            var exceptions = new List<KeyValuePair<LeverType, DesignParametersException>>();

            exceptions.AddRange(GetExeptions(LeverType.Horizontal, LeverWorkspace.GetDesignParametersExceptions(parameters.HorizontalLever.AB, HorizontalLever)));
            exceptions.AddRange(GetExeptions(LeverType.Lever1, LeverWorkspace.GetDesignParametersExceptions(parameters.Lever1.AB, Lever1)));
            exceptions.AddRange(GetExeptions(LeverType.Lever2, LeverWorkspace.GetDesignParametersExceptions(parameters.Lever2.AB, Lever2)));

            return exceptions;
        }

        private IEnumerable<KeyValuePair<LeverType, DesignParametersException>> GetExeptions(LeverType type, IEnumerable<DesignParametersException> exceptions)
        {
            foreach (var exception in exceptions)
                yield return new KeyValuePair<LeverType, DesignParametersException>(type, exception);                
        }

        public IWorkspace GetLeverByType(LeverType type)
        {
            switch(type)
            {
                case LeverType.Horizontal:
                    return HorizontalLever;
                case LeverType.Lever1:
                    return Lever1;
                case LeverType.Lever2:
                    return Lever2;
                default:
                    throw new NotImplementedException();                         
            }
        }

        public void SetValue(LeverType type, MovableValueType valueType, double ab)
        {
            var lever = GetLeverByType(type);

            switch(valueType)
            {
                case MovableValueType.Max:
                    lever.ABmax = ab;
                    break;

                case MovableValueType.Min:
                    lever.ABmin = ab;
                    break;

                case MovableValueType.Zero:
                    lever.ABzero = ab;
                    break;

                default: throw new NotImplementedException();   
            }
        }

        public void RemoveZero(LeverType type)
        {
            GetLeverByType(type).ABzero = null;
        }

        public object Clone()
        {
            var workspace = new RobotWorkspace(this.Name);
            workspace.HorizontalLever = this.HorizontalLever.Clone() as IWorkspace;
            workspace.Lever1 = this.Lever1.Clone() as IWorkspace;
            workspace.Lever2 = this.Lever2.Clone() as IWorkspace;

            return workspace;
        }

        public override string ToString()
        {
            return Name;                    
        }
    }
}
