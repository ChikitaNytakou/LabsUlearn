namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
		if (count % 100 > 10 && count % 100 < 20) return "рублей";
        else if (count % 10 > 1 & count % 10 < 5) return "рубля";
		else if (count % 10 == 1) return "рубль";
		else return "рублей";
	}
}