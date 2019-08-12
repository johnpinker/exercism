using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        if (rows == 0) return new List<List<int>>();
        List<int> firstRow = new List<int> { 1 };
        List<List<int>> retVal = new List<List<int>>();
        retVal.Add(firstRow);
        for (int i=1; i< rows; i++)
        {
            firstRow = CalcRow(firstRow);
            retVal.Add(firstRow);
        }
        return retVal;
    }

    private static List<int> CalcRow(List<int> lastRow)
    {
        List<int> newRow = new List<int>(lastRow);
        newRow.Add(lastRow[0]);
        newRow[0] = lastRow[0];
        for (int i=1; i < newRow.Count-1; i++)
            newRow[i] = lastRow[i-1] + lastRow[i];
        return newRow;
    }
}