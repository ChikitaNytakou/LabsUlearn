namespace Geometry
{
    public class Vector
    {
        public double X;
        public double Y;
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
    }
}