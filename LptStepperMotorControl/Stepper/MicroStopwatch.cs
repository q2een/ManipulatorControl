using System;

namespace LptStepperMotorControl.Stepper
{
    /// <summary>
    /// Предоставляет класс микросекундомера.
    /// </summary>
    public class MicroStopwatch : System.Diagnostics.Stopwatch
    {
        /// <summary>
        /// Возвращает количество микросекунд на один такт. 
        /// </summary>
        readonly double microSecPerTick = 1000000D / Frequency;

        /// <summary>
        /// Предоставляет класс микросекундомера.
        /// </summary>
        public MicroStopwatch()
        {
            if (!IsHighResolution)
            {
                throw new Exception("Счетчик производительности высокого разрешения недоступен для данной системы");
            }
        }

        /// <summary>
        /// Возвращает затраченное количество микросекунд.
        /// </summary>
        public long ElapsedMicroseconds
        {
            get
            {
                return (long)(ElapsedTicks * this.microSecPerTick);
            }
        }
    }
}
