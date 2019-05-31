﻿using LptStepperMotorControl.PortControl;
using LptStepperMotorControl.Stepper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulatorControl.BL
{
    public class LeverMovement
    {
        private readonly StepperWorker worker = new StepperWorker(100);
        private LPTPort port;

        private readonly RobotLever[] levers;
        private RobotLever movingLever;

        private Queue<StepLever> steppersQueue;

        public bool IsRunning
        {
            get
            {
                return movingLever != null;
            }
        }

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
        public event EventHandler<StepLever> OnMovingEnd = delegate { };
        public event EventHandler<StepLever> OnStepsIntervalElapsed = delegate { };

        public LeverMovement(LPTPort port, RobotLever[] levers)
        {
            this.port = port;
            this.levers = levers;

            this.worker.OnStart += Worker_OnStart;
            this.worker.OnStop += Worker_OnStop;
            this.worker.Elapsed += Worker_Elapsed;
        }

        public void Run(StepLever stepLever)
        {
            if (IsRunning || (worker.Stepper != null && worker.Stepper.Enabled))
                throw new Exception("Невозможно запустить перемещение плеча, так как перемещение другого плеча еще не окончено");

            movingLever = levers.Single(lever => lever.Type == stepLever.Lever);

            worker.Stepper = movingLever.Stepper;
            worker.Stepper.TargetStepsCount = stepLever.StepsCount;

            new Task(worker.Start).Start();
        }

        public void Run(Queue<StepLever> steppersQueue)
        {
            if (IsRunning || (worker.Stepper != null && worker.Stepper.Enabled))
                throw new Exception("Невозможно запустить перемещение плеча, так как перемещение другого плеча еще не окончено");

            this.steppersQueue = steppersQueue;
            Continue();
        }

        public void Stop(LeverType type)
        {
            if (movingLever.Type == type)
                worker.Stop();
        }

        public void Stop()
        {
            worker.Stop();
        }

        public void Abort()
        {
            worker.Abort();
        }

        private void Continue()
        {
            if (steppersQueue == null || steppersQueue.Count == 0)
                return;

            Run(steppersQueue.Dequeue());
        }

        private void Worker_Elapsed(object sender, EventArgs e)
        {
            OnStepsIntervalElapsed(this, new StepLever(movingLever.Type, movingLever.Stepper.CurrentStepsCount));
        }

        private void Worker_OnStop(object sender, EventArgs e)
        {               
            if(steppersQueue.Count > 0)
            {
                if (worker.StopReason != StepperStopReason.WorkDone)
                    steppersQueue.Clear();
                else
                    new Task(Continue).Start();
            }

            OnMovingEnd(this, new StepLever(movingLever.Type, movingLever.Stepper.CurrentStepsCount));
            movingLever = null;   
        }

        private void Worker_OnStart(object sender, EventArgs e)
        {   
            if(steppersQueue.Count == 0)
            OnMovingStart(this, new StepLever(movingLever.Type, movingLever.Stepper.CurrentStepsCount));
        }
    }
}