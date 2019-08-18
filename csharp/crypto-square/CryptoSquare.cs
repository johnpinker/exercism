using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        return new string(plaintext.Where(s => Char.IsLetterOrDigit(s)).ToArray()).ToLower();
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        int r=0;
        int c=0;
        while (r*c < plaintext.Length)
        {
            if (r==c) c++;
            else r++;
        }
        for (int i=0; i < r; i++)
        {
            int rowStart = c*i;
            //int rowEnd = rowStart + c > plaintext.Length ? plaintext.Length : rowStart + c;
            int rowEnd = rowStart + c > plaintext.Length ? plaintext.Length-rowStart : c;
            string tmpStr = plaintext.Substring(rowStart, rowEnd);
            if (tmpStr.Length != c)
                tmpStr = tmpStr.PadRight(c);
            yield return tmpStr;
        }

    }

    public static string Encoded(string plaintext)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static string Ciphertext(string plaintext)
    {
        StringBuilder sb = new StringBuilder();
        string normText = NormalizedPlaintext(plaintext);
        List<string> rows = new List<string>(PlaintextSegments(normText));
        if (rows.Count() == 0) return "";
        int cols = rows.ElementAt(0).Count();
        for (int i=0; i< cols; i++)
        {
            foreach (String s in rows)
                sb.Append(s[i]);
            if (i != cols-1) sb.Append(" ");
        }

        return sb.ToString();
    }
}