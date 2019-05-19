namespace UM160CalculationLib
{
    public abstract class RobotLeverDesignParameters: LeverWorkspace, IRobotLever
    {
        private IPartMovable workspace;

        public virtual IPartMovable Workspace
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

        private double ab;

        public override double AB
        {
            get
            {
                return ab;
            }
            set
            {                    
                if (!IsNewABValueCorrect(value))
                    throw new DesignParametersException("Новое значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет конструктивным параметрам робота");


                if (Workspace != this && !workspace.IsNewABValueCorrect(value))
                   throw new DesignParametersException("Новое значение расстояния от оси подвеса ходового винта до точки крепления плеча к гайке ходового винта не удовлетворяет установленной рабочей зоне");

                if(Workspace != this)
                    workspace.AB = value;

                ab = value;
            }
        }

        public RobotLeverDesignParameters(double AB, double abmin, double abmax) : base(AB, abmin, abmax)
        {
        }
    }
}
