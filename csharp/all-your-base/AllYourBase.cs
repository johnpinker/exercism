using System;
using System.Collections.Generic;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2 || outputBase < 2)
            throw new ArgumentException();
        if (inputDigits.Length == 0)
            return new int[1] { 0 };
        List<int> retList = new List<int>();
        int j=0;
        int tmpInt = 0;
        int remainder = 0;
        for (int i=inputDigits.Length-1; i >= 0; i--)
        {
            if (inputDigits[i] >= inputBase || inputDigits[i] < 0) throw new ArgumentException();
            tmpInt += inputDigits[i] * (int)Math.Pow(inputBase, inputDigits.Length-i-1);
        }
        if (tmpInt == 0) return new int[1] {0};
        while (tmpInt > 0)
        {
            remainder = tmpInt%outputBase;
            tmpInt = tmpInt / outputBase;
            retList.Add(remainder);
        }
        retList.Reverse();
        return retList.ToArray();
    }
}