using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ManipulatorControl.BL.Script
{
    public class MovementScript : EventArgs
    {
        private readonly Queue<LeverScriptPosition> movementPath;

        private readonly IEnumerable<LeverPosition> startPosition, ednPosition;

        public IEnumerable<LeverPosition> Start
        {
            get
            {
                return startPosition;
            }
        }

        public IEnumerable<LeverPosition> End
        {
            get
            {
                return ednPosition; 
            }
        }

        public ReadOnlyCollection<LeverScriptPosition> MovementPath
        {
            get
            {
                return movementPath.ToList().AsReadOnly();
            }
        }

        public MovementScript GetReversed()
        {
            var queue = new Queue<LeverScriptPosition>(movementPath.Select(i => i.GetReversed()).Reverse());
            return new MovementScript(queue, ednPosition, startPosition);
        }

        public MovementScript(Queue<LeverScriptPosition> movementPath, IEnumerable<LeverPosition> startPosition, IEnumerable<LeverPosition> ednPosition)
        {
            this.movementPath = movementPath;//Optimize(movementPath);
            this.startPosition = startPosition;
            this.ednPosition = ednPosition;
        }
        /*
        public static Queue<LeverScriptPosition> Optimize(Queue<LeverScriptPosition> movementPath)
        {
            Queue<LeverScriptPosition> path = new Queue<LeverScriptPosition>();

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

                path.Enqueue(position);                               

                lastPosition = position;
            }

            return path;
        }      */
    }
}
