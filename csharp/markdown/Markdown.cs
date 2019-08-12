using System;
using System.Text.RegularExpressions;
using System.Linq;

public static class Markdown
{
    private static string Wrap(string text, string tag) => "<" + tag + ">" + text + "</" + tag + ">";

    private static string Parse(string markdown, string delimiter, string tag)
    {
        var pattern = delimiter + "(.+)" + delimiter;
        var replacement = "<" + tag + ">$1</" + tag + ">";
        return Regex.Replace(markdown, pattern, replacement);
    }

    private static string Parse__(string markdown) => Parse(markdown, "__", "strong");

    private static string Parse_(string markdown) => Parse(markdown, "_", "em");

    private static string ParseText(string markdown, bool list)
    {
        var parsedText = Parse_(Parse__((markdown)));
        if (!list)
            return Wrap(parsedText, "p");
        else 
            return parsedText;
    }

    private static string ParseHeader(string markdown)
    {
        var count = markdown.TakeWhile(c => c == '#').Count();

        if (count == 0)
        {
            return null;
        }

        var headerTag = "h" + count;
        return Wrap(markdown.Substring(count + 1), headerTag);
    }

    private static string ParseLineItem(string markdown)
    {
        return Wrap(ParseText(markdown.Substring(2), true), "li");
    }

    private static string ParseParagraph(string markdown)
    {
        return ParseText(markdown, false);
    }

    private static string ParseLine(string markdown)
    {
        switch (markdown[0])
        {
            case '#': return ParseHeader(markdown);
            case '*': return ParseLineItem(markdown);
            default: return ParseParagraph(markdown);
        }
    }

    public static string Parse(string markdown)
    {
        var lines = markdown.Split('\n');
        var result = "";
        var list = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i][0] == '*' && !list)
            {
                if (!list) result += "<ul>";
                result += ParseLineItem(lines[i]);
                list = true;
            }
            else if (lines[i][0] == '*' && list)
            {
                result += ParseLineItem(lines[i]);
            }
            else if (lines[i][0] != '*' && list)
            {
                list = false;
                result += "</ul>";
                result += ParseLine(lines[i]);
            }
            else
                result += ParseLine(lines[i]);
        }

        if (list) result += "</ul>";

        return result;
    }
}