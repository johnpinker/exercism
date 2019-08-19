using System;

public static class OcrNumbers
{
    public static string Convert(string input)
    {
        string[] rows = input.Split("\n");
        if (rows.Length%4 != 0 || rows[0].Length%3 != 0) throw new ArgumentException();
        string retVal = "";
        int tmpInt ;
        for (int j=0; j < rows.Length; j += 4)
        {
            if (j != rows.Length -1 && j > 0) retVal += ",";
            for (int i=0; i < rows[j].Length; i += 3)
            {
                tmpInt = ParseDigit(rows[j].Substring(i, 3), rows[j+1].Substring(i, 3), rows[j+2].Substring(i, 3));
                retVal += tmpInt == -1 ? "?" : tmpInt.ToString();
            }
        }
        return retVal;
    }

    private static int ParseDigit(string s1, string s2, string s3)
    {
        if (s1 == "   ") // can only be 1 or 4
        {
            if (s2 == "  |" && s3 == "  |") return 1;
            else if (s2 == "|_|" && s3 == "  |") return 4;
        }
        else if (s1 == " _ ") // 23567890
        {
            if (s2 == " _|") //23
            {
                if (s3 == "|_ ") return 2;
                else if (s3 == " _|") return 3;
            }
            else if (s2 == "|_ ") //56
            {
                if (s3 == " _|") return 5;
                else if (s3 == "|_|") return 6;
            }
            else if (s2 == "  |") // 7
            {
                if (s3 == "  |") return 7;
            }
            else if (s2 == "|_|") // 489
            {
                if (s3 == "  |") return 4;
                else if (s3 == "|_|") return 8;
                else if (s3 == " _|") return 9;
            }
            else if (s2 == "| |")//0
            {
                if (s3 == "|_|") return 0;
            }
        }
        return -1;

    }
}