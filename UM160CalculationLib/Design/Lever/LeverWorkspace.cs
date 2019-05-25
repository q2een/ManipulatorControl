﻿using System.Collections.Generic;

namespace UM160CalculationLib
{
    public class LeverWorkspace: IWorkspace
    {
        /// <summary>
        /// Возвращает максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        public virtual double ABmax { get; set; }

        /// <summary>
        /// Возвращает минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        public virtual double ABmin { get; set; }

        /// <summary>
        /// Возвращает или задает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, которое является нулевой точкой отсчета, мм.
        /// </summary>
        public virtual double? ABzero { get; set; }

        /// <summary>
        /// Проверяет соответствует ли конструктивным параметрам новое значение расстояния от оси подвеса ходового винта 
        /// до точки крепления плеча к гайке ходового винта и возвращает результат проверки.
        /// </summary>
        /// <param name="ab">Новове значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта</param>
        /// <returns>Результат проверки нового значения на соответствие конструктивным параметрам робота</returns>
        public virtual bool IsBetweenMinAndMax(double ab)
        {
            return ab >= this.ABmin && ab <= this.ABmax;
        }
          
        public LeverWorkspace(double abmin, double abmax, double? abzero)
        {
            ABmax = abmax;
            ABmin = abmin;
            ABzero = abzero;
        }
         
        public static IEnumerable<DesignParametersException> GetDesignParametersExceptions(double ab, IWorkspace workspace)
        {
            if (workspace.ABmax < workspace.ABmin)
                yield return new DesignParametersException("Минимально допустимое значение не может быть больше максимально допустимого значения");

            if (!(ab >= workspace.ABmin && ab <= workspace.ABmax))
                yield return new DesignParametersException("Значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет установленной рабочей зоне");

            if (!(workspace.ABzero >= workspace.ABmin && workspace.ABzero <= workspace.ABmax))
                yield return new DesignParametersException("Значение расстояния нулевой точки не удовлетворяет установленной рабочей зоне");
        }

        public static IEnumerable<DesignParametersException> GetDesignParametersExceptions(IPartMovable movableLeverPart)
        {
            return GetDesignParametersExceptions(movableLeverPart.AB, movableLeverPart);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
