using System;

namespace ManipulatorControl.BL
{
    /// <summary>
    /// Предоставляет класс, содержащий данные о количестве шагов шагового двигателя, который управляет плечом.
    /// </summary>
    public class StepLever : EventArgs
    {
        /// <summary>
        /// Возвращает тип плеча.
        /// </summary>
        public LeverType Lever { get; private set; }

        /// <summary>
        /// Возвращает количество шагов.
        /// </summary>
        public long StepsCount { get; set; }

        /// <summary>
        /// Предоставляет класс, содержащий данные о количестве шагов шагового двигателя, который управляет плечом.
        /// </summary>
        /// <param name="lever">Тип плеча</param>
        /// <param name="stepsCount">Количество шагов</param>
        public StepLever(LeverType lever, long stepsCount)
        {
            Lever = lever;
            StepsCount = stepsCount;
        }
    }
}
