using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    private static List<string> proteins;
    private static readonly string[] Methionine = {"AUG"};
    private static readonly string[] Phenylalanine = {"UUU", "UUC"};
    private static readonly string[] Leucine = {"UUA", "UUG"};
    private static readonly string[] Serine = {"UCU", "UCC", "UCA", "UCG"};
    private static readonly string[] Tyrosine = {"UAU", "UAC"};
    private static readonly string[] Cysteine = {"UGU", "UGC"};
    private static readonly string[] Tryptophan = {"UGG"};
    private static readonly string[] StopProteins = {"UAA", "UAG", "UGA"};


    public static string[] Proteins(string strand)
    {
        int startIndex = 0;
        proteins = new List<string>();
        List<string> retVal = new List<string>();
        while ((startIndex = GetProtein(strand, startIndex)) != -1)
        {
        }
        foreach (var p in proteins)
        {
            if (Array.IndexOf(Methionine, p) >= 0)
                retVal.Add(nameof(Methionine));
            else if (Array.IndexOf(Phenylalanine, p) >= 0)
                retVal.Add(nameof(Phenylalanine));
            else if (Array.IndexOf(Leucine, p) >= 0)
                retVal.Add(nameof(Leucine));
            else if (Array.IndexOf(Serine, p) >= 0)
                retVal.Add(nameof(Serine));
            else if (Array.IndexOf(Tyrosine, p) >= 0)
                retVal.Add(nameof(Tyrosine));
            else if (Array.IndexOf(Cysteine, p) >= 0)
                retVal.Add(nameof(Cysteine));
            else if (Array.IndexOf(Tryptophan, p) >= 0)
                retVal.Add(nameof(Tryptophan));
            else if (Array.IndexOf(StopProteins, p) >= 0)
                break;
        }
        return retVal.ToArray();
    }

    private static int GetProtein(string strand, int startIndex)
    {
        if (startIndex+3 > strand.Length)
            return -1;
        proteins.Add(strand.Substring(startIndex, 3));
        return startIndex+3;
    }
}