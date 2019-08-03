using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string s = number.ToString();
        int retVal = 0;
        for (int i =0; i < s.Length; i++) 
        {
            retVal += (int)Math.Pow(Char.GetNumericValue(s[i]), s.Length);
        }
        return retVal == number;
    }
}