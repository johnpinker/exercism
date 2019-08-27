using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private readonly string[] rows;
    public WordSearch(string grid)
    {
       rows = grid.Split("\n");
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        Dictionary<string, ((int, int), (int, int))?> retVal = new Dictionary<string, ((int, int), (int, int))?>();
        foreach (string word in wordsToSearchFor)
        {
            for (int r=0; r < rows.Length; r++)
            {
                for (int c=0; c< rows[0].Length; c++)
                {
                    if (rows[r][c] == word[0])
                    {
                        (int, int)? tmpPoint2 = SearchFromPoint((r, c), word);
                        ((int, int), (int, int))? tmpPoint;
                        if (tmpPoint2 != null) tmpPoint = ((c+1, r+1), (tmpPoint2.Value.Item2, tmpPoint2.Value.Item1));
                        else tmpPoint = null;
                        if (tmpPoint2 != null)
                            retVal.Add(word, tmpPoint);
                    }
                }
            }
        }
        foreach (string w in wordsToSearchFor)
            if (!retVal.ContainsKey(w)) retVal.Add(w, null);
        return retVal;
    }

    private (int, int)? SearchFromPoint((int, int) point, string word)
    {
        (int, int)? retVal;
        retVal = SearchRow(point, word);
        if (retVal != null) return retVal;
        retVal = SearchColumn(point, word);
        if (retVal != null) return retVal;
        retVal = SearchDiagonal(point, word);
        if (retVal != null) return retVal;
        return null;
    }

    private (int, int)? SearchRow((int, int) point, string word)
    {
        int j = 0;
        int i=0;
        int k=0;
        i=point.Item1;
        j=point.Item2;
        while (i < rows.Length && j < rows[i].Length && rows[i][j] == word[k])
        {
            if (k == word.Length-1) return (i+1, j+1);
            j++;
            k++;
        }
        i=point.Item1;
        j=point.Item2;
        k=0;
        while (i >= 0 && j >= 0 && rows[i][j] == word[k])
        {
            if (k == word.Length-1) return (i+1, j+1);
            j--;
            k++;
        }
        return null;
    }

    private (int, int)? SearchColumn((int, int) point, string word)
    {
        int j = 0;
        int i=0;
        int k=0;
        i=point.Item1;
        j=point.Item2;
        while (i < rows.Length && j < rows[i].Length && rows[i][j] == word[k])
        {
            if (k == word.Length-1) return (i+1, j+1);
            i++;
            k++;
        }
        i=point.Item1;
        j=point.Item2;
        k=0;
        while (i > 0 && j > 0 && rows[i][j] == word[k])
        {
            if (k == word.Length-1) return (i+1, j+1);
            i--;
            k++;
        }
        return null;
    }

    private (int, int)? SearchDiagonal((int, int) point, string word)
    {
        int j=0;
        int i=0;
        int k=0;
        i=point.Item1;
        j=point.Item2;
        while (i < rows.Length && j < rows[i].Length && rows[i][j] == word[k])
        {
            if (k == word.Length-1) return (i+1, j+1);
            i++;
            j++;
            k++;
        }
        i=point.Item1;
        j=point.Item2;
        k=0;
        while (i > 0 && j < rows[i].Length && rows[i][j] == word[k])
        {
            if (k == word.Length-1) return (i+1, j+1);
            i--;
            j++;
            k++;
        }
                i=point.Item1;
        j=point.Item2;
        k=0;
        while (i > 0 && j > 0 && rows[i][j] == word[k])
        {
            if (k == word.Length-1) return (i+1, j+1);
            i--;
            j--;
            k++;
        }
        i=point.Item1;
        j=point.Item2;
        k=0;
        while (i < rows.Length && j > 0 && rows[i][j] == word[k])
        {
            if (k == word.Length-1) return (i+1, j+1);
            i++;
            j--;
            k++;
        }
        return null;
    }
}