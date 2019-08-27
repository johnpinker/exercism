using System;
using System.Collections.Generic;
using System.Linq;

public static class NthPrime
{
    public static int Prime(int nth)
    {
        if (nth <= 0) throw new ArgumentOutOfRangeException();
        int limit = nth == 1 ? 2 : nth*nth;
        return Primes(limit).Skip(nth-1).First();
    }

    public static IEnumerable<int> Primes(int limit)
    {
        bool isPrime = false;
        foreach (int i in Enumerable.Range(2, limit))
        {
            isPrime = true;
            for (int p=2; p < Math.Sqrt(i)+1; p++)
            {
                if (i != p && i%p == 0) isPrime = false;
            }
            if (isPrime) 
                yield return i;
        }
    }

}