namespace UM160CalculationLib
{
    public abstract class RobotLever: LeverWorkspace, IRobotLever
    {
        private IWorkspace workspace;
        private double ab;

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

        ///// <summary>
        ///// Возвращает или задает расстояние от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта, мм.
        ///// </summary>
        public double AB
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

        public virtual bool IsABIncreasesOnStepperCW { get; set; }

        public RobotLever (bool isABIncreasesOnStepperCW, double ab, double abmin, double abmax, double? abzero) : base(abmin, abmax, abzero)
        {
            AB = ab;
            IsABIncreasesOnStepperCW = isABIncreasesOnStepperCW;
        }
    }
}
