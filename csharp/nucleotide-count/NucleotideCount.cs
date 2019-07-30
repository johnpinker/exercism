using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> dict = new Dictionary<char, int> { ['A'] = 0, ['C'] = 0, ['G'] = 0, ['T'] = 0 };
        foreach (var c in sequence) _ = dict.ContainsKey(c) == true ? dict[c]++ : throw new ArgumentException();
        
        return dict;
    }
}