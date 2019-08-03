using System;

public static class ScrabbleScore
{
    private static readonly char[] ValueOne = {'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T' };
    private static readonly char[] ValueTwo = {'D', 'G' };
    private static readonly char[] ValueThree = {'B', 'C', 'M', 'P' };
    private static readonly char[] ValueFour = {'F', 'H', 'V', 'W', 'Y' };
    private static readonly char[] ValueFive = {'K'};
    private static readonly char[] ValueEight = {'J', 'X' };
    private static readonly char[] ValueTen = {'Q', 'Z'};
    public static int Score(string input)
    {
        int score = 0;
        foreach (var tmpC in input)
        {
            char c = Char.ToUpper(tmpC);
            if (Array.IndexOf(ValueOne, c) >= 0)
                score += 1;
            else if (Array.IndexOf(ValueTwo, c) >= 0)
                score += 2;
            else if (Array.IndexOf(ValueThree, c) >= 0)
                score += 3;
            else if (Array.IndexOf(ValueFour, c) >= 0 )
                score += 4;
            else if (Array.IndexOf(ValueFive, c) >= 0)
                score += 5;
            else if (Array.IndexOf(ValueEight, c) >= 0)
                score += 8;
            else if (Array.IndexOf(ValueTen, c) >= 0)
                score += 10;
        }
        return score;
    }
}