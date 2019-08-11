using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        Dictionary<string, int> list = new Dictionary<string, int>();
        Regex r = new Regex(@"([^\n, .':\W]*[\w']+[^' .,\W]*)");
        foreach (Match s in r.Matches(phrase))
        {
            // ugly - couldn't get head/tail \' removed from words
            string word = s.Value.ToLower();
            if (word == "") continue;
            if (word[0] == '\'') word = word.Substring(1);
            if (word[word.Length-1] == '\'') word = word.Substring(0, word.Length-1);
            if (list.TryGetValue(word, out int tmpInt))
                list[word]++;
            else 
                list.Add(word, 1);
        }
        return list;
    }
}