using System;

namespace ManipulatorControl.BL.Script
{
    /// <summary>
    /// Предоставляет класс содержащий данные об одном шаге в сценарии.
    /// </summary>
    public class LeverScriptPosition : EventArgs, IEquatable<LeverScriptPosition>
    {
        /// <summary>
        /// Возвращает тип плеча робота.
        /// </summary>
        public LeverType LeverType { get; private set; }

        /// <summary>
        /// Возвращает начальную точку плеча робота.
        /// </summary>
        public double From { get; set; }

        /// <summary>
        /// Возвращает конечную точку плеча робота.
        /// </summary>
        public double To { get; set; }

        /// <summary>
        /// Предоставляет класс содержащий данные об одном шаге в сценарии.
        /// </summary>
        /// <param name="leverType">Тип плеча робота</param>
        public LeverScriptPosition(LeverType leverType)
        {
            LeverType = leverType;
        }

        public LeverScriptPosition GetReversed()
        {
            return new LeverScriptPosition(LeverType)
            {
                From = To,
                To = From
            };
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            return this.Equals(other as LeverScriptPosition);
        }

        public bool Equals(LeverScriptPosition other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            return this.LeverType == other.LeverType && this.From.Equals(other.From) && this.To.Equals(other.To);
        }

        public override int GetHashCode()
        {
            return From.GetHashCode() ^ To.GetHashCode() ^ LeverType.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} ---> {2}", LeverType.ToRuString(), From, To);
        }
    }
}
