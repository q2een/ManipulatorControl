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
        private string scriptName;

        private bool IsMoving = false;

        private List<LeverScriptPosition> leverPositions = new List<LeverScriptPosition>();

        private LeverScriptPosition scriptPosition;

        public event EventHandler OnPathChanged = delegate { };
        public event EventHandler OnNewStartPoint = delegate { };
        public event EventHandler OnNewEndPoint = delegate { };

        public IEnumerable<LeverPosition> StartPoint { get; private set; }
        public IEnumerable<LeverPosition> EndPoint { get; private set; }


        public ReadOnlyCollection<LeverScriptPosition> Path
        {
            get
            {
                return leverPositions.AsReadOnly();
            }
        }

        public ScriptBuilder(RobotMovement movement, string scriptName)
        {
            this.movement = movement;
            this.scriptName = scriptName;
        }

        public MovementScript GetScript()
        {
            if (scriptPosition != null || IsMoving)
                throw new Exception("Дождидесь окончания перемещения робота");

            if(EndPoint == null || EndPoint.Count() == 0)
                SetCurrentPositionAsEnd();

            if (StartPoint.SequenceEqual(EndPoint) && leverPositions.Count == 0)
                throw new Exception("Невозможно создать пустой сценарий");

            return new MovementScript(new Queue<LeverScriptPosition>(leverPositions), StartPoint, EndPoint) { Name = scriptName };
        }

        public void Cancel()
        {
            this.movement.OnMovingStart -= Movement_OnMovingStart;
            this.movement.OnMovingEnd -= Movement_OnMovingEnd;
        }

        public void SetCurrentPositionAsStart()
        {
            if(StartPoint != null && StartPoint.Count() != 0)
            {
                this.movement.OnMovingStart -= Movement_OnMovingStart;
                this.movement.OnMovingEnd -= Movement_OnMovingEnd;
            }

            StartPoint = movement.GetCurrentLeversPosition();
            OnNewStartPoint(this, EventArgs.Empty);

            EndPoint = null;
            leverPositions = new List<LeverScriptPosition>();
            OnPathChanged(this, EventArgs.Empty);

            this.movement.OnMovingStart += Movement_OnMovingStart;
            this.movement.OnMovingEnd += Movement_OnMovingEnd;
        }

        public void SetCurrentPositionAsEnd()
        {
            EndPoint = movement.GetCurrentLeversPosition();
            OnNewEndPoint(this, EventArgs.Empty);

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

            if (!StartPoint.OrderBy(i => i.LeverType).SequenceEqual(currentPosition))
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

        public static Queue<LeverScriptPosition> Optimize(Queue<LeverScriptPosition> movementPath)
        {
            Queue<LeverScriptPosition> path = new Queue<LeverScriptPosition>();

            if (movementPath.Count <= 1)
                return movementPath;

            var lastPosition = movementPath.Dequeue();

            while(movementPath.Count > 0)
            {
                var position = movementPath.Dequeue();

                if(lastPosition.LeverType != position.LeverType)
                {
                    path.Enqueue(lastPosition);
                    path.Enqueue(position);
                    continue;
                }

                path.Enqueue(new LeverScriptPosition(position.LeverType)
                {
                    From = lastPosition.From,
                    To = position.To
                });                               

                lastPosition = position;
            }

            return path;
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
                scriptPosition = new LeverScriptPosition(e.Lever) {From = movement.GetLeverPosition(e.Lever)};
        }
    }
}
