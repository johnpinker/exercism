using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2)
            throw new ArgumentOutOfRangeException();
        Dictionary<int, bool> numList = new Dictionary<int, bool>();
        foreach (var i in Enumerable.Range(2, limit))
            numList.Add(i, true);
        foreach (var n in numList.Keys.ToList())
        {
            if (numList[n] == true)
            {
                foreach (var j in Enumerable.Range(n, limit))
                {
                    if (j*n <= limit)
                        numList[j*n] = false;
                }
            }
        }
        return numList.Where(k => k.Value == true && k.Key <= limit).Select(s => s.Key).ToArray();
    }
}