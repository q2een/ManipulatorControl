using LptStepperMotorControl.PortControl;
using System;

namespace LptStepperMotorControl.Stepper
{
    /// <summary>
    /// Предоставляет класс, содержащий информацию об управляющих PIN для протокола STEP/DIR/ENABLE.
    /// </summary>
    public struct StepDirPin
    {

        /// <summary>
        /// Возвращает номер управляющего PIN для сигнала STEP.
        /// </summary>
        public int Step { get; private set; }

        /// <summary>
        /// Возвращает номер управляющего PIN для сигнала DIR.
        /// </summary>
        public int Dir { get; private set; }

        /// <summary>
        /// Возвращает номер управляющего PIN для сигнала ENABLE.
        /// </summary>
        public int Enable { get; private set; }

        /// <summary>
        /// Предоставляет класс, содержащий информацию об управляющих PIN для протокола STEP/DIR/ENABLE.
        /// </summary>
        /// <param name="step">Номер управляющего PIN для сигнала STEP</param>
        /// <param name="dir">Номер управляющего PIN для сигнала DIR</param>
        /// <param name="enable">Номер управляющего PIN для сигнала ENABLE</param>
        public StepDirPin(int step, int dir, int enable)
        {
            if (step == dir || step == enable || dir == enable)
                throw new Exception("Управляющие PIN не могут повторяться");

            // Проверяет, являются ли заданные PIN управляющими.
            foreach (var pin in new[] { step, dir, enable })
                if (!LPTPort.IsOutputPin(pin))
                    throw new Exception("PIN с номером " + pin + " не является PIN вывода");

            this.Step = step;
            this.Dir = dir;
            this.Enable = enable;
        }

        public static bool operator==(StepDirPin pin1, StepDirPin pin2)
        {
            return pin1.Step == pin2.Step && pin1.Dir == pin2.Dir && pin1.Enable == pin2.Enable;
        }

        public static bool operator !=(StepDirPin pin1, StepDirPin pin2)
        {
            return !(pin1==pin2);
        }
    }
}
