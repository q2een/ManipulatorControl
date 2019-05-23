namespace UM160CalculationLib
{
    public class HorizontalLeverDesignParameters : RobotLeverDesignParameters
    {
        public double Coefficient { get; set; }

        public HorizontalLeverDesignParameters(double AB, double abmin, double abmax, double coefficient, bool isABIncreasesOnStepperCW) : base(AB, abmin, abmax, isABIncreasesOnStepperCW)
        {
            Coefficient = coefficient;
        }
    }
}
