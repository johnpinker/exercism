using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        if (CheckChain(dominoes.ToList())) return true;
        List<(int, int)> chain = new List<(int, int)>();
        return (TryChain(chain, dominoes.ToList()));
    }

    private static bool Fits(List<(int, int)> dominoes, (int,int) toTry)
    {
        if (dominoes.Count() == 0)
            return true;
        else if (dominoes.Last().Item2 == toTry.Item1)
            return true;
        else 
            return false;
    }
    private static bool TryChain(List<(int,int)> currChain, List<(int,int)> poolChain)
    {
        if (poolChain.Count() == 0 && CheckChain(currChain)) return true;
        
        foreach ((int, int) d in poolChain.ToList())
        {
            if (Fits(currChain, d))
            {
                poolChain.Remove(d);
                currChain = currChain.Append(d).ToList();
                if (TryChain(currChain, poolChain) ==  false)
                {
                    currChain.Remove(d);
                    poolChain.Add(d);
                }
                else return true;
            }
            else if (Fits(currChain, (d.Item2, d.Item1)))
            {
                poolChain.Remove(d);
                currChain = currChain.Append((d.Item2, d.Item1)).ToList();
                if (TryChain(currChain, poolChain) == false)
                {
                    currChain.Remove((d.Item2, d.Item1));
                    poolChain.Add(d);
                }
                else return true;
            }
        }
        return false;
    }

    private static bool CheckChain(List<(int, int)> toCheck)
    {
        if (toCheck.Count() == 0) return true;
        for (int i=1; i< toCheck.Count; i++)
        {
            if (toCheck[i].Item1 != toCheck[i-1].Item2)
                return false;
        }
        if (toCheck[0].Item1 != toCheck[toCheck.Count-1].Item2)
            return false;
        return true;
    }
}