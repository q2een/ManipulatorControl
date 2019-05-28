using System;

namespace LptStepperMotorControl.Stepper
{
    public class StepperWorker
    {
        System.Threading.Thread threadTimer = null;
        bool stopTimer = true;

        public StepperMotor Stepper { get; set; }

        public StepperStopReason StopReason { get; private set; }

        public int Interval { get; set; }

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
                return (this.threadTimer != null && this.threadTimer.IsAlive);
            }
        }

        public event EventHandler Elapsed = delegate { };
        public event EventHandler OnStart = delegate { };
        public event EventHandler OnStop = delegate { };

        public StepperWorker()
        {
                
        }

        public StepperWorker(int interval)
        {
            Interval = interval;
        }

        public void Start()
        {
            if (Enabled)
                return;

            this.stopTimer = false;
            StopReason = StepperStopReason.None;

            Stepper.ResetSteps();

            System.Threading.ThreadStart threadStart = delegate ()
            {
                Loop(ref this.stopTimer);
            };

            this.threadTimer = new System.Threading.Thread(threadStart);
            this.threadTimer.Priority = System.Threading.ThreadPriority.Normal;
            this.threadTimer.Start();
        }

        public void Stop()
        {
            if (Stepper == null)
                return;

            StopReason = StepperStopReason.Stoped;
            Stepper.Stop();
        }

        public void Abort()
        {
            this.stopTimer = true;

            if (Enabled)
            {
                this.StopReason = StepperStopReason.Aborted;
                this.threadTimer.Abort();
                Stepper.Enabled = false;
                OnStop(this, EventArgs.Empty);
                Stepper.ResetSteps();
            }
        }

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
            Stepper.ResetSteps();
        }
    }
}
