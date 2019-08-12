using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        int count=0;
        foreach (T tmp in input)
            count++;
        return count;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        List<T> tmpList = new List<T>();
        foreach (T tmp in input)
            tmpList.Insert(0, tmp);
        return tmpList;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        List<TOut> tmpList = new List<TOut>();
        foreach (TIn tmp in input)
            tmpList.Add(map(tmp));
        return tmpList;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        List<T> tmpList = new List<T>();
        foreach (T tmp in input)
            if (predicate(tmp))
                tmpList.Add(tmp);
        return tmpList;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        TOut retVal = start;
        for (int i=0; i< input.Count; i++)
            retVal = func(retVal, input[i]);
        return retVal;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        TOut retVal = start;
        for (int i=input.Count-1; i>=0; i--)
            retVal = func(input[i], retVal);
        return retVal;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        List<T> tmpList = new List<T>();
        foreach (List<T> l in input)
            foreach (T tmp in l)
                tmpList.Add(tmp);
        return tmpList;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        List<T> tmpList = new List<T>();
        foreach (T tmp in left)
            tmpList.Add(tmp);
        foreach (T tmp in right)
            tmpList.Add(tmp);
        return tmpList;
    }
}