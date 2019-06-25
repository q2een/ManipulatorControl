namespace ManipulatorControl.BL
{
    /// <summary>
    /// Предоставляет статический класс с методами расширений.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Возвращает наименование подвижного звена робота на русском языке.
        /// </summary>
        /// <param name="leverType">Тип звена</param>
        /// <returns>Наименование подвижного звена робота на русском языке</returns>
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
