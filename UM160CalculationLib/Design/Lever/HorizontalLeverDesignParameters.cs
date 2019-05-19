namespace UM160CalculationLib
{
    public class HorizontalLeverDesignParameters : RobotLeverDesignParameters
    {
        public double Coefficient { get; set; }

        public HorizontalLeverDesignParameters(double AB, double abmin, double abmax, double coefficient) : base(AB, abmin, abmax)
        {
            Coefficient = coefficient;
        }
    }
}
