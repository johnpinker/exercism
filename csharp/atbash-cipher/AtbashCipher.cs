using System;
using System.Linq;
using System.Collections.Generic;

public static class AtbashCipher
{
    public static string Encode(string plainValue)
    {
        string retVal = EncodeString(plainValue);
        List<char> tmpList = new List<char>();
        for (int i=0; i<retVal.Length; i++)
        {
            if (i%5 == 0 && i != 0) tmpList.Add(' ');
            tmpList.Add(retVal[i]);
        }
        retVal = new string(tmpList.ToArray());
        return retVal;
    }

    public static string Decode(string encodedValue) => encodedValue.Replace(" ", "").EncodeString();


    private static string EncodeString(this string value) => new string(value.Select(s => {
            char c = char.ToLower(s);
            if (char.IsLetter(c))
                return (char)((25-(c-'a')) + 'a');
            else if (char.IsDigit(c))
                return c;
            else 
                return char.MinValue;
        }).ToArray()).Replace(char.MinValue.ToString(), "");
}
