using System;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        char[] tmpStr = text.ToCharArray();
        for (int i=0; i<tmpStr.Length; i++)
        {
            tmpStr[i] = RotateChar(tmpStr[i], shiftKey);
        }
        return new string(tmpStr);
    }

    private static char RotateChar(char c, int key)
    {
        if (!char.IsLetter(c))
            return c;
        int amtToShift;
        bool isUpper = Char.IsUpper(c);
        amtToShift = !isUpper ? c - 'a' + key : c - 'A' + key;
        amtToShift = amtToShift > 25 ? amtToShift - 26 : amtToShift;
        return (char)(isUpper ? 'A' + amtToShift : 'a' + amtToShift);
    }
}
