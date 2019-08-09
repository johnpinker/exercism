using System;
using System.Collections.Generic;

public class Matrix
{
    private List<List<int>> matList;
    public Matrix(string input)
    {
        matList = new List<List<int>>();
        string[] lines = input.Split('\n');
        for (int i=0; i<lines.Length; i++)
        {
            matList.Add(new List<int>());
            string[] elements = lines[i].Split(' ');
            for (int j=0; j< elements.Length; j++)
            {
                matList[i].Add(int.Parse(elements[j]));
            }
        }
    }

    public int Rows
    {
        get => matList.Count;
    }

    public int Cols
    {
        get => matList[0].Count;
    }

    public int[] Row(int row) => matList[row-1].ToArray();

    public int[] Column(int col)
    {
        List<int> retList = new List<int>();
        for (int i=0; i< matList.Count; i++)
            retList.Add(matList[i][col-1]);
        return retList.ToArray();
    }
}