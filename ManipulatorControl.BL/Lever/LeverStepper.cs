using LptStepperMotorControl.Stepper;

namespace ManipulatorControl.BL
{
    /// <summary>
    /// Предоставляет класс содержащий информацию о шаговом двигателе, который приводит в движение плечо.
    /// </summary>
    public class LeverStepper
    {
        /// <summary>
        /// Возвращает тип плеча робота-манипулятора.
        /// </summary>
        public LeverType Type { get; private set; }

        /// <summary>
        /// Возвращает или задает экземпляр класса для управления шаговым двигателем.
        /// </summary>
        public StepperMotor Stepper { get; set; }

        /// <summary>
        /// Предоставляет класс содержащий информацию о шаговом двигателе, который приводит в движение плечо
        /// </summary>
        /// <param name="type">Тип плеча робота-манипулятора</param>
        /// <param name="stepper">Экземпляр класса для управления шаговым двигателем</param>
        public LeverStepper(LeverType type, StepperMotor stepper)
        {
            Type = type;
            Stepper = stepper;
        }
    }
}
