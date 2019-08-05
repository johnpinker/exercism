using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        double tmpDbl;
        tmpDbl= Math.Pow(realNumber, r.Numerator);
        double tmpPwr = (double)(1.0/r.Denominator);
        tmpDbl = Math.Pow(tmpDbl, tmpPwr);
        return tmpDbl;
    }
}

public struct RationalNumber
{
    public int Numerator {get; set;}
    public int Denominator {get; set;}
    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }


    private static bool IsNegative(RationalNumber n)
    {
        if (n.Numerator < 0 || n.Denominator < 0)
            return true;
        else 
            return false;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber retVal = new RationalNumber();
        retVal.Numerator = (r1.Numerator * r2.Denominator) + (r1.Denominator * r2.Numerator);
        retVal.Denominator = (r1.Denominator * r2.Denominator);
        return retVal.Reduce();
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber retVal = new RationalNumber();
        retVal.Numerator = (r1.Numerator * r2.Denominator) - (r1.Denominator * r2.Numerator);
        retVal.Denominator = (r1.Denominator * r2.Denominator);
        return retVal.Reduce();
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber retVal = new RationalNumber();
        retVal.Numerator = r1.Numerator*r2.Numerator;
        retVal.Denominator = r1.Denominator*r2.Denominator;
        return retVal.Reduce();
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        RationalNumber retVal = new RationalNumber();
        retVal.Numerator = r1.Numerator*r2.Denominator;
        retVal.Denominator = r1.Denominator*r2.Numerator;
        return retVal.Reduce();
    }

    public RationalNumber Abs()
    {
        Numerator = Math.Abs(Numerator);
        Denominator = Math.Abs(Denominator);
        return this;
    }

    public RationalNumber Reduce()
    {
        List<int> commonDenominators = new List<int>();
        List<int> commonNumerators = new List<int>();
        int gcd = 0;
        bool isNN = Numerator < 0 ? true : false;
        bool isDN = Denominator < 0 ? true : false;
        if(Numerator == 0)
        {
            Denominator = 1;
            return this;
        }
        for (int i=1; i <= Math.Abs(Numerator); i++)
            if (Numerator%i == 0)
                commonNumerators.Add(i);
        for (int i=1; i<= Math.Abs(Denominator); i++)
            if (Denominator%i == 0)
                commonDenominators.Add(i);
        gcd = commonNumerators.Where(s => commonDenominators.IndexOf(s) != -1).Max();
        if (gcd != 0)
        {
            Numerator /= gcd;
            Denominator /= gcd;
        }
        Numerator = isNN ? Math.Abs(Numerator) * -1 : Numerator;
        Denominator = isDN ? Math.Abs(Denominator) * -1 : Denominator;
        if (Denominator < 0)
            if (Numerator >0)
            {
                Numerator *= -1;
                Denominator *= -1;
            }
            else 
            {
                Denominator *= -1;
                Numerator *= -1;
            }
        return this;
    }

    public RationalNumber Exprational(int power)
    {
        if (power > 0)
        {
            this.Numerator = (int)Math.Pow(this.Numerator, power);
            this.Denominator = (int)Math.Pow(this.Denominator, power);
        }
        else if (power < 0)
        {
            RationalNumber nab = Abs();
            this.Numerator = (int)Math.Pow(nab.Denominator, power);
            this.Denominator = (int)Math.Pow(nab.Numerator, power);
        }
        else //power = 0
        {
            this.Numerator = 1;
            this.Denominator = 1;
        }
        return this.Reduce();
    }

    public double Expreal(int baseNumber)
    {
        return baseNumber.Expreal(this);
    }
}