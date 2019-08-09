using System;
using System.Text;
public static class House
{
    public static string Recite(int verseNumber)
    {
        return $"This is the {GetString(verseNumber)}house that Jack built.";
    }

    private static string GetString(int level)
    {
        switch (level)
        {
            case 1:
                return "";
            case 2:
                return $"malt that lay in the {GetString(level-1)}";
            case 3:
                return $"rat that ate the {GetString(level-1)}";
            case 4: 
                return $"cat that killed the {GetString(level-1)}";
            case 5:
                return $"dog that worried the {GetString(level-1)}";
            case 6:
                return $"cow with the crumpled horn that tossed the {GetString(level-1)}";
            case 7:
                return $"maiden all forlorn that milked the {GetString(level-1)}";
            case 8:
                return $"man all tattered and torn that kissed the {GetString(level-1)}";
            case 9:
                return $"priest all shaven and shorn that married the {GetString(level-1)}";
            case 10:
                return $"rooster that crowed in the morn that woke the {GetString(level-1)}";
            case 11:
                return $"farmer sowing his corn that kept the {GetString(level-1)}";
            case 12:
                return $"horse and the hound and the horn that belonged to the {GetString(level-1)}";
            default: 
                return "";
        }
    }
    public static string Recite(int startVerse, int endVerse)
    {
        StringBuilder sb = new StringBuilder();
        for (int i=startVerse; i <= endVerse; i++)
        {
            sb.Append(Recite(i)); 
            if (i != endVerse) sb.Append("\n");
        }
        return sb.ToString();
    }
}