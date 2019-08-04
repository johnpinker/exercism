using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    public Direction Direction
    {
        get; private set;
    }


    public int X
    {
        get; private set;
    }

    public int Y
    {
        get; private set;
    }

    public void Move(string instructions)
    {
        foreach (char c in instructions)
        {
            switch (c) 
            {
            case 'R' : ChangeDirection(true); break;
            case 'L' : ChangeDirection(false); break;
            case 'A' : this.Advance(); break;
            default: break;
            }
        }
    }

    private void ChangeDirection(bool inc)
    {
        switch (this.Direction)
        {
            case Direction.East: this.Direction = inc ? Direction.South: Direction.North; break;
            case Direction.South: this.Direction = inc ? Direction.West: Direction.East; break;
            case Direction.West: this.Direction = inc ? Direction.North: Direction.South; break;
            case Direction.North: this.Direction = inc ? Direction.East: Direction.West; break;
        }
    }
    private void Advance()
    {
        switch (this.Direction)
        {
            case Direction.North: this.Y++; break;
            case Direction.South: this.Y--; break;
            case Direction.West: this.X--; break;
            case Direction.East: this.X++; break;
        }
    }

}