using System;
using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        StringBuilder sb = new StringBuilder();
        for (int i=input.Length-1; i>= 0; i--)
        {
            sb.Append(input[i]);
        }
        return sb.ToString();
    }
}