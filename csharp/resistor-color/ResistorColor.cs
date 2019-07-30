using System;
using System.Linq;

public static class ResistorColor
{
    public static string[] Colors() => new string[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
    public static int ColorCode(string color) => Array.IndexOf(Colors(), color);
}