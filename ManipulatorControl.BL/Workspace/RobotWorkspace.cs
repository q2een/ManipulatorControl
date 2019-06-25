using System;
using System.Collections.Generic;
using UM160CalculationLib;

namespace ManipulatorControl.BL.Workspace
{
    /// <summary>
    /// Предоставляет класс рабочей зоны робота.
    /// </summary>
    public class RobotWorkspace : ICloneable
    {
        /// <summary>
        /// Возвращает или задает наименование рабочей зоны роботы.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает рабочую зону плеча.
        /// </summary>
        public IWorkspace Lever1 { get; set; }

        /// <summary>
        /// Возвращает или задает рабочую зону предплечья.
        /// </summary>
        public IWorkspace Lever2 { get; set; }

        /// <summary>
        /// Возвращает или задает рабочую зону каретки робота.
        /// </summary>
        public IWorkspace HorizontalLever { get; set; }

        /// <summary>
        /// Предоставляет класс рабочей зоны робота.
        /// </summary>
        /// <param name="name">Наименование рабочей зоны роботы</param>
        public RobotWorkspace(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Возвращает ошибки, связанные с данной рабочей зоной.
        /// </summary>
        /// <param name="parameters">Уонструктивные параметры робота</param>
        /// <returns>Коллекция ошибок</returns>
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

        /// <summary>
        /// Возвращает экземпляр класса рабочей зоны плеча на основе его типа <paramref name="type"/>.
        /// </summary>
        /// <returns>Экземпляр класса рабочей зоны плеча</returns>
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

        /// <summary>
        /// Устанавливает новое значение для рабочей зоны плеча.
        /// </summary>
        /// <param name="type">Тип плеча</param>
        /// <param name="valueType">Тип значения</param>
        /// <param name="ab">Новое значение</param>
        public void SetValue(LeverType type, MovableValueTypes valueType, double ab)
        {
            var lever = GetLeverByType(type);

            switch(valueType)
            {
                case MovableValueTypes.Max:
                    lever.ABmax = ab;
                    break;

                case MovableValueTypes.Min:
                    lever.ABmin = ab;
                    break;

                case MovableValueTypes.Zero:
                    lever.ABzero = ab;
                    break;

                default: throw new NotImplementedException();   
            }
        }

        /// <summary>
        /// Удаляет нулевое положение плеча с типом <paramref name="type"/>.
        /// </summary>
        public void RemoveZero(LeverType type)
        {
            GetLeverByType(type).ABzero = null;
        }

        /// <summary>
        /// Создает новый объект, являющийся копией текущего экземпляра.
        /// </summary>
        /// <returns>Новый объект, являющийся копией текущего экземпляра.</returns>
        public object Clone()
        {
            var workspace = new RobotWorkspace(this.Name);
            workspace.HorizontalLever = this.HorizontalLever.Clone() as IWorkspace;
            workspace.Lever1 = this.Lever1.Clone() as IWorkspace;
            workspace.Lever2 = this.Lever2.Clone() as IWorkspace;

            return workspace;
        }

        /// <summary>
        /// Возвращает строку, представляющую текущий объект
        /// </summary>
        /// <returns>Строку, представляющую текущий объект</returns>
        public override string ToString()
        {
            return Name;                    
        }
    }
}
