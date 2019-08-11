using System;
using System.Collections.Generic;
using System.Linq;
public class Anagram
{
    private string _word {get; set;}
    public Anagram(string baseWord)
    {
        _word=baseWord;
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> matches = new List<string>();
        foreach (string s in potentialMatches)
            if (new string(s.ToUpper().OrderBy(c => c).ToArray()) == new string(_word.ToUpper().OrderBy(c2 => c2).ToArray()) &&
                (s.ToUpper() != _word.ToUpper()))
            matches.Add(s);
        return matches.ToArray();
    }
}