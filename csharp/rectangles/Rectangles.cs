using System;

public static class Rectangles
{
    public static int Count(string[] rows)
    {
        int rectCount = 0;
        for (int i=0; i<rows.Length; i++)
        {
            for (int j=0; j<rows[0].Length; j++)
            {
                if (rows[i][j] == '+')
                {
                    if (IsRectangle(rows, (i,j)))
                        rectCount++;
                }
            }
        }
        return rectCount;
    }

    public static bool IsRectangle(string[] rows, (int, int) startPoint) 
    {
        int startX = startPoint.Item2;
        int startY = startPoint.Item1;
        int endX = startX;
        if (endX == rows[startY].Length-1) return false; 
        else endX++;
        int endY = startY;
        if (endY == rows.Length-1) return false;
        else endY++;
        // start at initial coord and go down
        while (endY < rows.Length && rows[endY][startX] == '|')
            endY++;
        if (rows[endY][startX] != '+')
            return false;
        // go right from the bottom
        while (endX < rows[startY].Length && rows[endY][endX] == '-')
            endX++;
        if (rows[endY][endX] != '+')
            return false;
        // go up
        endY--;
        while (endY >= startY && rows[endY][endX] == '|')
            endY--;
        if (rows[startY][endX] != '+')
            return false;
        // go left from top
        endX--;
        while (endX >= startX && rows[startY][endX] == '-')
            endX--;
        if (endX != startX) return false;
        else return true;
    }
}