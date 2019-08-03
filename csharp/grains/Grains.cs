using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n < 1 || n > 64)
            throw new ArgumentOutOfRangeException();
        if (n==1) return 1;
        else return Square(n-1)*2;
    }

    public static ulong Total()
    {
        ulong tmpResult = 0;
        for (int i=1; i<65; i++)
            tmpResult += Square(i);
        return tmpResult;
    }
}