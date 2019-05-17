using System;

namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет класс, содержащий свойства конструктивных параметров робота.
    /// </summary>
    public class DesignParameters
    {
        #region Свойства.

        /// <summary>
        /// Возвращает длину плеча 1, мм.
        /// </summary>
        public double L1 { get; private set; }
        
        /// <summary>
        /// Возвращает длину плеча 2, мм.
        /// </summary>
        public double L2 { get; private set; }
        
        /// <summary>
        /// Возвращает расстояние от центра схвата до точки его подвеса на плече 2, мм.
        /// </summary>
        public double Lc { get; private set; }

        #region Конструктивные параметры плеч манипулятора. 

        /// <summary>
        /// Возвращает конструктивные параметры для расчета перемещения робота по подвесной балке.
        /// </summary>
        public HorizontalLeverDesignParameters HorizontalLever { get; private set; }

        /// <summary>
        /// Возвращает конструктивные параметры для расчета угла φ1 (плечо 1).
        /// </summary>
        public LeverDesignParameters Lever1 { get; private set; }

        /// <summary>
        /// Возвращает конструктивные параметры для расчета угла φ2 (плечо 2).
        /// </summary>
        public LeverDesignParameters Lever2 { get; private set; }

        #endregion

        #endregion

        #region Конструкторы.

        /// <summary>
        /// Предоставляет класс, содержащий свойства конструктивных параметров робота.
        /// </summary>
        /// <param name="l1">Длина плеча 1, мм.</param>
        /// <param name="l2">Длина плеча 2, мм.</param>
        /// <param name="lc">Расстояние от центра схвата до точки его подвеса на плече 2, мм.</param>
        /// <param name="horizontalLever">Конструктивные параметры для расчета горизонтального перемещения.</param>
        /// <param name="dpPhi1">Конструктивные параметры для расчета угла φ1 (плечо 1).</param>
        /// <param name="dpPhi2">Конструктивные параметры для расчета угла φ1 (плечо 2).</param>
        public DesignParameters(double l1, double l2, double lc, HorizontalLeverDesignParameters horizontalLever, LeverDesignParameters lever1, LeverDesignParameters lever2)
        {
            this.L1 = l1;
            this.L2 = l2;
            this.Lc = lc;
            this.HorizontalLever = horizontalLever;
            this.Lever1 = lever1;
            this.Lever2 = lever2;
        }
        #endregion
    }
}