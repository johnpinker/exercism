using System;
using System.Collections.Generic;
using System.Linq;
public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        List<int> change = new List<int>();

        if (target == 0) return new List<int>().ToArray();
        if (target < 0) throw new ArgumentException();
        int[] amount = new int[target+1];
        int[] coinsChosen = new int[target+1];
        Array.Fill(amount, 0);
        Array.Fill(coinsChosen, 0);

        for (int amt=1; amt <= target; amt++)
        {
            int temp = int.MaxValue;
            amount[amt] = int.MaxValue;
            for (int c=0; c < coins.Length; c++)
            {
                 if (coins[c] <= amt)
                {
                    int tmp_amt = amount[amt-coins[c]] == int.MaxValue ? int.MaxValue : amount[amt-coins[c]] + 1;
                    if (tmp_amt < temp)
                    {
                        temp = tmp_amt;
                        amount[amt] = temp;
                        coinsChosen[amt] = coins[c];
                    }
                }

            }
        }
        int i = target;

        if (coinsChosen.Max() == 0 || amount[target] == int.MaxValue) throw new ArgumentException();
        while (i > 0)
        {
            change.Add(coinsChosen[i]);
            i -= coinsChosen[i];
        }
        return change.ToArray();
    }
}