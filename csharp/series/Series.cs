using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength > numbers.Length || sliceLength <= 0 || numbers.Length == 0)
            throw new ArgumentException();
        int i = 0;
        List<string> lst = new List<string>();
        while (i <= numbers.Length-sliceLength)
        {
            lst.Add(numbers.Substring(i, sliceLength));
            i++;
        }
        return lst.ToArray();
    }
}