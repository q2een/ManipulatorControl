using System;
using System.Threading;

namespace LptStepperMotorControl.Stepper
{
    /// <summary>
    /// Предоставляет класс для запуска шагового двигателя. Позволяет обращаться 
    /// к экземпляру шагового двигателя в цикле в отдельном потоке. 
    /// За генерацию импульсов, рассчет значений скорости и ускорения отвечает <see cref="StepperMotor"/>.
    /// </summary>
    public class StepperWorker
    {
        #region Свойства.

        /// <summary>
        /// Возвращает или задает экземпляр класса шагового двигателя.
        /// </summary>
        public StepperMotor Stepper { get; set; }

        /// <summary>
        /// Возвращает причину остановки.
        /// </summary>
        public StepperStopReason StopReason { get; private set; }

        /// <summary>
        /// Возвращает или задает интервал (в шагах) через который будет вызываться событие <see cref="Elapsed"/>.
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// Возвращает или задает флаг указывающий на работу шагового двигателя. 
        /// </summary>
        public bool Enabled
        {
            set
            {
                if (value)
                {
                    Start();
                }
                else
                {
                    Stop();
                }
            }
            get
            {
                 return Stepper != null && Stepper.IsRunning && Stepper.Enabled;
            }
        }

        /// <summary>
        /// Происходит при истечении заданного интервала шагов <see cref="Interval"/>.
        /// </summary>
        public event EventHandler Elapsed = delegate { };

        /// <summary>
        /// Происходит перед запуском работы шагового двигателя.
        /// </summary>
        public event EventHandler OnStart = delegate { };

        /// <summary>
        /// Происходит после остановки работы шагового двигателя, в том числе аварийной.
        /// </summary>
        public event EventHandler OnStop = delegate { };

        #endregion

        #region Конструкторы.

        /// <summary>
        /// Предоставляет класс для запуска шагового двигателя.
        /// </summary>
        /// <param name="interval">Интревал (в шагах) через который будет вызываться событие <see cref="Elapsed"/></param>
        public StepperWorker(int interval = 0)
        {
            Interval = interval;
        }

        #endregion

        /// <summary>
        /// Запускает работу шагового двигателя <see cref="Stepper"/>.
        /// </summary>
        public void Start()
        {
            if (Enabled)
                return;   

            this.stopWorker = false;
            StopReason = StepperStopReason.None;

            ThreadStart threadStart = delegate ()
            {
                Loop(ref this.stopWorker);
            };

            this.threadWorker = new Thread(threadStart);
            this.threadWorker.Priority = ThreadPriority.Normal;
            this.threadWorker.Start();
        }

        /// <summary>
        /// Останавливает шаговый двигатель с заданным торможением.
        /// </summary>
        public void Stop()
        {
            if (Stepper == null)
                return;

            StopReason = StepperStopReason.Stoped;
            Stepper.Stop();
        }

        /// <summary>
        /// Вызывает аварийную остановку шагового двигателя.
        /// </summary>
        public void Abort()
        {
            this.stopWorker = true;

            if (Enabled)
            {
                this.StopReason = StepperStopReason.Aborted;
                this.threadWorker.Abort();
                Stepper.Enabled = false;
                OnStop(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Главный цикл, в котором происходит запуск метода <see cref="StepperMotor.Run"/>.
        /// </summary>
        /// <param name="stopTimer">Флаг остановки</param>
        private void Loop(ref bool stopTimer)
        {                  
            Stepper.Enabled = true;

            OnStart(this, EventArgs.Empty);

            while (!stopTimer)
            {
                Stepper.Run();

                if (Interval > 0 && Stepper.CurrentStepsCount % Interval == 0)
                    Elapsed(this, EventArgs.Empty);

                stopTimer = !Stepper.IsRunning;
            }

            Stepper.Enabled = false;

            StopReason = StopReason == StepperStopReason.Stoped ? StopReason : StepperStopReason.WorkDone;

            OnStop(this, EventArgs.Empty);
        }

        #region Поля.

        private Thread threadWorker = null;
        private bool stopWorker = true;

        #endregion
    }
}
