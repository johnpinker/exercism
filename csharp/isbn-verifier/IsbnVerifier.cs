using System;
using System.Collections.Generic;
using System.Linq;
public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        if (number == "") return false;
        bool isXCheck = number[number.Length-1] == 'X' ? true : false;
        int total = 0;
        string cleanedString = new string (number.Where(s => char.IsDigit(s)).ToArray());
        if (!(cleanedString.Length == 10 && !isXCheck) && !(cleanedString.Length == 9 && isXCheck))
            return false;
        for (int i=0; i < 9; i++)
            total += int.Parse(cleanedString[i].ToString()) * (10-i);
        if (isXCheck) total += 10;
        else total += int.Parse(cleanedString[cleanedString.Length-1].ToString());
        if (total%11 == 0) 
            return true;
        else
            return false;
    }
}