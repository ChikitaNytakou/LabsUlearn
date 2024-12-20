using System.Collections.Generic;
using Avalonia.Media;
using Geometry;

//Напишите здесь код, который заставит работать методы segment.GetColor и segment.SetColor

namespace GeometryPainting
{
    public static class SegmentExtensions
    {
        public static Dictionary<Segment, Color> dicionary = new Dictionary<Segment, Color>();
        public static Color GetColor(this Segment segment)
        {
            if (!dicionary.ContainsKey(segment)) return Colors.Black;
            else return dicionary[segment];
        }

        public static void SetColor(this Segment segment, Color color)
        {
            dicionary[segment] = color;
        }
    }
}

