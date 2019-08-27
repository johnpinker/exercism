using System;
using System.Collections.Generic;
using System.Linq;

public class RailFenceCipher
{

    private int Rails;
    private bool inc = true;

    public RailFenceCipher(int rails)
    {
        Rails = rails;
    }


    public string Encode(string input)
    {
        char[,] rows = new char[Rails,input.Length];
        string retVal = "";
        for (int i=0, j=0; i < input.Length; i++)
        {
            rows[j,i] = input[i];
            j = IncRow(j);
        }
        for (int i=0; i< Rails; i++)
            for (int j=0; j < input.Length; j++)
                if (rows[i,j] != 0)
                    retVal += rows[i, j].ToString();
        return retVal;
    }

    int IncRow(int row)
    {
        if (row == Rails-1 && inc)
            inc = false;
        else if (row == 0)
            inc = true;
        return inc ? row+1 : row-1;
    }
    public string Decode(string input)
    {
        char[,] rows = new char[Rails,input.Length];
        string retVal = "";
        for (int i=0, j=0; i < input.Length; i++)
        {
            rows[j,i] = '-';
            j = IncRow(j);
        }
        
        for (int i=0, k=0; i< Rails; i++)
            for (int j=0; j < input.Length; j++)
                if (rows[i,j] == '-')
                    rows[i,j] = input[k++];
        

        for (int i=0, j=0; i < input.Length; i++)
        {
            retVal += rows[j,i].ToString();
            j = IncRow(j);
        }
        return retVal;
    }
}