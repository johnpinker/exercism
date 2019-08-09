using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span == 0) return 1;
        if ((digits.Length%span != 0 && digits.Length < span) || 
            (digits.Length == 0 && span > 0) ||
            (span < 0)
        )
            throw new ArgumentException();
        long largestSum = 0;
        long tmpInt = 1;
        int[] newDigits;
        try {
            newDigits = digits.Select(s => int.Parse(s.ToString())).ToArray(); 
        } catch (Exception e)
        {
            throw new ArgumentException();
        }
        List<int> tmpList = new List<int>();
        List<int> largestList;
        for (int i=0; i<=digits.Length-span; i++)
        {

            for (int j=span-1; j>=0; j--)
            {
                tmpList.Add(newDigits[j+i]);
                tmpInt *= newDigits[j+i];
            }
            
            if (tmpInt > largestSum)
            {
                largestSum = tmpInt;
                largestList = tmpList;
            }
            tmpList.Clear();
            tmpInt = 1;
        }
        return largestSum;
    }
}