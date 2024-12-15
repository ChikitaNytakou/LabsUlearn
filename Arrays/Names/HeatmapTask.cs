using System.Xml.Linq;

namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        var days = new string[30];
        var months = new string[12];
        double[,] birthsCounts = new double[days.Length, months.Length];
        for (int i = 0; i < days.Length; i++)
        {
            days[i] = (i + 2).ToString();
            if (i < 12)
                months[i] = (i + 1).ToString();
        }
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].BirthDate.Day == 1) continue;
            birthsCounts[names[i].BirthDate.Day - 2, names[i].BirthDate.Month - 1]++;
        }
        return new HeatmapData(
            "Тепловая карта рождаемости в зависимости от дня и месяца",
            birthsCounts,
            days,
            months);
    }
}