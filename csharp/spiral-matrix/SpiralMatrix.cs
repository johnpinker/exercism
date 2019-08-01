using System;

public class SpiralMatrix
{
    private static int _size;
    private static int[,] _matrix;

    private static int numbersWritten =1;
    public static int[,] GetMatrix(int size)
    {
        _matrix = new int[size, size];
        _size = size; 
        int num = 1;
        int i =0;
        int j = 0;
        int start = 0;
        int end = _size-1;
        i = start;
        j= start;

        while (start <= end)
        {
            if (start == end)
                _matrix[start, end] = num;
            
            for (j =start; j<end; j++)
            {
                //console.log(i + ":" + j);
                _matrix[i,j] = num;
                num++;
            }
            for (i=start; i<end; i++)
            {
                _matrix[i,j] = num;
                num++;
            }
            for (j=j;j >start; j--)
            {
                //console.log(i + ":" + j);
                _matrix[i,j] = num;
                num++;
            }
            for (i=i; i>start; i--)
            {
                _matrix[i,j] = num;
                num++;
            }
            start++;
            end--;
            i=start;j=start;
        }

       
       return _matrix;
    }
}
