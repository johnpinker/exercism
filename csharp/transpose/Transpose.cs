using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public static class Transpose
{
    public static string String(string input)
    {
        StringBuilder sb = new StringBuilder();
        string[] lines = input.Split("\n");
        int longestLine =lines.Select(s => s.Length).Max();
        for (int i=0; i<longestLine; i++)
        {
            for (int j=0; j <= LastLineWithChars(lines, i); j++)
            {
                sb.Append( i < lines[j].Length ? lines[j][i].ToString() : " ");
            }
            if (i < longestLine-1) sb.Append("\n");
        }
        return sb.ToString();
    }

    private static int LastLineWithChars(string[] lines, int index)
    {
        int retVal = 0;
        for (int i=0; i< lines.Length; i++)
        {
            if (lines[i].Length > index)
                retVal = i;
        }
        return retVal;
    }
}