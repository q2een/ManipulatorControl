using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ManipulatorControl.BL.Script
{
    public class ScriptBuilder
    {
        private readonly RobotMovement movement;

        private bool IsMoving = false;

        private IEnumerable<LeverPosition> startPosition, endPosition;

        private List<LeverScriptPosition> leverPositions = new List<LeverScriptPosition>();

        private LeverScriptPosition scriptPosition;

        public event EventHandler OnPathChanged = delegate { };

        public ReadOnlyCollection<LeverScriptPosition> Path
        {
            get
            {
                return leverPositions.AsReadOnly();
            }
        }

        public ScriptBuilder(RobotMovement movement)
        {
            this.movement = movement;
        }

        public MovementScript GetScript()
        {
            if (scriptPosition != null || IsMoving)
                throw new Exception("Дождидесь окончания перемещения робота");

            if(endPosition == null || endPosition.Count() == 0)
                SetCurrentPositionAsEnd();

            return new MovementScript(new Queue<LeverScriptPosition>(Path), startPosition, endPosition);
        }

        public void SetCurrentPositionAsStart()
        {
            if(startPosition == null || startPosition.Count() == 0)
            {
                this.movement.OnMovingStart -= Movement_OnMovingStart;
                this.movement.OnMovingEnd -= Movement_OnMovingEnd;
            }

            startPosition = movement.GetCurrentLeversPosition();

            endPosition = null;
            leverPositions = new List<LeverScriptPosition>();

            this.movement.OnMovingStart += Movement_OnMovingStart;
            this.movement.OnMovingEnd += Movement_OnMovingEnd;
        }

        public void SetCurrentPositionAsEnd()
        {
            endPosition = movement.GetCurrentLeversPosition();

            this.movement.OnMovingStart -= Movement_OnMovingStart;
            this.movement.OnMovingEnd -= Movement_OnMovingEnd;
        }

        public void BackTo(LeverScriptPosition scriptPosition)
        {
            if (!leverPositions.Contains(scriptPosition))
                throw new ArgumentException("Не найдена заданная точка");

            var startIndex = Path.IndexOf(scriptPosition);
            var count = Path.Count - startIndex;

            if (count == 0)
                return;

            var movePositions = new List<LeverPosition>();

            for (int i = startIndex; i < Path.Count; i++)
            {
                var pos = leverPositions[i];
                movePositions.Add(new LeverPosition(pos.LeverType, pos.From));
            }

            movePositions.Reverse();

            leverPositions.RemoveRange(startIndex, count);

            IsMoving = true;

            movement.MoveRobotByPath(movePositions, new Action(Continue));
        }
        
        public void MoveTo(LeverScriptPosition scriptPosition)
        {
            var currentPosition = movement.GetCurrentLeversPosition().OrderBy(i => i.LeverType);

            if (!startPosition.OrderBy(i => i.LeverType).SequenceEqual(currentPosition))
                throw new Exception("Необходимо переместить робот в начальное положение");

            var startIndex = Path.IndexOf(scriptPosition);

            var movePositions = new List<LeverPosition>();

            for (int i = 0; i < startIndex + 1; i++)
            {
                var pos = leverPositions[i];
                movePositions.Add(new LeverPosition(pos.LeverType, pos.To));
            }

            IsMoving = true;

            movement.MoveRobotByPath(movePositions, new Action(Continue));
        }
        
        private void Continue()
        {
            IsMoving = false;
            OnPathChanged(this, EventArgs.Empty);
        }

        private void Movement_OnMovingEnd(object sender, StepLever e)
        {
            if (IsMoving)
                return;

            if (scriptPosition.LeverType != e.Lever)
                throw new Exception("Ошибка создания сценария");

            scriptPosition.To = movement.GetLeverPosition(e.Lever);
            leverPositions.Add(scriptPosition);

            OnPathChanged(this, EventArgs.Empty);

            scriptPosition = null;
        }

        private void Movement_OnMovingStart(object sender, StepLever e)
        {
            if(!IsMoving)
                scriptPosition = new LeverScriptPosition() { LeverType = e.Lever, From = movement.GetLeverPosition(e.Lever)};
        }
    }
}
