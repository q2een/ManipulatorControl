using System;
using System.Collections.Generic;
using System.Linq;

namespace ManipulatorControl.BL.Script
{
    /// <summary>
    /// Предоставляет класс содержащий данные сценария.
    /// </summary>
    public class MovementScript : EventArgs
    {
        private readonly Queue<LeverScriptPosition> movementPath;

        /// <summary>
        /// Возвращает или задает наименование сценария.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возврвщает начальную положение робота в сценарии.
        /// </summary>
        public IEnumerable<LeverPosition> Start { get; private set; }

        /// <summary>
        /// Возврвщает конечное положение робота в сценарии.
        /// </summary>
        public IEnumerable<LeverPosition> End { get; private set; }

        /// <summary>
        /// Возвращает очередь положений робота - сценарий. 
        /// </summary>
        /// <remarks>
        /// Возвращает копию очереди.
        /// </remarks>
        public Queue<LeverScriptPosition> MovementPath
        {
            get
            {
                return new Queue<LeverScriptPosition>(movementPath ?? new Queue<LeverScriptPosition>());
            }
        }

        /// <summary>
        /// Возвращает экземпляр класса для исполнения сценария в обратном порядке.
        /// </summary>
        /// <returns>Экземпляр класса для исполнения сценария в обратном порядке</returns>
        public MovementScript GetReversed()
        {
            var queue = new Queue<LeverScriptPosition>(movementPath.Select(i => i.GetReversed()).Reverse());
            return new MovementScript(queue, start: End, end: Start) { Name = Name + "[REVERSE]" };
        }

        /// <summary>
        /// Предоставляет класс содержащий данные сценария. Позволяет реализовать обучение робота.
        /// </summary>
        /// <param name="movementPath">Позиции плечей при движения робота.</param>
        /// <param name="start">Начальное положения робота</param>
        /// <param name="end">Конечное положение робота</param>
        public MovementScript(Queue<LeverScriptPosition> movementPath, IEnumerable<LeverPosition> start, IEnumerable<LeverPosition> end)
        {
            this.movementPath = movementPath;

            Start = start;
            End = end;
        }

        /// <summary>
        /// Переопределение класса. Возвращает строку с наименованием сценария.
        /// </summary>
        /// <returns>Строка с наименованием сценария</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
