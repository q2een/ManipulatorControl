namespace LptStepperMotorControl.Stepper
{
    /// <summary>
    /// Предоставляет тип причины остановки шагового двигателя.
    /// </summary>
    public enum StepperStopReason
    {
        /// <summary>
        /// Не задано.
        /// </summary>
        None,
        /// <summary>
        /// Шаговый двигатель отработал заданное количество шагов и выключился.
        /// </summary>
        WorkDone,
        /// <summary>
        /// Выполнение шагов было прервано.
        /// </summary>
        Aborted,
        /// <summary>
        /// Шаговый двигатель был остановлен.
        /// </summary>
        Stoped
    }
}
