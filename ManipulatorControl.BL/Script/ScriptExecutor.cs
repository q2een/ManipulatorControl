using System;
using System.Collections.Generic;
using System.Linq;

namespace ManipulatorControl.BL.Script
{
    public class ScriptExecutor
    {
        public MovementScript MovementScript { get; private set; }
        private readonly RobotMovement movement;

        private Queue<LeverScriptPosition> path;

        private LeverScriptPosition active;
        private LeverPosition ActiveLeverPosition
        {
            get
            {
                return new LeverPosition(active.LeverType, active.To);
            }
        }

        public event EventHandler<LeverScriptPosition> StepPassed = delegate { };
        public event EventHandler ScriptExecuted = delegate { };

        public ScriptExecutor(RobotMovement movement)
        {
            this.movement = movement;
        }

        public void Execute(MovementScript movementScript, bool isReversed)
        {
            if (active != null)
                throw new Exception("Уже выполняется другой скрипт");

            this.MovementScript = isReversed ? movementScript.GetReversed() : movementScript;

            Execute();
        }

        private void Execute()
        {
            try
            {
                if (!IsNowInPosition(MovementScript.Start))
                    movement.MoveRobotByPath(MovementScript.Start, Execute);

                path = new Queue<LeverScriptPosition>(MovementScript.MovementPath);

                movement.LeverPositionChanged += Movement_LeverPositionChanged;
                Run();
            }
            catch(Exception ex)
            {
                active = null;
                movement.LeverPositionChanged -= Movement_LeverPositionChanged; 
                throw ex;
            }
        }

        private void Run()
        {
            try
            {
                active = path.Dequeue();

                if (!movement.GetLeverPosition(active.LeverType).Equals(active.From))
                    throw new Exception("Ошибка при перемещении робота по сценарию");

                movement.MoveLever(ActiveLeverPosition);
            }
            catch (Exception ex)
            {
                active = null;
                movement.LeverPositionChanged -= Movement_LeverPositionChanged;
                throw ex;
            }
        }

        private void Movement_LeverPositionChanged(object sender, LeverPosition e)
        {
            try
            {
                if (!e.Equals(ActiveLeverPosition))
                    throw new Exception("Ошибка при перемещении робота по сценарию");

                StepPassed(this, active);

                active = null;

                if (path.Count > 0)
                {
                    Run();
                    return;
                }

                if (!IsNowInPosition(MovementScript.End))
                {
                    movement.MoveRobotByPath(MovementScript.End, null);
                    ScriptExecuted(this, EventArgs.Empty);
                    active = null;
                    movement.LeverPositionChanged -= Movement_LeverPositionChanged;
                }

            }
            catch (Exception ex)
            {
                active = null;
                movement.LeverPositionChanged -= Movement_LeverPositionChanged;
                throw ex;
            }
        }

        private bool IsNowInPosition(IEnumerable<LeverPosition> position)
        {
            var current = movement.GetCurrentLeversPosition().OrderBy(i => i.LeverType);
            position = position.OrderBy(i => i.LeverType);

            return current.SequenceEqual(position);
        }
    }
}
