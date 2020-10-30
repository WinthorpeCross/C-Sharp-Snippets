
using System;

namespace Value_Equality_Class_Example
{
    // For the sake of simplicity, assume a ThreeDPoint IS a TwoDPoint.
    public class ThreeDPoint : TwoDPoint, IEquatable<ThreeDPoint>
    {
        public int Z { get; private set; }

        public ThreeDPoint(int x, int y, int z)
            : base(x, y)
        {
            if ((z < 1) || (z > 2000))
            {
                throw new System.ArgumentException("Point must be in range 1 - 2000");
            }
            this.Z = z;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ThreeDPoint);
        }

        public bool Equals(ThreeDPoint p)
        {
            // If parameter is null, return false.
            if (Object.ReferenceEquals(p, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            // Check properties that this class declares.
            if (Z == p.Z)
            {
                // Let base class check its own fields
                // and do the run-time type comparison.
                return base.Equals((TwoDPoint)p);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (X * 0x100000) + (Y * 0x1000) + Z;
        }

        public static bool operator ==(ThreeDPoint lhs, ThreeDPoint rhs)
        {
            // Check for null.
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles the case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ThreeDPoint lhs, ThreeDPoint rhs)
        {
            return !(lhs == rhs);
        }
    }
}
