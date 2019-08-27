using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int,int)>) Largest(int minFactor, int maxFactor)
    {
        Dictionary<int, List<(int, int)>> factors = new Dictionary<int, List<(int, int)>>();
        if (minFactor >= maxFactor) throw new ArgumentException();
        for (int i=minFactor; i <= maxFactor; i++)
            for (int j=minFactor; j <= maxFactor; j++)
            {
                int tmpInt = i*j;
                if (isPal(tmpInt))
                {
                    if (factors.Keys.Contains(tmpInt))
                    {
                        if (!factors[tmpInt].Contains((i, j)) && !factors[tmpInt].Contains((j, i)))
                            factors[tmpInt].Add((i, j));
                    }
                    else
                        factors.Add(tmpInt, new List<(int, int)>() {(i, j)});
                }
            }
        if (factors.Count() == 0) throw new ArgumentException();
        int lowest = factors.Keys.Max();
        return (lowest, factors[lowest]);
    }

    public static (int, IEnumerable<(int,int)>) Smallest(int minFactor, int maxFactor)
    {
        if (minFactor >= maxFactor) throw new ArgumentException();
        Dictionary<int, List<(int, int)>> factors = new Dictionary<int, List<(int, int)>>();
        for (int i=minFactor; i <= maxFactor; i++)
            for (int j=minFactor; j <= maxFactor; j++)
            {
                int tmpInt = i*j;
                if (isPal(tmpInt))
                {
                    if (factors.Keys.Contains(tmpInt))
                    {
                        if (!factors[tmpInt].Contains((i, j)) && !factors[tmpInt].Contains((j, i)))
                            factors[tmpInt].Add((i, j));
                    }
                    else
                        factors.Add(tmpInt, new List<(int, int)>() {(i, j)});
                }
            }
        if (factors.Count() == 0) throw new ArgumentException();
        int lowest = factors.Keys.Min();
        return (lowest, factors[lowest]);
    }

    private static bool isPal(int d)
    {
        string s = d.ToString();
        int i =0, j=s.Length-1;
        while (i < j)
        {
            if (s[i] != s[j])
                return false;
            else
            {
                i++; 
                j--;
            }
        }
        return true;
    }
}
