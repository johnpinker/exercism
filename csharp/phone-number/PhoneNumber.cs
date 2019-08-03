using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        string retVal = "";
        retVal = Regex.Replace(phoneNumber, @"[ \(\)\+-\.]", "");
        retVal = retVal.StartsWith('1') ? retVal.Substring(1) : retVal;
        if (retVal.Length != 10 || retVal[0] == '0' || retVal[0] == '1' || retVal[3] == '0' || retVal[3] =='1')
            throw new ArgumentException();
        return retVal;
    }
}