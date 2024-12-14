using System;

namespace Fractals;

internal static class DragonFractalTask
{
    public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
    {
        double x = 1;
        double y = 0;
        double xDerivative;
        double yDerivative;
        double angleFirst = 45 * Math.PI / 180;
        double angleSecond = 135 * Math.PI / 180;
        var random = new Random(seed);
        for (int i = 0; i < iterationsCount; i++)
        {
            var nextNumber = random.Next(2);
            if (nextNumber == 0)
            {
                xDerivative = (x * Math.Cos(angleFirst) - y * Math.Sin(angleFirst)) / Math.Sqrt(2);
                yDerivative = (x * Math.Sin(angleFirst) + y * Math.Cos(angleFirst)) / Math.Sqrt(2);
            }
            else
            {
                xDerivative = (x * Math.Cos(angleSecond) - y * Math.Sin(angleSecond)) / Math.Sqrt(2) + 1;
                yDerivative = (x * Math.Sin(angleSecond) + y * Math.Cos(angleSecond)) / Math.Sqrt(2);
            }
            x = xDerivative;
            y = yDerivative;
            pixels.SetPixel(x, y);
        }
    }
}