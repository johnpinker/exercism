using System;
using System.Collections.Generic;
using System.Linq;
public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        string cleanString = new String(word.Where(s => Char.IsLetter(s)).ToArray());
        string cleanString2 = new String(cleanString.Select(s => Char.ToLower(s)).ToArray());
        return cleanString2.Distinct().Count() == cleanString2.Length;
    }
}
