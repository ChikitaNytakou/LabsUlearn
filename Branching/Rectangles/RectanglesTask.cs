using System;

namespace Rectangles;

public static class RectanglesTask
{
    // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        bool horizontalOverlap = r1.Left <= r2.Right && r1.Right >= r2.Left;

        bool verticalOverlap = r1.Top <= r2.Bottom && r1.Bottom >= r2.Top;

        return horizontalOverlap && verticalOverlap;
    }

    // Площадь пересечения прямоугольников
    public static int IntersectionSquare(Rectangle r1, Rectangle r2)
    {
        int xIntersection = 0;
        int yIntersection = 0;
        if (AreIntersected(r1, r2)) {
            int xIntersLeftMax = Math.Max(r1.Left, r2.Left);
            int xIntersRightMin = Math.Min(r1.Right, r2.Right);
            int yIntersTopMax = Math.Max(r1.Top, r2.Top);
            int yIntersBottomMin = Math.Min(r1.Bottom, r2.Bottom);

            xIntersection = Math.Abs(xIntersRightMin - xIntersLeftMax);
            yIntersection = Math.Abs(yIntersBottomMin - yIntersTopMax);
        }
        return xIntersection * yIntersection;
    }

    // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
    // Иначе вернуть -1
    // Если прямоугольники совпадают, можно вернуть номер любого из них.
    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        if (AreIntersected(r1, r2))
        {
            if ((r1.Left <= r2.Left & r1.Right >= r2.Right) & (r1.Top <= r2.Top & r1.Bottom >= r2.Bottom)) return 1;
            else if ((r1.Left >= r2.Left & r1.Right <= r2.Right) & (r1.Top >= r2.Top & r1.Bottom <= r2.Bottom)) return 0;
            else return -1;
        }
        else return -1;
    }
}