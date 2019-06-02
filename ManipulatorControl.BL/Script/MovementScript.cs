using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ManipulatorControl.BL.Script
{
    public class MovementScript
    {
        private readonly Queue<LeverScriptPosition> movementPath;

        private readonly IEnumerable<LeverPosition> startPosition, ednPosition;

        public IEnumerable<LeverPosition> Start
        {
            get
            {
                return IsReverse ? ednPosition : startPosition;
            }
        }

        public IEnumerable<LeverPosition> End
        {
            get
            {
                return IsReverse ? startPosition : ednPosition; 
            }
        }

        public bool IsReverse { get; set; }

        public Queue<LeverScriptPosition> MovementPath
        {
            get
            {
                return new Queue<LeverScriptPosition>(IsReverse ? movementPath.Reverse() : movementPath);
            }
        }

        public MovementScript(Queue<LeverScriptPosition> movementPath, IEnumerable<LeverPosition> startPosition, IEnumerable<LeverPosition> ednPosition)
        {
            this.movementPath = Optimize(movementPath);
            this.startPosition = startPosition;
            this.ednPosition = ednPosition;
        }

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
        }
    }
}
