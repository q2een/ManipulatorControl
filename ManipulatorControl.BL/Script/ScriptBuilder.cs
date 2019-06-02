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

        private IEnumerable<LeverPosition> startPosition, endPosition;

        private List<LeverScriptPosition> leverPositions = new List<LeverScriptPosition>();

        private LeverScriptPosition scriptPosition;

        public event EventHandler OnNewPathItem = delegate { };

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

        private void Movement_OnMovingEnd(object sender, StepLever e)
        {
            if (scriptPosition.LeverType != e.Lever)
                throw new Exception("Ошибка создания сценария");

            scriptPosition.To = movement.GetLeverPosition(e.Lever);
            leverPositions.Add(scriptPosition);

            OnNewPathItem(this, EventArgs.Empty);

            scriptPosition = null;
        }

        private void Movement_OnMovingStart(object sender, StepLever e)
        {
            scriptPosition = new LeverScriptPosition() { LeverType = e.Lever, From = movement.GetLeverPosition(e.Lever)};
        }
    }
}
