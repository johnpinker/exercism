using System;
using System.Text;

public static class FoodChain
{
    public static string Recite(int verseNumber)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"I know an old lady who swallowed a {GetAnimal(verseNumber)}.\n");
        if (verseNumber == 8)
        {
            sb.Append("She's dead, of course!");
            return sb.ToString();
        }
        sb.Append(GetSecondLine(verseNumber));
        if (verseNumber == 2) sb.Append("It ");
        sb.Append(GetRecursiveText(verseNumber));
        sb.Append($"I don't know why she swallowed the {GetAnimal(1)}. Perhaps she'll die.");

        return sb.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        StringBuilder sb = new StringBuilder();
        for (int i=startVerse; i <= endVerse; i++)
        {
            sb.Append(Recite(i));
            if (i != endVerse) sb.Append("\n\n");
        }
        return sb.ToString();
    }

    static string GetRecursiveText(int verse)
    {
        if (verse == 1) return "";
        string recString = GetRecursiveText(verse-1);
        if (verse == 2)
            return $"wriggled and jiggled and tickled inside her.\n" +
                "She swallowed the spider to catch the fly.\n";
        else 
            return $"She swallowed the {GetAnimal(verse)} to catch the {GetAnimal(verse-1)}{(verse==3 ? " that " : ".\n")}{recString}";
    }

    static string GetSecondLine(int verse)
    {
        switch (verse)
        {
            case 3: return "How absurd to swallow a bird!\n";
            case 4: return  "Imagine that, to swallow a cat!\n";
            case 5: return "What a hog, to swallow a dog!\n";
            case 6: return "Just opened her throat and swallowed a goat!\n";
            case 7: return "I don't know how she swallowed a cow!\n";

        }
        return "";
    }
    public static string GetAnimal(int verse)
    {
        switch (verse) 
        {
            case 1: return "fly";
            case 2: return "spider";
            case 3: return "bird";
            case 4: return "cat";
            case 5: return "dog";
            case 6: return "goat";
            case 7: return "cow";
            case 8: return "horse";
        }
        return "";
    }
}