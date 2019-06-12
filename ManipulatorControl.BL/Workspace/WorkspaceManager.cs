using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UM160CalculationLib;

namespace ManipulatorControl.BL.Workspace
{
    /// <summary>
    /// Предоставляет класс для управления рабочими зонами робота-манипулятора. 
    /// </summary>
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

        /// <summary>
        /// Происходит при изменени активной рабочей зоны робота-манипулятора.
        /// </summary>
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

        public RobotWorkspace DesignParametersWorkspace
        {
            get
            {
                return robotWorkspaces != null && robotWorkspaces.Count > 0 ? robotWorkspaces[0] : null;
            }
            set
            {
                robotWorkspaces[0] = GetDesignParametersWorkspace("Конструктивные параметры");
            }
        }

        public WorkspaceManager(DesignParameters parameters, List<RobotWorkspace> robotWorkspaces, int activeWorkspaceIndex = 0)
        {
            this.parameters = parameters;

            Add(GetDesignParametersWorkspace("Конструктивные параметры"));

            if (robotWorkspaces != null)
                this.robotWorkspaces.AddRange(robotWorkspaces);

            ActiveWorkspace = this.robotWorkspaces[activeWorkspaceIndex];
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
            if (!robotWorkspaces.Contains(robotWorkspace))
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

        public void SetValue(IWorkspace workspace, MovableValueTypes valueType, double ab)
        {
            switch (valueType)
            {
                case MovableValueTypes.Max:
                    workspace.ABmax = ab;
                    break;

                case MovableValueTypes.Min:
                    workspace.ABmin = ab;
                    break;

                case MovableValueTypes.Zero:
                    workspace.ABzero = ab;
                    break;

                default: throw new ArgumentException("Тип значения не корректен");
            }
        }

        /// <summary>
        /// Возвращает истину, если текущее положение плеч робота-манипулятора соответствует рабочей зоне <paramref name="workspace"/>.
        /// </summary>
        /// <param name="workspace">Рабочая зона</param>
        /// <returns>Истина, если текущее положение плеч робота-манипулятора соответствует рабочей зоне</returns>
        public bool IsRobotInWorkspace(RobotWorkspace workspace)
        {
            var horizontal = workspace.HorizontalLever.IsBetweenMinAndMax(parameters.HorizontalLever.AB);
            var lever1 = workspace.Lever1.IsBetweenMinAndMax(parameters.Lever1.AB);
            var lever2 = workspace.Lever2.IsBetweenMinAndMax(parameters.Lever2.AB);

            return horizontal && lever1 && lever2;
        }

        /// <summary>
        /// Возвращает тип плеч, которые не расположены в пределах рабочей зоны <paramref name="workspace"/>.
        /// </summary>
        /// <param name="workspace">Рабочая зона</param>
        /// <returns>Коллекция типов плеч, которые не расположены в рабочей зоне</returns>
        public IEnumerable<LeverType> GetLeversOutOfWorkspaceRange(RobotWorkspace workspace)
        {
            if (!workspace.HorizontalLever.IsBetweenMinAndMax(parameters.HorizontalLever.AB))
                yield return LeverType.Horizontal;

            if (!workspace.Lever1.IsBetweenMinAndMax(parameters.Lever1.AB))
                yield return LeverType.Lever1;

            if (!workspace.Lever2.IsBetweenMinAndMax(parameters.Lever2.AB))
                yield return LeverType.Lever2;
        }

        /// <summary>
        /// Возвращает коллекцию положений плеч, которых необходимо достичь плечу чтобы оказаться
        /// в пределах рабочей зоны <paramref name="workspace"/>.
        /// </summary>
        /// <param name="workspace">Рабочая зона</param>
        /// <returns>Коллекция положений плеч, которых необходимо достичь плечу чтобы оказаться в пределах рабочей зоны</returns>
        public IEnumerable<LeverPosition> GetLeversPositionToWorkspaceRange(RobotWorkspace workspace)
        {
            if (!workspace.HorizontalLever.IsBetweenMinAndMax(parameters.HorizontalLever.AB))
                yield return new LeverPosition(LeverType.Horizontal, GetNearestPositionInWorkspace(workspace.HorizontalLever,parameters.HorizontalLever.AB));

            if (!workspace.Lever1.IsBetweenMinAndMax(parameters.Lever1.AB))
                yield return new LeverPosition(LeverType.Lever1, GetNearestPositionInWorkspace(workspace.Lever1, parameters.Lever1.AB));

            if (!workspace.Lever2.IsBetweenMinAndMax(parameters.Lever2.AB))
                yield return new LeverPosition(LeverType.Lever2, GetNearestPositionInWorkspace(workspace.Lever2, parameters.Lever2.AB));
        }

        /// <summary>
        /// Возвращает коллекцию положений плеч, которых необходимо достичь плечу чтобы оказаться
        /// в нулевой точке рабочей зоны <paramref name="workspace"/>.
        /// </summary>
        /// <param name="workspace">Рабочая зона</param>
        /// <returns>Коллекция положений плеч, которых необходимо достичь плечу чтобы оказаться в нулевой точке рабочей зоны</returns>
        public IEnumerable<LeverPosition> GetLeverPositionsToWorkspaceZero(RobotWorkspace workspace)
        {
            if (workspace.HorizontalLever.ABzero == null)
                throw new DesignParametersException(LeverType.Horizontal.ToRuString() + ": не задана нулевая точка. Перемещение невозможно");
            else
                yield return new LeverPosition(LeverType.Horizontal, (double)workspace.HorizontalLever.ABzero);

            if (workspace.Lever1.ABzero == null)
                throw new DesignParametersException(LeverType.Lever1.ToRuString() + ": не задана нулевая точка. Перемещение невозможно");
            else
                yield return new LeverPosition(LeverType.Lever1, (double)workspace.Lever1.ABzero);

            if (workspace.Lever2.ABzero == null)
                throw new DesignParametersException(LeverType.Lever2.ToRuString() + ": не задана нулевая точка. Перемещение невозможно");
            else
                yield return new LeverPosition(LeverType.Lever2, (double)workspace.Lever2.ABzero);
        }

        /// <summary>
        /// Возвращает ближайшую к положению <paramref name="position"/> точку рабочей зоны <paramref name="workspace"/>.
        /// </summary>
        /// <param name="workspace">Рабочая зона плеча</param>
        /// <param name="position">Положения плеча</param>
        /// <returns>Ближайшая к положению <paramref name="position"/> точка рабочей зоны</returns>
        public double GetNearestPositionInWorkspace(IWorkspace workspace, double position)
        {
            var a = Math.Abs(position - workspace.ABmax);
            var b = Math.Abs(position - workspace.ABmin);

            return a < b ? workspace.ABmax : workspace.ABmin;
        }

        /// <summary>
        /// Устанавливает рабочую зону с заданным индексом в качестве активной.
        /// </summary>
        /// <param name="index">Индекс рабочей зоны</param>
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

        public static void RemoveWorkspacesFromDesignParameters(DesignParameters parameters)
        {
            parameters.Lever1.Workspace = null;
            parameters.Lever2.Workspace = null;
            parameters.HorizontalLever.Workspace = null;
        }

    }
}
