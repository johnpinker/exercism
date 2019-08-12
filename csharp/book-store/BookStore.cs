using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    private static readonly double BasePrice = 8.0;
    public static decimal Total(IEnumerable<int> books)
    {
        int[] hist = new int[5] { 0, 0, 0, 0, 0};
        for (int i=0; i< 5; i++)
            hist[i] = books.Where(s => s== i+1).Count();
        int sum = hist.Sum();
        Decimal retVal = 0m;
        List<int> groupList = new List<int>();
        while (sum > 0)
        {
            int groupCount = 0;
            for (int i=0; i < 5; i++)
            {
                if (hist[i] >= 1)
                {
                    groupCount++;
                    hist[i]--;
                }
            }
            groupList.Add(groupCount);
            sum = hist.Sum();
        }
        while (groupList.Contains(5) && groupList.Contains(3))
        {
            groupList[groupList.IndexOf(5)]--;
            groupList[groupList.IndexOf(3)]++;
        }
        foreach (var v in groupList)
            retVal += GetGroupPrice(v);
        return retVal;
    }

    private static Decimal GetGroupPrice(int group)
    {
        switch (group)
        {
            case 0: return 0m;
            case 1: return new Decimal(BasePrice);
            case 2: return new Decimal(BasePrice*2.0*0.95);
            case 3: return new Decimal(BasePrice*3*.90);
            case 4: return new Decimal(BasePrice*4*0.80);
            case 5: return new Decimal(BasePrice*5*0.75);
            default: throw new InvalidOperationException();
        }
    }
}