using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static int[] Factors(long number)
    {
        List<int> retList = new List<int>();
        long n = number;
        while (n%2 ==0)
        {
            retList.Add(2);
            n /= 2;
        }
        for (int i=3; i <= Math.Sqrt(n); i += 2)
            while (n%i == 0)
            {
                retList.Add((int)i);
                n /= i;
            }
        if (n > 2)
            retList.Add((int)n);
        return retList.ToArray();
    }
}