namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет класс, содержащий свойства описывающие конструктивные параметры каретки робота-манипулятора. 
    /// </summary>
    public class HorizontalLeverDesignParameters : RobotLever
    {
        /// <summary>
        /// Возвращает или задает коэффициент, указывающий количество шагов шагового двигателя необходимых для изменения значения 
        /// <see cref="this.AB"/> на 1 мм.
        /// </summary>
        public double Coefficient { get; set; }

        /// <summary>
        /// Предоставляет класс, содержащий свойства описывающие конструктивные параметры горизонтального плеча робота-манипулятора. 
        /// </summary>
        /// <param name="isABIncreasesOnStepperCW">Флаг указывающий увеличивается ли значение AB при движении ротора ШД по часовой стрелке</param>
        /// <param name="coefficient">Коэффициент, указывающий количество шагов шагового двигателя необходимых для изменения значения</param>
        /// <param name="ab">Текущее расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abmin">Минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abmax">Максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abzero">Расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта являющееся нулевой точкой отсчета, мм</param>
        public HorizontalLeverDesignParameters(bool isABIncreasesOnStepperCW, double coefficient, double ab, double abmin, double abmax, double? abzero = null) 
            : base(isABIncreasesOnStepperCW, ab, abmin, abmax, abzero)
        {
            Coefficient = coefficient;
        }
    }
}
