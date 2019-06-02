namespace ManipulatorControl.BL.Script
{
    public class LeverScriptPosition
    {
        public LeverType LeverType { get; set; }

        public double From { get; set; }

        public double To { get; set; }


        public override string ToString()
        {
            return string.Format("{0}: {1} ---> {2}", LeverType.ToRuString(), From, To);
        }
    }
}
