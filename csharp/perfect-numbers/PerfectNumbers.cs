using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        int sumVal = 0;
        if (number <= 0)
            throw new ArgumentOutOfRangeException();
        sumVal = Enumerable.Range(1, number-1).Where(s => number%s == 0).Sum();
        switch (sumVal.CompareTo(number))
        {
            case 0: 
                return Classification.Perfect;
            case 1:
                return Classification.Abundant;
            case -1:
                return Classification.Deficient;
            default:
                throw new ArgumentException();
        }
    }
}
