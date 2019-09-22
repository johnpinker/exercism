using System;
using System.Collections.Generic;
using System.Linq;


public class Card: IComparable
{
    public string Suite;
    public string Value;

    public Card(string card)
    {
        if (card.Length == 3)
            Suite = card[2].ToString();
        else 
            Suite = card[1].ToString();
        if (card.Length == 3)
            Value = card.Substring(0, 2);
        else 
            Value = card[0].ToString();
    }

    public int IntValue()
    {
       switch (Value)
       {
           case "A": return 11;
           case "J":
           case "Q":
           case "K": return 10;
           default: return int.Parse(Value);
       }
    }
    
    public int CompareTo(object o) 
    {
        Card compareCard = o as Card;
        
        if (char.IsDigit(compareCard.Value[0]) && char.IsDigit(Value[0]))
        {
            int thisDigit = int.Parse(Value);
            int thatDigit = int.Parse(compareCard.Value);
            if (compareCard.Value == "10") thatDigit = 10;
            if (Value == "10") thisDigit = 10;
            return thisDigit.CompareTo(thatDigit);
        }

        else if (Value == "A")
        {
            if (compareCard.Value == "A") return 0;
            else if (compareCard.Value == "2") return -1;
            else return 1;
        }
        else if (Value == "K")
        {
            if (compareCard.Value == "A") return -1;
            else if (compareCard.Value == "K") return 0;
            else return 1;
        }
        else if (Value == "Q")
        {
            if (compareCard.Value == "K" || compareCard.Value == "A") return -1;
            else if (compareCard.Value == "Q") return 0;
            else return 1;
        }
        else if (Value == "J")
        {
            if (compareCard.Value == "Q" || compareCard.Value == "K" || compareCard.Value == "A") return -1;
            else if (compareCard.Value == "J") return 0;
            else return 1;
        }
        else 
            return -1;
    }
}

public class Hand
{
    Card[] cards;
    public string handString;
    public Hand(string input)
    {
        handString = input;
        cards = new Card[5];
        string[] splitInput = input.Split(" ");
        if (splitInput.Length != 5) throw new ArgumentException();
        for (int i=0; i < splitInput.Length; i++)
        {
            cards[i] = new Card(splitInput[i]);
        }
    }
    
    public override string ToString()
    {
        return handString;
    }

    public Card HighCard()
    {
        return cards.Max();
    }

    public int HandClass()
    {
        return 9; // no hand - high card
    }

}
public static class Poker
{
    public static IEnumerable<string> BestHands(IEnumerable<string> hands)
    {
        List<Hand> handList = new List<Hand>();
        foreach (string s in hands)
            handList.Add(new Hand(s));
        if (handList.Count() == 1)
            return handList.Select(s => s.handString);

        List<string> retHands = new List<string>();
        int highClass = handList.Max(s => s.HandClass());
        List<Hand> highHands = handList.Where(s => s.HandClass() == highClass).ToList();
        retHands.AddRange(highHands.Select(s => s.ToString()));
        return retHands.ToArray();

    } 

}