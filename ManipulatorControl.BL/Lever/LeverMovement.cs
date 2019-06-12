using LptStepperMotorControl.PortControl;
using LptStepperMotorControl.Stepper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManipulatorControl.BL
{
    /// <summary>
    /// Предоставляет класс, отвечающий за перемещение плеча робота-манипулятора.
    /// </summary>
    public class LeverMovement
    {
        private readonly StepperWorker worker = new StepperWorker(80);
        private LPTPort port;

        private readonly LeverStepper[] levers;
        private LeverStepper movingLever;

        private Queue<StepLever> steppersQueue = new Queue<StepLever>();

        private Action doAfterWorkEnd = null;

        public bool IsRunning
        {
            get
            {
                return movingLever != null;
            }
        }

        public bool IsQueueMoving { get; private set; }

        public int StepsInterval
        {
            get
            {
                return this.worker.Interval;
            }
            set
            {
                this.worker.Interval = value;
            }
        }

        public event EventHandler<StepLever> OnMovingStart = delegate { };
        public event EventHandler<LeverMovingEndEventArgs> OnMovingEnd = delegate { };
        public event EventHandler<StepLever> OnStepsIntervalElapsed = delegate { };

        public LeverMovement(LPTPort port, LeverStepper[] levers)
        {
            this.port = port;
            this.levers = levers;

            this.worker.OnStart += Worker_OnStart;
            this.worker.OnStop += Worker_OnStop;
            this.worker.Elapsed += Worker_Elapsed;
        }

        /// <summary>
        /// Подает на шаговый двигатель плеча указанное количество импульсов.
        /// </summary>
        /// <param name="stepLever">Тип перемещаемого плеча и количество импульсов</param>
        public void Move(StepLever stepLever)
        {
            if (IsRunning || worker.Enabled)
                throw new Exception("Невозможно запустить перемещение плеча, так как перемещение другого плеча еще не окончено");

            if (stepLever.StepsCount == 0)
                return;

            IsQueueMoving = false;

            Run(stepLever);
        }

        /// <summary>
        /// Последовательно выполняет перемещение плеч из очереди.
        /// </summary>
        /// <param name="steppersQueue">Очередь экземпляров класса, содержащего тип перемещаемого плеча и количество импульсов</param>
        public void Move(Queue<StepLever> steppersQueue)
        {
            Move(steppersQueue, null);
        }

        /// <summary>
        /// Последовательно выполняет перемещения плеч из очереди. После завершения перемещения выполняет <paramref name="doAfterWorkEnd"/>.
        /// </summary>
        /// <param name="steppersQueue">Очередь экземпляров класса, содержащего тип перемещаемого плеча и количество импульсов</param>
        /// <param name="doAfterWorkEnd">Метод, который будет выполнен после завершения перемещения</param>
        public void Move(Queue<StepLever> steppersQueue, Action doAfterWorkEnd)
        {
            if (IsRunning || worker.Enabled)
                throw new Exception("Невозможно запустить перемещение плеча, так как перемещение другого плеча еще не окончено");

            this.steppersQueue = new Queue<StepLever>(steppersQueue.Where(stepLever => stepLever.StepsCount != 0));

            IsQueueMoving = true;

            this.doAfterWorkEnd = doAfterWorkEnd;
            Continue();
        }

        public void Stop(LeverType type)
        {
            if (movingLever != null && movingLever.Type == type)
                worker.Stop();
        }

        /// <summary>
        /// Останавливает шаговый двигатель с заданным торможением.
        /// </summary>
        public void Stop()
        {
            worker.Stop();
        }

        /// <summary>
        /// Вызывает аварийную остановку шагового двигателя.
        /// </summary>
        public void Abort()
        {
            worker.Abort();
        }

        private void Run(StepLever stepLever)
        {
            movingLever = levers.Single(lever => lever.Type == stepLever.Lever);

            worker.Stepper = movingLever.Stepper;
            worker.Stepper.SetStepsCount(stepLever.StepsCount);

            new Task(worker.Start).Start();
        }

        private void Continue()
        {
            if (steppersQueue == null || steppersQueue.Count == 0)
            {
                if (doAfterWorkEnd != null)
                    doAfterWorkEnd();

                return;
            }

            Run(steppersQueue.Dequeue());
        }

        private void Worker_Elapsed(object sender, EventArgs e)
        {
            OnStepsIntervalElapsed(this, new StepLever(movingLever.Type, movingLever.Stepper.CurrentStepsCount));
        }

        private void Worker_OnStop(object sender, EventArgs e)
        {
            var stepLever = new StepLever(movingLever.Type, movingLever.Stepper.CurrentStepsCount);
            movingLever = null;

            OnMovingEnd(this, new LeverMovingEndEventArgs(stepLever, worker.StopReason));

            if (IsQueueMoving)
            {
                if (worker.StopReason != StepperStopReason.WorkDone)
                    steppersQueue.Clear();
                else
                    new Task(Continue).Start();
            }
        }

        private void Worker_OnStart(object sender, EventArgs e)
        {   
            OnMovingStart(this, new StepLever(movingLever.Type, movingLever.Stepper.TargetStepsCount));
        }
    }
}
