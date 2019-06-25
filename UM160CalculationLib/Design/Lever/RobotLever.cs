namespace UM160CalculationLib
{
    /// <summary>
    /// Предоставляет абстрактный класс содержащий свойства конструктивных параметров плеча робота-манипулятора.
    /// </summary>
    public abstract class RobotLever: LeverWorkspace, IRobotLever
    {
        private IWorkspace workspace;
        private double ab;

        /// <summary>
        /// Возвращает или задает рабочую область плеча робота-манипулятора.
        /// </summary>
        public virtual IWorkspace Workspace
        {
            get
            {
                return workspace ?? this;
            }
            set
            {
                workspace = value;
            }
        }

        /// <summary>
        /// Возвращает или задает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        /// </summary>
        public virtual double AB
        {
            get
            {
                return ab;
            }
            set
            {                    
                if (!IsBetweenMinAndMax(value))
                    throw new DesignParametersException("Новое значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет конструктивным параметрам робота");

                if (Workspace != this && !workspace.IsBetweenMinAndMax(value))
                   throw new DesignParametersException("Новое значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет установленной рабочей зоне");

                ab = value;
            }
        }

        /// <summary>
        /// Возвращает или задает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, которое является нулевой точкой отсчета, мм.
        /// </summary>
        public override double? ABzero
        {
            get
            {
                return base.ABzero;
            }
            set
            {
                if (value != null && !IsBetweenMinAndMax((double)value))
                    throw new DesignParametersException("Новое нулевое значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет конструктивным параметрам робота");


                if (Workspace != this && value != null && !workspace.IsBetweenMinAndMax((double)value))
                    throw new DesignParametersException("Новое нулевое значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет установленной рабочей зоне");

                base.ABzero = value;
            }
        }

        /// <summary>
        /// Возвращает или задает флаг указывающий увеличивается ли значение <see cref="AB"/> при движении ротора ШД по часовой стрелке.
        /// </summary>
        public virtual bool IsABIncreasesOnStepperCW { get; set; }

        /// <summary>
        /// Предоставляет абстрактный класс содержащий свойства конструктивных параметров плеча робота-манипулятора.
        /// </summary>
        /// <param name="isABIncreasesOnStepperCW">Флаг указывающий увеличивается ли значение <see cref="AB"/> при движении ротора ШД по часовой стрелке.</param>
        /// <param name="ab">Текущее расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abmin">Минимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abmax">Максимальное расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм</param>
        /// <param name="abzero">Расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта являющееся нулевой точкой отсчета, мм</param>
        public RobotLever (bool isABIncreasesOnStepperCW, double ab, double abmin, double abmax, double? abzero) : base(abmin, abmax, abzero)
        {
            AB = ab;
            IsABIncreasesOnStepperCW = isABIncreasesOnStepperCW;
        }
    }
}
