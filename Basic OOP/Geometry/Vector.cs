using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Geometry
{
    public class Vector
    {
        public double X;
        public double Y;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector vector2)
        {
            return Geometry.Add(this, vector2);
        }

        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
    }

    public class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            Vector vectorSum = new Vector();
            vectorSum.X = vector1.X + vector2.X;
            vectorSum.Y = vector1.Y + vector2.Y;
            return vectorSum;
        }

        public static double GetLength(Segment segment)
        {
            return Math.Sqrt(Math.Pow(segment.End.X - segment.Begin.X, 2)
                            + Math.Pow(segment.End.Y - segment.Begin.Y, 2));
        }
        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            double dist1 = Math.Sqrt(Math.Pow(segment.Begin.X - vector.X, 2)
                            + Math.Pow(segment.Begin.Y - vector.Y, 2));
            double dist2 = Math.Sqrt(Math.Pow(segment.End.X - vector.X, 2)
                + Math.Pow(segment.End.Y - vector.Y, 2));
            return dist1 + dist2 == GetLength(segment);    
        }
    }
}