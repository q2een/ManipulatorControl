namespace ManipulatorControl.BL.Settings
{
    /// <summary>
    /// Предоставляет класс, связывающий тип плеча с шаговым двигателем, которое его 
    /// перемещает и номерами выводов порта для управления ШД.
    /// </summary>
    public class LeverStepperSettings
    {
        /// <summary>
        /// Возвращает или задает тип плеча.
        /// </summary>
        public LeverType LeverType { get; set; }

        /// <summary>
        /// Возвращает или задает тип вывода на драйвере.
        /// </summary>
        public StepDirPinType PinType { get; set; }

        /// <summary>
        /// Возвращает илли задает объект шагового двигателя для управления перемещением.
        /// </summary>
        public LptStepperMotorControl.Stepper.StepperMotor Stepper { get; set; }

        /// <summary>
        /// Предоставляет класс, связывающий тип плеча с шаговым двигателем, которое его 
        /// перемещает и номерами выводов порта для управления ШД.
        /// </summary>
        /// <param name="type">Тип плеча</param>
        /// <param name="pinType">Тип вывода на драйвере</param>
        /// <param name="stepper">Объект шагового двигателя</param>
        public LeverStepperSettings(LeverType type, StepDirPinType pinType, LptStepperMotorControl.Stepper.StepperMotor stepper)
        {
            LeverType = type;
            PinType = pinType;
            Stepper = stepper;
        }
    }
}
