using System;
using System.Text;

public static class TwelveDays
{
    public static string Recite(int verseNumber)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"On the {GetNumberName(verseNumber)} day of Christmas my true love gave to me: {RetVerse(verseNumber)}.");
        return sb.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        StringBuilder sb = new StringBuilder();
        for (int i=startVerse; i<= endVerse; i++)
        {
            sb.Append(Recite(i));
            if (i != endVerse) sb.Append("\n");
        }
        return sb.ToString();
    }

    public static string RetVerse(int verse)
    {
        switch (verse)
        {
            case 1: return "a Partridge in a Pear Tree";
            case 2: return $"two Turtle Doves, and {RetVerse(verse-1)}";
            case 3: return $"three French Hens, {RetVerse(verse-1)}";
            case 4: return $"four Calling Birds, {RetVerse(verse-1)}";
            case 5: return $"five Gold Rings, {RetVerse(verse-1)}";
            case 6: return $"six Geese-a-Laying, {RetVerse(verse-1)}";
            case 7: return $"seven Swans-a-Swimming, {RetVerse(verse-1)}";
            case 8: return $"eight Maids-a-Milking, {RetVerse(verse-1)}";
            case 9: return $"nine Ladies Dancing, {RetVerse(verse-1)}";
            case 10: return $"ten Lords-a-Leaping, {RetVerse(verse-1)}";
            case 11: return $"eleven Pipers Piping, {RetVerse(verse-1)}";
            case 12: return $"twelve Drummers Drumming, {RetVerse(verse-1)}";
            default: return "";
        }
    }
    public static string GetNumberName(int num)
    {
        switch (num)
        {
            case 1: return "first";
            case 2: return "second";
            case 3: return "third";
            case 4: return "fourth";
            case 5: return "fifth";
            case 6: return "sixth";
            case 7: return "seventh";
            case 8: return "eighth";
            case 9: return "ninth";
            case 10: return "tenth";
            case 11: return "eleventh";
            case 12: return "twelfth";            
            default: return "";
        }
    }
}