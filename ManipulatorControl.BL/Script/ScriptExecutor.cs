using System;
using System.Collections.Generic;
using System.Linq;

namespace ManipulatorControl.BL.Script
{
    public class ScriptExecutor
    {
        #region Свойства.

        public MovementScript MovementScript { get; private set; }

        public bool IsExecuting
        {
            get
            {
                return isExecuting || active != null;
            }
            private set
            {
                if (isExecuting == value)
                    return;

                if (!value)
                {
                    isRunningToPoint = false;
                    path = null;
                    active = null;
                    movement.LeverPositionChanged -= Movement_LeverPositionChanged;
                    movement.OnMovingEnd -= Movement_OnMovingEnd;
                    OnExecutingEnd(this, EventArgs.Empty);
                    Exception = null;
                    MovementScript = null;
                }
                else
                {
                    OnExecutingStart(this, EventArgs.Empty);
                    movement.LeverPositionChanged += Movement_LeverPositionChanged;
                    movement.OnMovingEnd += Movement_OnMovingEnd;
                }

                isExecuting = value;
            }
        }

        public Exception Exception { get; private set; }

        #endregion

        #region События.

        public event EventHandler<LeverScriptPosition> StepPassed = delegate { };
        public event EventHandler OnExecutingStart = delegate { };
        public event EventHandler OnExecutingEnd = delegate { };

        #endregion

        #region Конструкторы.

        public ScriptExecutor(RobotMovement movement)
        {
            this.movement = movement;
        }

        #endregion

        public void Execute(MovementScript movementScript, bool isReversed)
        {
            if (IsExecuting)
                throw new Exception("Уже выполняется другой скрипт");

            this.MovementScript = isReversed ? movementScript.GetReversed() : movementScript;

            Execute();
        }

        private void Execute()
        {
            try
            {
                IsExecuting = true;

                if (!movement.IsNowAtPosition(MovementScript.Start))
                {
                    isRunningToPoint = true;
                    movement.MoveRobotByPath(MovementScript.Start, Execute);
                    return;
                }

                path = new Queue<LeverScriptPosition>(MovementScript.MovementPath);
                Run();
            }
            catch (Exception ex)
            {
                Exception = ex;
                IsExecuting = false;
            }
        }

        private void Run()
        {
            try
            {
                isRunningToPoint = false;
                active = path.Dequeue();

                if (movement.GetLeverPosition(active.LeverType) != active.From)
                    throw new Exception("Ошибка при перемещении робота по сценарию");

                movement.MoveLever(GetActiveLeverPosition());
            }
            catch (Exception ex)
            {
                Exception = ex;
                IsExecuting = false;
            }
        }

        private LeverPosition GetActiveLeverPosition()
        {
            if (active == null)
                return null;

            return new LeverPosition(active.LeverType, active.To);
        }

        private void Movement_LeverPositionChanged(object sender, LeverPosition e)
        {
            try
            {
                if (isRunningToPoint)
                {
                    if (!MovementScript.Start.Contains(e) && !MovementScript.End.Contains(e))
                        throw new Exception("Ошибка при перемещении робота к " + (path == null ? "начальной" : "конечной") + " точке сценария");

                    return;
                }

                if (!e.Equals(GetActiveLeverPosition()))
                    throw new Exception("Ошибка при перемещении робота по сценарию");

                StepPassed(this, active);

                active = null;

                if (path.Count > 0)
                {
                    Run();
                    return;
                }

                if (!movement.IsNowAtPosition(MovementScript.End))
                {
                    movement.MoveRobotByPath(MovementScript.End, new Action(() => isRunningToPoint = false));
                    return;
                }   

                IsExecuting = false;
            }
            catch (Exception ex)
            {
                Exception = ex;
                IsExecuting = false;
            }
        }

        private void Movement_OnMovingEnd(object sender, LeverMovingEndEventArgs e)
        {
            if (isExecuting && (e.StopReason == LptStepperMotorControl.Stepper.StepperStopReason.Aborted
                || e.StopReason == LptStepperMotorControl.Stepper.StepperStopReason.Stoped))
            {
                Exception = new Exception("Выполнение сценария остановлено");
                IsExecuting = false;
            }
        }

        #region Поля.

        private readonly RobotMovement movement;

        private Queue<LeverScriptPosition> path;

        private LeverScriptPosition active;

        private bool isExecuting, isRunningToPoint;

        #endregion
    }
}
