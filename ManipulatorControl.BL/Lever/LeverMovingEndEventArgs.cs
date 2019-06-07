using LptStepperMotorControl.Stepper;

namespace ManipulatorControl.BL
{
    /// <summary>
    /// Предоставляет класс, содержащий данные о событии окончания движения плеча робота.
    /// </summary>
    public class LeverMovingEndEventArgs : StepLever
    {
        /// <summary>
        /// Возвращает причину окончания движения плеча робота. 
        /// </summary>
        public StepperStopReason StopReason { get; private set;}

        /// <summary>
        /// Предоставляет класс, содержащий данные о событии окончания движения плеча робота.
        /// </summary>
        /// <param name="leverType">Тип плеча</param>
        /// <param name="stepsCount">Количество шагов</param>
        /// <param name="stopReason">Причина окончания движения плеча робота</param>
        public LeverMovingEndEventArgs(LeverType leverType, long stepsCount, StepperStopReason stopReason) : base(leverType, stepsCount)
        {
            StopReason = stopReason;
        }

        /// <summary>
        /// Предоставляет класс, содержащий данные о событии окончания движения плеча робота
        /// </summary>
        /// <param name="stepLever">Экземпляр класса, содержащий данные о количестве шагов шагового двигателя, который управляет плечом.</param>
        /// <param name="stopReason">Причина окончания движения плеча робота</param>
        public LeverMovingEndEventArgs(StepLever stepLever, StepperStopReason stopReason) : this(stepLever.Lever, stepLever.StepsCount, stopReason)
        {
        }
    }
}
