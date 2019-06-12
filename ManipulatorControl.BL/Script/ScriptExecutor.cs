using System;
using System.Collections.Generic;
using System.Linq;

namespace ManipulatorControl.BL.Script
{
    /// <summary>
    /// Предоставляет класс для выполнения сценария.
    /// </summary>
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

        /// <summary>
        /// Выполняет сценарий в прямой или обратной последовательности.
        /// </summary>
        /// <param name="movementScript">Объект класса сценария</param>
        /// <param name="isReversed">Флаг, указывающий на выполнение в обратной последовательности</param>
        public void Execute(MovementScript movementScript, bool isReversed)
        {
            if (IsExecuting)
                throw new Exception("Уже выполняется другой скрипт");

            this.MovementScript = isReversed ? movementScript.GetReversed() : movementScript;

            var startPosExceptions = movement.ValidateLeverPositions(MovementScript.Start);

            if (startPosExceptions.Count() > 0)
                throw new Exception("Невозможно достичь начальное положение сценария\n" +
                    string.Join("\n", startPosExceptions.Select(ex => ex.Message)));

            var endPosExceptions = movement.ValidateLeverPositions(MovementScript.End);

            if (endPosExceptions.Count() > 0)
                throw new Exception("Невозможно достичь конечное положение сценария\n" +
                    string.Join("\n", endPosExceptions.Select(ex => ex.Message)));

            var pathExceptions = movement.ValidateLeverPositions(MovementScript.MovementPath.SelectMany(path => GetLeverPositions(path)));

            if (pathExceptions.Count() > 0)
                throw new Exception("Невозможно достичь одно или несколько положения из сценария\n" +
                    string.Join("\n", pathExceptions.Select(ex => ex.Message)));

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

        private IEnumerable<LeverPosition> GetLeverPositions(LeverScriptPosition leverScriptPosition)
        {
            yield return new LeverPosition(leverScriptPosition.LeverType, leverScriptPosition.From);
            yield return new LeverPosition(leverScriptPosition.LeverType, leverScriptPosition.To);
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
