using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Painter
    {
        static float x, y;
        static IGraphics graphics;

        public static void Initialization(IGraphics newGraphics)
        {
            graphics = newGraphics;
            //grafika.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        { x = x0; y = y0; }

        public static void MakeIt(Pen pen, double length, double angle)
        {
            //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }

        public static void DrawSide(int size, double left, double up, double right, double bottom)
        {
            Painter.MakeIt(new Pen(Brushes.Yellow), size * 0.375f, left);
            Painter.MakeIt(new Pen(Brushes.Yellow), size * 0.04f * Math.Sqrt(2), up);
            Painter.MakeIt(new Pen(Brushes.Yellow), size * 0.375f, right);
            Painter.MakeIt(new Pen(Brushes.Yellow), size * 0.375f - size * 0.04f, bottom);
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double rotationAngle, IGraphics graphics)
        {
            // ugolPovorota пока не используется, но будет использоваться в будущем
            Painter.Initialization(graphics);

            var size = Math.Min(width, height);

            var diagonalLength = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Painter.SetPosition(x0, y0);
            //Рисуем 1-ую сторону
            Painter.DrawSide(size, 0, Math.PI / 4, Math.PI, Math.PI / 2);
            
            Painter.Change(size * 0.04f, -Math.PI);
            Painter.Change(size * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);

            //Рисуем 2-ую сторону
            Painter.DrawSide(size, -Math.PI / 2, -Math.PI / 2 + Math.PI / 4, -Math.PI / 2 + Math.PI, -Math.PI / 2 + Math.PI / 2);

            Painter.Change(size * 0.04f, -Math.PI / 2 - Math.PI);
            Painter.Change(size * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

            //Рисуем 3-ю сторону
            Painter.DrawSide(size, Math.PI, Math.PI + Math.PI / 4, Math.PI + Math.PI, Math.PI + Math.PI / 2);
            
            Painter.Change(size * 0.04f, Math.PI - Math.PI);
            Painter.Change(size * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);

            //Рисуем 4-ую сторону
            Painter.DrawSide(size, Math.PI / 2, Math.PI / 2 + Math.PI / 4, Math.PI / 2 + Math.PI, Math.PI / 2 + Math.PI / 2);
            
            Painter.Change(size * 0.04f, Math.PI / 2 - Math.PI);
            Painter.Change(size * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }
    }
}