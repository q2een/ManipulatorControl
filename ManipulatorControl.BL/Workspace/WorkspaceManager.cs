using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UM160CalculationLib;

namespace ManipulatorControl.BL.Workspace
{
    public class WorkspaceManager
    {
        private int editingWorkspaceIndex = -1;

        private readonly DesignParameters parameters;

        private RobotWorkspace activeWorkspace;

        private List<RobotWorkspace> robotWorkspaces;

        public ReadOnlyCollection<RobotWorkspace> RobotWorkspaces
        {
            get
            {
                return robotWorkspaces.AsReadOnly();
            }
        }

        public RobotWorkspace ActiveWorkspace { get; set; }

        public int ActiveWorkspaceIndex
        {
            get
            {
                return RobotWorkspaces.IndexOf(ActiveWorkspace);
            }
        }

        public WorkspaceManager(DesignParameters parameters, List<RobotWorkspace> robotWorkspaces)
        {
            this.parameters = parameters;
        }

        public void Add(RobotWorkspace robotWorkspace)
        {
            robotWorkspaces.Add(robotWorkspace);
        }

        public void Rename(int index, string name)
        {
            if (name.Replace("\n", " ").Trim().Length < 3)
                throw new ArgumentException("Имя рабочей зоны должно содержать, как минимум, три символа");

            robotWorkspaces[index].Name = name;
        }

        public void SetValue(IWorkspace workspace, MovableValueType valueType, double ab)
        {
            switch (valueType)
            {
                case MovableValueType.Max:
                    workspace.ABmax = ab;
                    break;

                case MovableValueType.Min:
                    workspace.ABmin = ab;
                    break;

                case MovableValueType.Zero:
                    workspace.ABzero = ab;
                    break;

                default: throw new ArgumentException("Тип значения не корректен");
            }
        }


        private bool IsRobotInWorkspace(RobotWorkspace workspace)
        {
            var horizontal = workspace.HorizontalLever.IsBetweenMinAndMax(parameters.HorizontalLever.AB);
            var lever1 = workspace.Lever1.IsBetweenMinAndMax(parameters.Lever1.AB);                     
            var lever2 = workspace.Lever2.IsBetweenMinAndMax(parameters.Lever2.AB);

            return horizontal && lever1 && lever2;
        }

        public Queue<StepLever> StepsTo


        public static void RemoveWorkspacesFromDesignParameters(DesignParameters parameters)
        {
            parameters.Lever1.Workspace = null;
            parameters.Lever2.Workspace = null;
            parameters.HorizontalLever.Workspace = null;
        }

        // Устанавливает в качестве рабочей зоны конструктивные параметры робота.
        private void SetDefaultWorkspace()
        {
            RemoveWorkspacesFromDesignParameters(this.parameters);
            this.activeWorkspace = null;
        }

        // Возвращает копию рабочей зоны соответствующую конструктивным параметрам робота.
        private RobotWorkspace GetDesignParametersWorkspaceClone(string name)
        {
            if (parameters == null)
                return null;

            return new RobotWorkspace(name)
            {
                HorizontalLever = parameters.HorizontalLever.Clone() as LeverWorkspace,
                Lever1 = parameters.Lever1.Clone() as LeverWorkspace,
                Lever2 = parameters.Lever2.Clone() as LeverWorkspace
            };
        }

        // Возвращает копию рабочей зоны соответствующую конструктивным параметрам робота.
        private RobotWorkspace GetDesignParametersWorkspace(string name)
        {
            if (parameters == null)
                return null;

            return new RobotWorkspace(name)
            {
                HorizontalLever = parameters.HorizontalLever as IPartMovable,
                Lever1 = parameters.Lever1 as IPartMovable,
                Lever2 = parameters.Lever2 as IPartMovable
            };
        }

        // Устанавливает заданную рабочую зону в качестве активной рабочей зоны.
        private void SetActiveWorkspace(RobotWorkspace workspace)
        {   
            parameters.Lever1.Workspace = workspace.Lever1;
            parameters.Lever2.Workspace = workspace.Lever2;
            parameters.HorizontalLever.Workspace = workspace.HorizontalLever;

            activeWorkspace = workspace;
        }


        private bool IsWorkspaceInMovableRange(IWorkspace workspace, IPartMovable lever)
        {
            return workspace.ABmin >= lever.ABmin && workspace.ABmax <= lever.ABmax;
        }
    }
}
