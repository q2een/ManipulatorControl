﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManipulatorControl.BL
{
    public class LeverPosition : EventArgs, IEquatable<LeverPosition>, IEqualityComparer<LeverPosition>
    {
        public LeverType LeverType { get; private set; }

        public double Position{ get; set; }

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
