using System;
using System.Linq;
public static class PigLatin
{
    public static string Translate(string word)
    {
        string[] words = word.Split(" ");
        string retVal = "";
        retVal = TranslateWord(words[0]);
        for (int i=1; i < words.Length; i++)
            retVal += " " + TranslateWord(words[i]);  
        return retVal;
    }

    private static bool IsVowell(char c)
    {
        switch(c)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o': 
            case 'u': return true;
            default: return false;
        }
    }

    private static string TranslateWord(string s)
    {
        if (IsVowell(s[0]) || s.StartsWith("xr") || s.StartsWith("yt"))
        {
            return s + "ay";
        }
        else
        {
            int i=0;
            while (!IsVowell(s[i]) || (s[i] == 'u' && IsVowell(s[i+1])))
            {
                if (s[i] == 'y' && i == 0)
                {
                    i++;
                    continue;
                } 
                else if (s[i] == 'y')
                {
                    break;
                }
                i++;
            }
            return s.Remove(0, i) + s.Substring(0, i) + "ay";
        }
    }
}