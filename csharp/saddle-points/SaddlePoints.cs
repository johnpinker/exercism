using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        List<(int, int)> retList = new List<(int, int)>();
        for (int i=0; i <= matrix.GetUpperBound(0); i++) // rows
            for (int j=0; j <= matrix.GetUpperBound(1); j++) // columns
            {
                if (CheckRow(ref matrix, i, matrix[i,j]) &&
                    CheckCol(ref matrix, j, matrix[i,j])
                ) retList.Add((i+1, j+1));
            }
        return retList;
    }

    public static bool CheckRow(ref int[,] matrix, int row, int value)
    {
        for (int i=0; i<=matrix.GetUpperBound(1); i++)
            if (value < matrix[row, i])
                return false;
        return true;
    }

    public static bool CheckCol(ref int[,] matrix, int col, int value)
    {
        for (int i=0; i<=matrix.GetUpperBound(0); i++)
            if (value > matrix[i, col])
                return false;
        return true;
    }
}
