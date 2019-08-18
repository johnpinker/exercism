using System;
using System.Collections.Generic;
public static class ScaleGenerator
{

    private static bool UseSharps(string tonic)
    {
        List<string> sharpList = new List<string>() { "C", "G", "D", "A", "E", "B", "F#", "e", "b", "f#", "c#", "g#", "d#", "a" };
        List<string> flatList = new List<string>() {"F", "Bb", "Eb", "Ab", "Db", "Gb", "d", "g", "c", "f", "bb", "eb" };
        if (sharpList.Contains(tonic)) return true;
        else if (flatList.Contains(tonic)) return false;
        else throw new ArgumentException("Unknown Tonic");
    }
    public static string[] Chromatic(string tonic)
    {
        List<string> retVal = new List<string>();
        bool isSharps = UseSharps(tonic);
        retVal.Add(tonic);
        string lastNote = tonic;
        for (int i=1; i< 12; i++)
        {
            string tmpNote = AddInterval(lastNote, isSharps);
            retVal.Add(tmpNote);
            lastNote = tmpNote;
        }
        return retVal.ToArray();
    }

    public static string[] Interval(string tonic, string pattern)
    {
        List<string> retVal = new List<string>();
        bool isSharps = UseSharps(tonic);
        string lastNote = ((char)tonic[0]).ToString().ToUpper();
        lastNote +=  tonic.Length > 1 ? tonic.Substring(1,1) : "";

        retVal.Add(lastNote);
        for (int i=0; i< pattern.Length-1; i++)
        {
            string tmpNote;
            if (pattern[i] == 'm') tmpNote = AddInterval(lastNote, isSharps);
            else if (pattern[i] == 'M') 
            {
                tmpNote = AddInterval(lastNote, isSharps);
                tmpNote = AddInterval(tmpNote, isSharps);
            }
            else 
            {
                tmpNote = AddInterval(lastNote, isSharps);
                tmpNote = AddInterval(tmpNote, isSharps);
                tmpNote = AddInterval(tmpNote, isSharps);
            }
            retVal.Add(tmpNote);
            lastNote = tmpNote;
        }
        return retVal.ToArray();
    }

    private static string AddInterval(string root, bool useSharps)
    {
        char rootChar = root[0];
        bool isFlat = root.Contains("b");
        bool isSharp = root.Contains("#");
        switch (rootChar) 
        {
            case 'A': 
            case 'C':
            case 'D':
            case 'F':
            case 'G':
            {
                if (isFlat) return rootChar.ToString();
                else if (isSharp) return (IncNote(rootChar)).ToString();
                else return useSharps ? (rootChar.ToString() + "#") : (IncNote(rootChar) + "b");
            }
            case 'B':
            case 'E':
            {
                if (isFlat) return rootChar.ToString();
                else return IncNote(rootChar);
            }
        }
        throw new ArgumentException("unknown interval");
    }

    private static string IncNote(char c)
    {
        if("G".Contains(c))
            return "A";
        else 
            return ((char)(c+1)).ToString();
    }
}