using System;

namespace Value_Equality_Struct_Example
{
    public struct TwoDPoint : IEquatable<TwoDPoint>
    {
        // Read/write auto-implemented properties.
        public int X { get; private set; }
        public int Y { get; private set; }

        public TwoDPoint(int x, int y)
            : this()
        {
            X = x;
            Y = x;
        }

        public override bool Equals(object obj)
        {
            if (obj is TwoDPoint)
            {
                return this.Equals((TwoDPoint)obj);
            }
            return false;
        }

        public bool Equals(TwoDPoint p)
        {
            return (X == p.X) && (Y == p.Y);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public static bool operator ==(TwoDPoint lhs, TwoDPoint rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(TwoDPoint lhs, TwoDPoint rhs)
        {
            return !(lhs.Equals(rhs));
        }
    }
}
