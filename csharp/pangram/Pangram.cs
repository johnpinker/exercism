using System;
using System.Collections.Generic;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach (var c in input) 
        {
            if (dict.ContainsKey(c) && char.IsLetter(c))
                dict[char.ToUpper(c)]++;
            else if (char.IsLetter(c))
                dict[char.ToUpper(c)] = 0;
        }
        return dict.Select(s => s).Count() == 26 ? true : false;
    }
}
