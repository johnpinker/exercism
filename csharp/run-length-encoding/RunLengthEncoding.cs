using System;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        char lastChar = char.MinValue;
        int charCount = 0;
        string retVal = "";
        for (int i=0; i < input.Length; i++)
        {
            if (lastChar == char.MinValue) 
            {
                lastChar = input[i];
                charCount = 1;
            }
            else if (input[i] == lastChar)
                charCount++;
            else 
            {
                if (charCount > 1)
                {
                    retVal += charCount + lastChar.ToString();
                    lastChar = input[i];
                    charCount = 1;
                }
                else
                {
                    retVal += lastChar;
                    lastChar = input[i];
                }
            }
        }
        if (charCount > 1) retVal += charCount + lastChar.ToString();
        else retVal += lastChar == char.MinValue ? "" : lastChar.ToString();
        return retVal;
    }

    public static string Decode(string input)
    {
        string numRepeat = "";
        string retVal = "";
        for (int i=0; i< input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                numRepeat += input[i];
            }
            else 
            {
                int numTimes = numRepeat == "" ? 1 : int.Parse(numRepeat);
                for (int j=0; j < numTimes; j++)
                    retVal += input[i];
                numRepeat = "";
            }
        }
        return retVal;
    }
}
