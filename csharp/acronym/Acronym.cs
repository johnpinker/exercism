using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        string[] words = phrase.Replace('-', ' ').Split(' ').Where(s => s != "").ToArray();
        var t = words.Select(s => s.SkipWhile(v => !char.IsLetter(v)).ElementAt(0));
        return string.Concat(t).ToUpper();
    }
}