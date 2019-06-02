namespace ManipulatorControl.BL
{
    public static class Extensions
    {
        public static string ToRuString(this LeverType leverType)
        {
            if (leverType == LeverType.Horizontal)
                return "Каретка робота";

            if (leverType == LeverType.Lever1)
                return "Плечо";

            if (leverType == LeverType.Lever2)
                return "Предплечье";

            return "";
        }
    }
}
