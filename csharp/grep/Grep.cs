using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

public static class Grep
{
    private enum GrepArgs 
    {
        PrintNumbers,
        PrintFileNames,
        CaseInsensitive,
        Invert,
        OnlyMatchLines,
        NoneSelected
    }
    public static string Match(string pattern, string flags, string[] files)
    {
        string tmpLine;
        string matchLine;
        StringBuilder sb = new StringBuilder();
        List<GrepArgs> args = ParseArgs(flags);
        foreach (string file in files)
        {
             TextReader tr = File.OpenText(file);
             int lineNum = 0;
             while ((tmpLine = tr.ReadLine()) != null)
             {
                matchLine = "";
                lineNum++;
                if ((isLineMatch(tmpLine, pattern, args) && !args.Contains(GrepArgs.Invert))||
                    (args.Contains(GrepArgs.Invert) && !isLineMatch(tmpLine, pattern, args)))
                {
                    if (args.Contains(GrepArgs.PrintFileNames))
                    {
                        if (!sb.ToString().Contains(file))
                            matchLine += file;
                    }
                    else if (args.Contains(GrepArgs.PrintNumbers))
                        matchLine = lineNum + ":" + tmpLine;
                    else 
                        matchLine += tmpLine;
                }
                if (matchLine != "")
                {
                    if (sb.Length > 0) sb.Append("\n");
                    if (files.Length > 1 && !args.Contains(GrepArgs.PrintFileNames)) sb.Append(file + ":");
                    sb.Append(matchLine);
                }
                
            }
            
            tr.Dispose();
        }
       return sb.ToString();
    }


    private static bool isLineMatch(string s, string pattern, List<GrepArgs> args)
    {
        StringComparison sc;
        if (args.Contains(GrepArgs.CaseInsensitive))
            sc = StringComparison.CurrentCultureIgnoreCase;
        else 
            sc = StringComparison.CurrentCulture;
        if (args.Contains(GrepArgs.OnlyMatchLines))
            return s.Equals(pattern, sc);
        else
            return s.Contains(pattern, sc);
    }
    private static List<GrepArgs> ParseArgs(string args)
    {
        string[] argStrings = args.Split(" ");
        List<GrepArgs> argList = new List<GrepArgs>();
        foreach (String s in argStrings)
        {
            switch (s)
            {
                case "-n": argList.Add(GrepArgs.PrintNumbers); break;
                case "-l": argList.Add(GrepArgs.PrintFileNames); break;
                case "-i": argList.Add(GrepArgs.CaseInsensitive); break;
                case "-v": argList.Add(GrepArgs.Invert); break;
                case "-x": argList.Add(GrepArgs.OnlyMatchLines); break;
            }
        }
        return argList;
    }
}