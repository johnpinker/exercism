using System;

public static class Bob
{
    public static string Response(string statement)
    {
        String sTrim = statement.Trim();
        if (sTrim.Length == 0)
            return "Fine. Be that way!";
        char punc = sTrim[sTrim.Length - 1];
        if (statement.ToUpper() == statement && !(statement.ToLower() == statement))
            return punc == '?' ? "Calm down, I know what I'm doing!" : "Whoa, chill out!";
        else if (punc == '?')
            return "Sure.";
        else
            return "Whatever.";

    }
}