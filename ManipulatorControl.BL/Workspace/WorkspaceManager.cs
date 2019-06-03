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
        private readonly DesignParameters parameters;

        private RobotWorkspace activeWorkspace;
        private List<RobotWorkspace> robotWorkspaces = new List<RobotWorkspace>();

        public ReadOnlyCollection<RobotWorkspace> RobotWorkspaces
        {
            get
            {
                return robotWorkspaces.AsReadOnly();
            }
        }

        public event EventHandler OnActiveWorkspaceChanged = delegate { };

        public RobotWorkspace ActiveWorkspace
        {
            get
            {
                return activeWorkspace ?? robotWorkspaces[0];
            }
            set
            {                   
                SetActiveWorkspace(value ?? robotWorkspaces[0]);
            }
        }

        public int ActiveWorkspaceIndex
        {
            get
            {
                return RobotWorkspaces.IndexOf(ActiveWorkspace);
            }
        }
        
        public WorkspaceManager(DesignParameters parameters, List<RobotWorkspace> robotWorkspaces, RobotWorkspace activeWorkspace = null)
        {
            this.parameters = parameters;                              

            Add(GetDesignParametersWorkspace("Конструктивные параметры"));

            if (robotWorkspaces != null)
                this.robotWorkspaces.AddRange(robotWorkspaces);

            ActiveWorkspace = activeWorkspace ?? this.robotWorkspaces[0];
        }

        public void Add(string name)
        {
            name = name.Replace("\n", " ").Trim();
            if (name.Length < 3)
                throw new ArgumentException("Имя рабочей зоны должно содержать, как минимум, три символа");

            var workspace = GetDesignParametersWorkspaceClone(name);

            robotWorkspaces.Add(workspace);
        }

        public void Add(RobotWorkspace robotWorkspace)
        {
            if(!robotWorkspaces.Contains(robotWorkspace))
                robotWorkspaces.Add(robotWorkspace);
        }

        public void Rename(int index, string name)
        {
            if (index == -1)
                throw new Exception("Заданная рабочая зона не найдена");

            if (index == 0)
                throw new Exception("Нельзя переименовать данную рабочую зону");

            name = name.Replace("\n", " ").Trim();
            if (name.Length < 3)
                throw new ArgumentException("Имя рабочей зоны должно содержать, как минимум, три символа");

            robotWorkspaces[index].Name = name;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > robotWorkspaces.Count - 1)
                throw new Exception("Заданная рабочая зона не найдена");

            if (index == 0)
                throw new Exception("Нельзя удалить данную рабочую зону");

            if (index == ActiveWorkspaceIndex)
            {
                ActiveWorkspace = null;
            }

            robotWorkspaces.RemoveAt(index);
        }

        public void Remove(RobotWorkspace workspace)
        {
            Remove(robotWorkspaces.IndexOf(workspace));
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
        
        public bool IsRobotInWorkspace(RobotWorkspace workspace)
        {
            var horizontal = workspace.HorizontalLever.IsBetweenMinAndMax(parameters.HorizontalLever.AB);
            var lever1 = workspace.Lever1.IsBetweenMinAndMax(parameters.Lever1.AB);                     
            var lever2 = workspace.Lever2.IsBetweenMinAndMax(parameters.Lever2.AB);

            return horizontal && lever1 && lever2;
        }

        public static void RemoveWorkspacesFromDesignParameters(DesignParameters parameters)
        {
            parameters.Lever1.Workspace = null;
            parameters.Lever2.Workspace = null;
            parameters.HorizontalLever.Workspace = null;
        }

        public IEnumerable<LeverType> GetLeversOutOfWorkspaceRange(RobotWorkspace workspace)
        {
            if (!workspace.HorizontalLever.IsBetweenMinAndMax(parameters.HorizontalLever.AB))
                yield return LeverType.Horizontal;

            if (!workspace.Lever1.IsBetweenMinAndMax(parameters.Lever1.AB))
                yield return LeverType.Lever1;

            if (!workspace.Lever2.IsBetweenMinAndMax(parameters.Lever2.AB))
                yield return LeverType.Lever2;
        }

        public IEnumerable<LeverPosition> GetLeverPositionsToWorkspaceZero(RobotWorkspace workspace)
        {
            if (workspace.HorizontalLever.ABzero == null)
                throw new DesignParametersException(LeverType.Horizontal.ToRuString() + ": не задана нулевая точка. Перемещение невозможно");
            else yield return new LeverPosition(LeverType.Horizontal, (double)workspace.HorizontalLever.ABzero);

            if (workspace.Lever1.ABzero == null)
                throw new DesignParametersException(LeverType.Lever1.ToRuString() + ": не задана нулевая точка. Перемещение невозможно");
            else yield return new LeverPosition(LeverType.Lever1, (double)workspace.Lever1.ABzero);

            if (workspace.Lever2.ABzero == null)
                throw new DesignParametersException(LeverType.Lever2.ToRuString() + ": не задана нулевая точка. Перемещение невозможно");
            else yield return new LeverPosition(LeverType.Lever2, (double)workspace.Lever2.ABzero);
        }

        public void SetActiveWorkspace(int index)
        {
            SetActiveWorkspace(robotWorkspaces[index]);
        }

        public void SetWorkspace(int index, RobotWorkspace workspace)
        {
            robotWorkspaces[index] = workspace;
        }

        // Устанавливает заданную рабочую зону в качестве активной рабочей зоны.
        private void SetActiveWorkspace(RobotWorkspace workspace)
        {
            var outOfRange = GetLeversOutOfWorkspaceRange(workspace).Select(lever => lever.ToRuString());

            if (outOfRange.Count() != 0)
                throw new ArgumentException("Текущее положение плеч робота находится вне рабочей зоны. " + 
                                            "Необходимо переместить следующие механизмы робота:\n" + string.Join("\n", outOfRange).Trim());

            if (!robotWorkspaces.Contains(workspace))
                robotWorkspaces.Add(workspace);

            parameters.Lever1.Workspace = workspace.Lever1;
            parameters.Lever2.Workspace = workspace.Lever2;
            parameters.HorizontalLever.Workspace = workspace.HorizontalLever;

            activeWorkspace = workspace;

            OnActiveWorkspaceChanged(this, EventArgs.Empty);
        }

        public RobotWorkspace GetClone(int index)
        {
            return robotWorkspaces[index].Clone() as RobotWorkspace;
        }

        // Устанавливает в качестве рабочей зоны конструктивные параметры робота.
        public void SetDefaultWorkspace()
        {
            RemoveWorkspacesFromDesignParameters(this.parameters);
            this.activeWorkspace = null;
        }

        // Возвращает копию рабочей зоны соответствующую конструктивным параметрам робота.
        public RobotWorkspace GetDesignParametersWorkspaceClone(string name)
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
        public RobotWorkspace GetDesignParametersWorkspace(string name)
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

        private bool IsWorkspaceInMovableRange(IWorkspace workspace, IPartMovable lever)
        {
            return workspace.ABmin >= lever.ABmin && workspace.ABmax <= lever.ABmax;
        }
    }
}
