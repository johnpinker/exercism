using System;
using System.Collections.Generic;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        List<T> retList = new List<T>();
        foreach (T tmp in collection)
        {
            if (predicate(tmp))
                retList.Add(tmp);
        }
        return retList;
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        List<T> retList = new List<T>();
        foreach (T tmp in collection)
        {
            if (!predicate(tmp))
                retList.Add(tmp);
        }
        return retList;
    }
}