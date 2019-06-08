using System.Collections.Generic;

namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет класс рабочей зоны плеча робота-манипулятора.
    /// </summary>
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

        /// <summary>
        /// Предоставляет класс рабочей зоны плеча робота-манипулятора.
        /// </summary>
        /// <param name="abmin">Минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.</param>
        /// <param name="abmax">Максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.</param>
        /// <param name="abzero">Расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, которое является нулевой точкой отсчета, мм.</param>
        public LeverWorkspace(double abmin, double abmax, double? abzero)
        {
            ABmax = abmax;
            ABmin = abmin;
            ABzero = abzero;
        }
         
        /// <summary>
        /// Возвращает коллекцию ошибок связанных с констркутивными параметрами или ограничениями рабочей зоны в зависимости 
        /// от текущего положения <paramref name="ab"/> и рабочей зоны <paramref name="workspace"/>.
        /// </summary>
        public static IEnumerable<DesignParametersException> GetDesignParametersExceptions(double ab, IWorkspace workspace)
        {
            if (workspace.ABmax < workspace.ABmin)
                yield return new DesignParametersException("Минимально допустимое значение не может быть больше максимально допустимого значения");
              /*
            if (!(ab >= workspace.ABmin && ab <= workspace.ABmax))
                yield return new DesignParametersException("Значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет установленной рабочей зоне");
                    */
            if (workspace.ABzero != null && !(workspace.ABzero >= workspace.ABmin && workspace.ABzero <= workspace.ABmax))
                yield return new DesignParametersException("Значение расстояния нулевой точки не удовлетворяет установленной рабочей зоне");
        }

        /// <summary>
        /// Возвращает коллекцию ошибок связанных с констркутивными параметрами или ограничениями рабочей зоны в зависимости 
        /// от конструктивных параметров подвижной части робота <paramref name="movableLeverPart"/>.
        /// </summary>
        public static IEnumerable<DesignParametersException> GetDesignParametersExceptions(IPartMovable movableLeverPart)
        {
            return GetDesignParametersExceptions(movableLeverPart.AB, movableLeverPart);
        }

        /// <summary>
        /// Создает новый объект, являющийся копией текущего экземпляра.
        /// </summary>
        /// <returns>Новый объект, являющийся копией текущего экземпляра.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
