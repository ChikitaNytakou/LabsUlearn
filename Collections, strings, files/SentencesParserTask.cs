namespace TextAnalysis;

static class SentencesParserTask
{
    public static List<List<string>> ParseSentences(string text)
    {
        var sentencesList = new List<List<string>>();
        char[] separatorsSentences = new char[] { '.', '!', '?', ';', ':', '(', ')' };
        var sentences = text.Replace("\u00A0", "").Split(separatorsSentences, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].Length == 0) { continue; }
            var words = ParseWords(sentences[i]);
            if (words.Count != 0)
                sentencesList.Add(words);
        }
        return sentencesList;
    }

    public static List<string> ParseWords(string sentence)
    {
        var wordsList = new List<string>();
        char[] separatorsWords = {'^', '#', '$', '-', '—', '+',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','=', 
            '\t', '\n', '\r', ',', '…', '“', '”', '<', '>', '‘', '*', ' ', '/'};
        var words = sentence.Split(separatorsWords, StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            if (words.Length != 0)
                wordsList.Add(word.ToLower());
        }
        return wordsList;
    }
}