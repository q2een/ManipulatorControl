using System;

namespace ManipulatorControl.BL.Script
{
    public class LeverScriptPosition : EventArgs, IEquatable<LeverScriptPosition>
    {
        public LeverType LeverType { get; set; }

        public double From { get; set; }

        public double To { get; set; }

        public LeverScriptPosition GetReversed()
        {
            return new LeverScriptPosition()
            {
                LeverType = LeverType,
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
