using System;

namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var days = new string[31];
<<<<<<< HEAD
        for (int i = 0; i < days.Length; i++) {
=======
        for (int i = 0; i < days.Length; i++)
        {
>>>>>>> branchFromNames
            days[i] = (i + 1).ToString();
        }
        var birthsCounts = new double[31];
        for (int i = 2; i <= birthsCounts.Length; i++)
        {
            for (int j = 0; j < names.Length; j++)
            {
                if (name == names[j].Name && names[j].BirthDate.Day == i)
                {
                    birthsCounts[names[j].BirthDate.Day - 1]++;
                }
            }
        }
        return new HistogramData($"Рождаемость людей с именем '{name}'", days, birthsCounts);
    }
}