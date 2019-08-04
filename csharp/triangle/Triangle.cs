using System;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        if (!IsValid(side1, side2, side3))
            return false;
        if (!IsIsosceles(side1, side2, side3) && !IsEquilateral(side1, side2, side3))
            return true;
        else 
            return false;
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        if (!IsValid(side1, side2, side3))
            return false;
        return side1 == side2 || side2 == side3 || side1 == side3;
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        if (!IsValid(side1, side2, side3))
            return false;
        return side1 == side2 && side2 == side3;
    }

    private static bool IsValid(double side1, double side2, double side3)
    {
        if (side1 <= 0.0 || side2 <= 0.0 || side3 < 0.0)
            return false;
        else if (side1 + side2 <= side3 || side2 + side3 <= side1 || side1 + side3 <= side2)
            return false;
        else
            return true;
    }
}