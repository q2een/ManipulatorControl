using LptStepperMotorControl.Stepper;

namespace ManipulatorControl.BL.Settings
{
    /// <summary>
    /// Предоставляет класс, содержащий свойства, описывающие выводы драйвера шаговых двигателей. 
    /// </summary>
    public class StepDirName
    {
        /// <summary>
        /// Возвращает или задает тип вывода на плате дравйвера.
        /// </summary>
        public StepDirPinType Type { get; set; }

        /// <summary>
        /// Возвращает или задает номера управляющих PIN для управления шаговым двигателем.
        /// </summary>
        public StepDirPin StepDir { get; set; }

        /// <summary>
        /// Предоставляет класс, содержащий свойства, описывающие выводы драйвера шаговых двигателей.
        /// </summary>
        /// <param name="pinType">Тип вывода на плате дравйвера</param>
        /// <param name="pins">Номера управляющих PIN для управления шаговым двигателем</param>
        public StepDirName(StepDirPinType pinType, StepDirPin pins)
        {
            Type = pinType;
            StepDir = pins;
        }

        /// <summary>
        /// Возвращает строку, представляющую текущий объект.
        /// </summary>
        /// <returns>Строка, представляющая текущий объект</returns>
        public override string ToString()
        {
            return string.Format("{0}: {1} {2} {3}", Type, StepDir.Step, StepDir.Dir, StepDir.Enable);
        }
    }
}
