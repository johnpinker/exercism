using System;
using System.Collections.Generic;
using System.Linq;
public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        switch (category)
        {
            case YachtCategory.Ones: return dice.Where(s => s ==1).Sum();
            case YachtCategory.Twos: return dice.Where(s => s ==2).Count()*2;
            case YachtCategory.Threes: return dice.Where(s => s ==3).Count()*3;
            case YachtCategory.Fours: return dice.Where(s => s ==4).Count()*4;
            case YachtCategory.Fives: return dice.Where(s => s ==5).Count()*5;
            case YachtCategory.Sixes: return dice.Where(s => s ==6).Count()*6;
            case YachtCategory.FullHouse: 
                int tmpCount = dice.Distinct().Count();
                if (tmpCount == 2)
                {
                    foreach (int i in dice.Distinct())
                        if (dice.Where(s => s==i).Count() < 2)
                            return 0;
                    return dice.Sum();
                }
                return 0;
            case YachtCategory.FourOfAKind: return dice.Distinct().Select(s => dice.Where(t => t == s).Count() >= 4 ? s*4 : 0).Sum();
            case YachtCategory.LittleStraight: if (dice.OrderBy(s => s).Distinct().First() == 1 && 
                dice.Distinct().Count() == 5 && dice.OrderBy(s => s).Distinct().Last() == 5) return 30;
                else return 0;
            case YachtCategory.BigStraight: if (dice.OrderBy(s => s).Distinct().First() == 2 && 
                dice.OrderBy(s => s).Distinct().Count() == 5 && dice.OrderBy(s => s).Distinct().Last() == 6) return 30;
                else return 0;
            case YachtCategory.Choice: return dice.Sum();
            case YachtCategory.Yacht: return (dice.Distinct().Count() == 1) ? 50 : 0;
            default: return -1;
        }
    }
}

