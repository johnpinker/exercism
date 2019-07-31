using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class MatchingBrackets
{
    private static readonly char[] allowedOpenings = { '{', '[', '(' };
    private static readonly char[] allowedClosings = { '}', ']', ')' };

    public static bool IsPaired(string input)
    {
        Stack<char> openingParens = new Stack<char>();

        foreach (var c in input)
        {
            if (isOpeningParen(c))
                openingParens.Push(c);
            else if (isClosingParen(c))
            {
                char tmpC;
                if (!openingParens.TryPeek(out tmpC))
                    return false;
                else if (areParensEqual(tmpC, c))
                    openingParens.Pop();
                else
                    return false;
            }
        }
        if (openingParens.Count == 0)
            return true;
        else
            return false;
    }

    private static bool isOpeningParen(char c)
    {
        foreach (char tmpC in allowedOpenings)
            if (tmpC == c)
                return true;
        return false;
    }

    private static bool isClosingParen(char c)
    {
        foreach (char tmpC in allowedClosings)
            if (tmpC == c)
                return true;
        return false;
    }

    private static bool areParensEqual(char c1, char c2)
    {
        for (int i =0; i < allowedOpenings.Length; i++)
        {
            if (allowedOpenings[i] == c1 && allowedClosings[i] == c2)
                return true;
        }
        return false;
    }
}
