using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
        if (row < 0 || column < 0 || row > 7  || column > 7)
            throw new ArgumentOutOfRangeException();
    }

    public int Row { get; }
    public int Column { get; }

    public bool IsSameRowOrCol(Queen toCompare) => (this.Row == toCompare.Row || this.Column == toCompare.Column) ? true : false;

    public bool IsDiagonal(Queen toCompare)
    {
        if (Math.Max(this.Row, toCompare.Row)-Math.Min(this.Row, toCompare.Row) == 
            Math.Max(this.Column, toCompare.Column)-Math.Min(this.Column, toCompare.Column))
            return true;
        else
            return false;
    }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black) => 
        (white.IsSameRowOrCol(black) || white.IsDiagonal(black)) ? true : false;


    public static Queen Create(int row, int column) => new Queen(row, column);
    
}