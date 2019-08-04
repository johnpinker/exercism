using System;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        string retStr = null;
        int currentBottles = startBottles;
        while (currentBottles > startBottles-takeDown)
        {
            retStr += GetMessage(currentBottles);
            retStr += currentBottles-1 != startBottles-takeDown ? "\n\n" : "";
            currentBottles--;
        }
        return retStr;
    }

    public static string GetMessage(int numBottles)
    {
        string retStr = null;
        string bottleString = $"{(numBottles == 0 ? "No more bottles" : (numBottles == 1 ? "1 bottle" : numBottles + " bottles"))}";
        string bottleString2 = $"{(numBottles == 0 ? "no more bottles" : (numBottles == 1 ? "1 bottle" : numBottles + " bottles"))}";
        string secondBottleString = $"{(numBottles == 1 ? "it" : "one")}";
        string thirdBottleString = $"{(numBottles == 1 ? "no more bottles" : (numBottles == 2 ? "1 bottle" : numBottles-1 + " bottles"))}";
        retStr += $"{bottleString} of beer on the wall, {bottleString2} of beer.\n";
        if (numBottles == 0)
            retStr += "Go to the store and buy some more, 99 bottles of beer on the wall.";
        else 
            retStr += $"Take {secondBottleString} down and pass it around, {thirdBottleString} of beer on the wall.";
        return retStr;
    }
}