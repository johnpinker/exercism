using System;
using System.Collections.Generic;
using System.Linq;
public class DndCharacter
{
    public int Strength { get; private set; }
    public int Dexterity { get; private set;}
    public int Constitution { get; private set;}
    public int Intelligence { get; private set;}
    public int Wisdom { get; private set;}
    public int Charisma { get; private set;}
    public int Hitpoints { get; private set;}

    public static int Modifier(int score)
    {
        return (int)Math.Floor((score-10)/2.0);
    }

    public static int Ability() 
    {
        List<int> rollList = new List<int>();
        Random r = new Random();
        for (int i=0; i<4;i++)
            rollList.Add(r.Next(1, 7));
        rollList = rollList.OrderByDescending(s => s).ToList<int>();
        return rollList.Take(3).Sum();
    }

    public static DndCharacter Generate()
    {
        DndCharacter character = new DndCharacter();
        character.Charisma = Ability();
        character.Strength = Ability();
        character.Dexterity = Ability();
        character.Constitution = Ability();
        character.Wisdom = Ability();
        character.Intelligence = Ability();
        character.Hitpoints = 10 + Modifier(character.Constitution);
        return character;
    }
}
