using Avalonia.Controls;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Recognizer;

internal static class MedianFilterTask
{
    /* 
	 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
	 * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
	 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
	 * https://en.wikipedia.org/wiki/Median_filter
	 * 
	 * Используйте окно размером 3х3 для не граничных пикселей,
	 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
	 */
    public static double[,] MedianFilter(double[,] original)
    {
        var xDimension = original.GetLength(0);
        var yDimension = original.GetLength(1);
        var result = new double[xDimension, yDimension];
        var coordinateMatrix = new List<List<int>>();
        var medianMatrix = new List<double>();

        for (int x = 0; x < xDimension; x++)
            for (int y = 0; y < yDimension; y++)
            {
                coordinateMatrix = CoordinateCount(x, y, xDimension, yDimension);
                medianMatrix = MatrixCount(coordinateMatrix, original);
                result[x, y] = MedianCount(medianMatrix.ToArray());
            }

        return result;
    }

    private static List<List<int>> CoordinateCount(int x, int y, int xDimension, int yDimension)
    {
        var result = new List<List<int>>();
        var xZero = x - 1;
        var yZero = y - 1;
        for (int i = xZero; i < xZero + 3; i++)
            for (int j = yZero; j < yZero + 3; j++)
                if (i >= 0 && i < xDimension && j >= 0 && j < yDimension)
                    result.Add(new List<int>() { i, j });
        return result;
    }

    private static List<double> MatrixCount(List<List<int>> coordinateMatrix, double[,] original)
    {
        var result = new List<double>();
        foreach (var item in coordinateMatrix)
            result.Add(original[item[0], item[1]]);
        return result;
    }

    public static double MedianCount(double[] matrix)
    {
        Array.Sort(matrix);
        var middleMatrix = matrix.Length / 2;
        if (matrix.Length % 2 == 0)
            return (matrix[middleMatrix - 1] + matrix[middleMatrix]) / 2;
        middleMatrix = (int)Math.Floor((double)middleMatrix);
        return matrix[middleMatrix]; ;
    }
}
