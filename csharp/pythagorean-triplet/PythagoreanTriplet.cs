using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        for (int i=1; i <= sum/3; i++)
        {
            for (int j=1; j <= sum/2; j++)
            {
                int k = sum-i-j;
                if (i + j + k == sum && i*i + j*j == k*k && ((i < j) && (j < k)))
                    yield return (i, j, k);
            }
        }
    }
}