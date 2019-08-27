using System;
using System.Collections.Generic;
using System.Linq;
public static class Luhn
{
    public static bool IsValid(string number)
    {
        string cleanedString = number.Replace(" ", "");
        if (number.Where(s => Char.IsDigit(s)).ToArray().Count() != cleanedString.Length) return false;
        if (cleanedString.Length <= 1) return false;
        int[] newVals = new int[cleanedString.Length];
        int j=1;
        for (int i=cleanedString.Length-1; i >= 0; i--, j++)
        {
            newVals[i] = int.Parse(cleanedString[i].ToString());
            if (j%2 == 0)
            {
                int tmpInt = newVals[i] * 2;
                newVals[i] = tmpInt > 9 ? tmpInt - 9 : tmpInt;
            }
        }
        return newVals.Sum()%10 == 0;
    }
}