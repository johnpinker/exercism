using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> retDict = new Dictionary<string, int>();
        foreach (var k in old.Keys)
        {
            foreach (var l in old[k])
            {
                retDict[l.ToLower()] = k;
            }
        }
        return retDict;
    }
}