using System;
using System.Collections.Generic;
using System.Linq;
public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        if (list1.SequenceEqual(list2))
            return SublistType.Equal;
        if (IsSubset(list1, list2))
            return SublistType.Superlist;
        if ((IsSubset(list2, list1)))
            return SublistType.Sublist;
        return SublistType.Unequal;
    }

    private static bool IsSubset<T>(List<T> listToCheck, List<T> subsetList)
    {
       
        int i=0,j=0;
        while (i < subsetList.Count && j < listToCheck.Count)
        {
            while ((i < subsetList.Count && j < listToCheck.Count) && 
            subsetList.ElementAt(i).Equals(listToCheck.ElementAt(j))) 
            {
                i++;
                j++;
            }
            if (i == subsetList.Count)
                return true;
            else 
            {
                j -= i;
                i=0;
            }
            j++;
        }
        if (i == subsetList.Count)
            return true;
        else
            return false;
    }
}