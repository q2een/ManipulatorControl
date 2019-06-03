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

        private bool IsMovingBack;

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

        public void SetCurrentPositionAsStart()
        {
            startPosition = movement.GetCurrentLeversPosition();

            endPosition = null;
            leverPositions = new List<LeverScriptPosition>();

            this.movement.OnMovingStart += Movement_OnMovingStart;
            this.movement.OnMovingEnd += Movement_OnMovingEnd;
        }

        public void SetCurrentPositionAsEnd()
        {
            endPosition = movement.GetCurrentLeversPosition();
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

            IsMovingBack = true;

            movement.MoveRobotByPath(movePositions, new Action(Continue));
        }

        private void Continue()
        {
            IsMovingBack = false;
            OnPathChanged(this, EventArgs.Empty);
        }

        private void Movement_OnMovingEnd(object sender, StepLever e)
        {
            if (IsMovingBack)
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
            if(!IsMovingBack)
                scriptPosition = new LeverScriptPosition() { LeverType = e.Lever, From = movement.GetLeverPosition(e.Lever)};
        }
    }
}
