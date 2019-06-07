using System;
using System.Collections.Generic;

namespace ManipulatorControl.BL
{
    /// <summary>
    /// Предоставляет класс содержащий данные о положении плеча робота-манипулятора.
    /// </summary>
    public class LeverPosition : EventArgs, IEquatable<LeverPosition>, IEqualityComparer<LeverPosition>
    {
        /// <summary>
        /// Возвращает тип плеча робота.
        /// </summary>
        public LeverType LeverType { get; private set; }

        /// <summary>
        /// Возвращает или задает положение плеча робота.
        /// </summary>
        public double Position{ get; set; }

        /// <summary>
        /// Предоставляет класс содержащий данные о положении плеча робота-манипулятора.
        /// </summary>
        /// <param name="leverType">Тип плеча робота</param>
        /// <param name="position">Положение плеча робота.</param>
        public LeverPosition(LeverType leverType, double position)
        {
            LeverType = leverType;
            Position = position;
        }


        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            return this.Equals(other as LeverPosition);
        }

        public bool Equals(LeverPosition other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            return this.LeverType == other.LeverType && Math.Round(this.Position, 0).Equals(Math.Round(other.Position, 0));
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode() ^ LeverType.GetHashCode();
        }

        public bool Equals(LeverPosition x, LeverPosition y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(LeverPosition obj)
        {
            return obj.GetHashCode();
        }
    }
}
