using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ManipulatorControl.BL
{
    public class MovementScript
    {
        private readonly Queue<LeverPosition> movementPath;

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

        public Queue<LeverPosition> MovementPath
        {
            get
            {
                return new Queue<LeverPosition>(IsReverse ? movementPath.Reverse() : movementPath);
            }
        }

        public MovementScript(Queue<LeverPosition> movementPath, IEnumerable<LeverPosition> startPosition, IEnumerable<LeverPosition> ednPosition)
        {
            this.movementPath = Optimize(movementPath);
            this.startPosition = startPosition;
            this.ednPosition = ednPosition;
        }

        public static Queue<LeverPosition> Optimize(Queue<LeverPosition> movementPath)
        {
            Queue<LeverPosition> path = new Queue<LeverPosition>();

            var lastPosition = movementPath.Dequeue();
            while(movementPath.Count > 0)
            {
                var position = movementPath.Dequeue();

                if(lastPosition.Lever != position.Lever)
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
