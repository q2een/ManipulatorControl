using LptStepperMotorControl.PortControl;
using Newtonsoft.Json;
using System;

namespace LptStepperMotorControl.Stepper
{
    /// <summary>
    /// Предоставляет класс для управления шаговым двигателем.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class StepperMotor
    {  
        #region Свойства.

        private float speed = 0;

        /// <summary>
        /// Возвращает или задает текущую скорость вращения ротора шагового двигателя. 
        /// </summary>
        /// <remarks>
        /// Ед. измерения: шагов в секунду.
        /// Положительное значение - движение по часовой стрелке.
        /// </remarks>
        public float Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                if (value == this.speed)
                    return;

                value = Constrain(value, -this.maxSpeed, this.maxSpeed);

                if (value == 0.0)
                    StepInterval = 0;
                else
                {
                    StepInterval = (ulong)(Math.Abs(1000000.0 / value));
                    Direction = (value > 0.0) ? Direction.CW : Direction.CCW;
                }

                this.speed = value;
            }
        }

        private float maxSpeed = 1;

        /// <summary>
        /// Возвращает или задает максимально возможную скорость вращения ротора шагового двигателя.
        /// </summary>
        /// Ед. измерения: шагов в секунду.
        /// Значение должно быть больше нуля.
        /// </remarks>
        [JsonProperty]
        public float MaxSpeed
        {
            get
            {
                return this.maxSpeed;
            }
            set
            {
                value = value < 0.0 ? -value : value;

                if (this.maxSpeed == value)
                    return;

                this.maxSpeed = value;
                this.cmin = 1000000.0f / value;

                // Recompute this._n from current speed and adjust speed if accelerating or cruising (Equation 16)
                if (this.n > 0)
                {
                    this.n = (long)((this.speed * this.speed) / (2.0 * this.acceleration));
                    ComputeNewSpeed();
                }

            }
        }

        private float acceleration = 0;

        /// <summary>
        /// Возвращает или задает ускорение ШД в шагах/секунду^2. 
        /// Значение должно быть больше нуля.
        /// </summary>
        [JsonProperty]
        public float Acceleration
        {
            get
            {
                return this.acceleration;
            }
            set
            {
                if (value == 0.0 || this.acceleration == value)
                    return;

                value = value < 0.0 ? -value : value;

                // Recompute this._n per Equation 17
                this.n = (long)(this.n * (this.acceleration / value));

                // New c0 per Equation 7, with correction per Equation 15
                this.c0 = (float)(0.676 * Math.Sqrt(2.0 / value) * 1000000.0); // Equation 15
                this.acceleration = value;
                ComputeNewSpeed();
            }
        }

        /// <summary>
        /// Возвращает количество пройденных шагов.
        /// </summary>
        public long CurrentStepsCount { get; private set; }

        private long targetStepsCount;

        /// <summary>
        /// Возвращает необходимое количество шагов.
        /// </summary>
        public long TargetStepsCount
        {
            get
            {
                return targetStepsCount;
            }
            private set
            {
                if (targetStepsCount == value)
                    return;

                targetStepsCount = value;
                ComputeNewSpeed();
            }
        }

        /// <summary>
        /// Возвращает количество шагов, которое осталось пройти.
        /// </summary>
        public long StepsLeft
        {
            get
            {
                return TargetStepsCount - CurrentStepsCount;
            }
        }

        /// <summary>
        /// Возвращает интервал между шагами в микросекундах.
        /// </summary>
        /// <remarks>
        /// 0 означает, что ШД не запущен.
        /// </remarks>
        public ulong StepInterval { get; private set; }

        /// <summary>
        /// Возвращает направление движения ротора шагового двигателя.
        /// </summary>
        public Direction Direction { get; private set; }

        /// <summary>
        /// Возвращает флаг, указывающий выполняется ли движения ротора шагового двигателя.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return !(speed == 0.0 && TargetStepsCount == CurrentStepsCount);
            }
        }

        #region Свойства для управления двигателем.

        /// <summary>
        /// Вовзвращает или задает экземпляр класса для работы с портом.
        /// </summary>
        public LPTPort Port { get; set; }

        /// <summary>
        /// Возвращает или задает номера управляющих пинов для ШД.
        /// </summary>
        public StepDirPin Pins { get; set; }

        /// <summary>
        /// Возвращает или задает флаг, указывающий на направление движения ротора
        /// шагового двигателя в зависимости от поданного сигнала на пин DIR.
        /// Движение ротора по часовой стрелке при логической единице (False) или нуле (True).
        /// </summary>
        /// <remarks>
        /// Направление движения зависит от устройства. Например, для шагового двигателя при заданной логической единице 
        /// движение может осуществляться как по часовой стрелке, так и против.
        /// </remarks>
        [JsonProperty]
        public bool CWDirectionIsLogicalZero { get; set; }

        private bool enabled = false;

        /// <summary>
        /// Возвращает или задает включены ли пины для управления шаговым двигателем.
        /// </summary>
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                Port.SetPin(Pins.Enable, value);

                var pinState = value && (CWDirectionIsLogicalZero ? Direction != Direction.CW : Direction == Direction.CW);

                Port.SetPin(Pins.Dir, pinState);

                enabled = value;

                if(value)
                    this.stopwatch.Start();
                else
                    this.stopwatch.Stop();
            }
        }
        #endregion

        #endregion

        #region Конструкторы.

        /// <summary>
        /// Предоставляет класс для управления шаговым двигателем.
        /// </summary>
        /// <param name="port">Порт</param>
        /// <param name="pins">Управляющие пины</param>
        /// <param name="cwDirectionIsLogicalZero">Флаг, указывающий на направление движения ротора
        /// шагового двигателя в зависимости от поданного сигнала на пин DIR.
        /// Движение ротора по часовой стрелке при логической единице (False) или нуле (True).</param>
        public StepperMotor(LPTPort port,StepDirPin pins, bool cwDirectionIsLogicalZero = true)
        {
            CWDirectionIsLogicalZero = cwDirectionIsLogicalZero;
            Port = port;
            Pins = pins;

            this.stopwatch = new MicroStopwatch();

            Acceleration = 1;
        }

        #endregion

        /// <summary>
        /// Запускает ШД с заданной скоростью и ускорением для выполнения необходимого 
        /// количества шагов <see cref="TargetStepsCount"/>.
        /// </summary>
        /// <remarks>
        /// Необходимо запускать в цикле.
        /// </remarks>
        /// <returns>Истина, если двигатель продолжает выполнять шаги для достижения заданного количества шагов</returns>
        public bool Run()
        {
            if (RunSpeed())
                ComputeNewSpeed();

            return speed != 0.0 || StepsLeft != 0;
        }

        /// <summary>
        /// Останавливает шаговый двигатель учитывая торможение. 
        /// </summary>
        /// <remarks>
        /// НЕ отключает пин порта.
        /// </remarks>
        public void Stop()
        {
            if (Speed == 0.0)
                return;

            long stepsToStop = (long)((Speed * Speed) / (2.0 * Acceleration)) + 1;
            TargetStepsCount = CurrentStepsCount + (stepsToStop * (speed > 0 ? 1 : -1));
        }

        /// <summary>
        /// Задает количество шагов которое необходимо выполнить.
        /// </summary>
        /// <param name="targetStepsCount">Количество шагов для выполнения</param>
        public void SetStepsCount(long targetStepsCount)
        {
            CurrentStepsCount = 0;
            TargetStepsCount = targetStepsCount;
            ComputeNewSpeed();
        }

        /// <summary>
        /// Реализует шаги в соответствии с текущим интервалом.
        /// </summary>
        /// <returns>Возвращает истину, если шаг осуществлен</returns>
        private bool RunSpeed()
        {
            // Ничего не делать пока не рассчитан интервал шага.
            if (StepInterval == 0)
                return false;

            ulong time = GetElapsedTime();

            if (time - this.lastStepTime < StepInterval)
                return false;

            CurrentStepsCount += (Direction == Direction.CW ? 1 : -1);

            DoStep();

            this.lastStepTime = time;

            return true;
        }

        /// <summary>
        /// Рассчитывает новую скорость для следующего шага в соответствии с заданными параметрами.
        /// </summary>
        private void ComputeNewSpeed()
        {
            long stepsToStop = (long)((Speed * Speed) / (2.0 * Acceleration));

            if (StepsLeft == 0 && stepsToStop <= 1)
            {
                // Все шаги пройдены. Остановка ШД.
                StepInterval = 0;
                Speed = 0.0f;
                this.n = 0;
                return;
            }

            if (StepsLeft > 0)
            {
                // Для выполнения необходимого количества шагов нужно двигаться по часовой стрелке.
                // Возможно, необходимо торможение.
                if (this.n > 0)
                {
                    // Происходит ускорение. Необходимо торможение ?
                    if ((stepsToStop >= StepsLeft) || Direction == Direction.CCW)
                        // Начать торможение.
                        this.n = -stepsToStop; 
                }
                else if (this.n < 0)
                {
                    // Происходит торможение. Необходимо ускорение ?
                    if ((stepsToStop < StepsLeft) && Direction == Direction.CW)
                        // Начать ускорение.
                        this.n = -this.n; 
                }
            }
            else if (StepsLeft < 0)
            {
                // Для выполнения необходимого количества шагов нужно двигаться против часовой стрелки.
                // Возможно, необходимо торможение.
                if (this.n > 0)
                {
                    // Происходит ускорение. Необходимо торможение ?
                    if ((stepsToStop >= -StepsLeft) || Direction == Direction.CW)
                        // Начать торможение.
                        this.n = -stepsToStop; 
                }
                else if (this.n < 0)
                {
                    // Происходит торможение. Необходимо ускорение ?
                    if ((stepsToStop < -StepsLeft) && Direction == Direction.CCW)
                        // Начать ускорение.
                        this.n = -this.n; 
                }
            }

            // Необходимо ускорение или торможение.
            if (this.n == 0)
            {
                // Первый шаг.
                this.cn = this.c0;
                Direction = (StepsLeft > 0) ? Direction.CW : Direction.CCW;
            }
            else
            {
                // Последующий шаг. Работает для ускорения и торможения.
                this.cn = this.cn - ((2.0f * this.cn) / ((4.0f * this.n) + 1));
                this.cn = Math.Max(this.cn, this.cmin);
            }

            this.n++;
            StepInterval = (ulong)this.cn;
            speed = 1000000.0f / this.cn;

            speed = Direction == Direction.CCW ? -speed : speed;
        }

        /// <summary>
        /// Формирует меандр - импульс для осуществления шага шаговым двигателем.
        /// </summary>
        private void DoStep()
        {
            Port.SetPin(Pins.Step, true);

            // Имитация задержки.
            var hightLevel = GetElapsedTime();             
            while (GetElapsedTime()- hightLevel < StepInterval/2)
            {
                System.Threading.Thread.SpinWait(10);
            }

            Port.SetPin(Pins.Step, false);
        }

        #region Вспомогательные методы.

        // Функция проверяет и если надо задает новое значение, так чтобы оно была в области допустимых значений, заданной параметрами.
        private float Constrain(float x, float a, float b)
        {
            if (x < a)
                return a;

            if (x > b)
                return b;

            return x;
        }
        
        // Возвращает пройденное время от момента запуска шагового двигателя.
        private ulong GetElapsedTime()
        {
            return (ulong)this.stopwatch.ElapsedMicroseconds;
        }

        #endregion

        #region Поля.

        // Время последнего шага в микросекундах. 
        private ulong lastStepTime = 0;

        // Счетчик шагов для расчета скорости. 
        private long n = 0;

        // Исходный значение времени шага в микросекундах. 
        private float c0 = 0;

        // Размер последнего шага в микросекундах. 
        private float cn = 0;

        // Минимальный размер шага в микросекундах, основанный на максимальной скорости. При максимальной скорости == 1.
        private float cmin = 2;

        // Экземпляр секундомера (измерения в микросекундах). 
        private readonly MicroStopwatch stopwatch;

        #endregion

    }
}
