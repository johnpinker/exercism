using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        return Enumerable.Range(1, max-1).Where(s => {
            foreach (var v in multiples) 
                if (v !=0 && s%v == 0) return true;
            return false;
        }).Sum();
        
    }
}