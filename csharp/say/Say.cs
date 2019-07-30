using System;
using System.Collections.Generic;

public static class Say
{


    public static string InEnglish(long number)
    {
        if (number == 0) return sayOnes(0);
        if (number < 0 || number > 999999999999) throw new ArgumentOutOfRangeException();
        List<Tuple<int, int>> numberList = ProcessNumber(number);
        string returnText = "";
        bool isTens = false;
        bool wasZeros = false;
        //foreach (var digit in numberList) returnText += $"{digit.Item1},{digit.Item2}:";
        foreach (var digit in numberList)
        {
            if (isTens) { returnText += sayTens(digit.Item1); isTens = false; continue; }
            else if (digit.Item1 == 1 && TruePlace(digit.Item2) == 2) { isTens = true; continue; }

            if (returnText.EndsWith('y') && TruePlace(digit.Item2) == 1 && digit.Item1 != 0) returnText += "-";
            else if (returnText.Length > 1 && digit.Item1 != 0) returnText += " ";

            if (digit.Item1 == 0)
            {
                if (TruePlace(digit.Item2) == 3) wasZeros = true;
                else if (TruePlace(digit.Item2) == 2 && wasZeros) wasZeros = true;
                else if (TruePlace(digit.Item2) == 1 && wasZeros) wasZeros = true;
            }
            else wasZeros = false;

            returnText += ProcessDigit(digit);
            returnText += !wasZeros ? AddScale(digit.Item2) : "";
        }
        return returnText;
    }

    public static List<Tuple<int, int>> ProcessNumber(long number)
    {
        List<Tuple<int, int>> tmpList = new List<Tuple<int, int>>();
        string tmpStr = number.ToString();
        for (int i = 0; i < tmpStr.Length; i++)
        {
            Tuple<int, int> newEntry = new Tuple<int, int>(tmpStr[i] - '0', tmpStr.Length - i);
            tmpList.Add(newEntry);
        }
        return tmpList;
    }

    public static string AddScale(int digitPlace)
    {
        switch (digitPlace)
        {
            case 4: return " thousand";
            case 7: return " million";
            case 10: return " billion";
            default: return "";
        }
    }
   

    public static string ProcessDigit(Tuple<int, int> digit)
    {
        string retMessage = "";
        if (digit.Item1 == 0) return retMessage;
        switch (TruePlace(digit.Item2))
        {
            case 3:
                retMessage += sayOnes(digit.Item1) + " hundred";
                break;
            case 2:
                retMessage += sayTenDigit(digit.Item1);
                break;
            case 1:
                retMessage += sayOnes(digit.Item1);
                break;
            default:
                retMessage += "errorPRocess";
                break;
        }

        return retMessage;
    }

    private static int TruePlace(int place)
    {
        if (place % 3 == 0) return 3;
        else if (place % 3 == 5%3) return 2;
        else return 1;
    }

    private static string sayOnes(int number)
    {
        switch (number)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            default: return "onesError";
        }
    }

    private static string sayTenDigit(int number)
    {
        switch (number)
        {
            case 2: return "twenty";
            case 3: return "thirty";
            case 4: return "forty";
            case 5: return "fifty";
            case 6: return "sixty";
            case 7: return "seventy";
            case 8: return "eighty";
            case 9: return "ninety";
            default: return "tenDigitError";
        }
    }

    private static string sayTens(int number)
    {
        switch (number)
        {
            case 0: return "ten";
            case 1: return "eleven";
            case 2: return "twelve";
            case 3: return "thirteen";
            case 4: return "fourteen";
            case 5: return "fifteen";
            case 6: return "sixteen";
            case 7: return "seventeen";
            case 8: return "eighteen";
            case 9: return "nineteen";
            default: return "tensError";
        }
    }
}
