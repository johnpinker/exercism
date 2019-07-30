using System;
using System.Collections.Generic;

[Flags]
public enum Allergen
{
    Eggs =0x01,
    Peanuts =0x02,
    Shellfish =0x04,
    Strawberries =0x08,
    Tomatoes= 0x10,
    Chocolate =0x20,
    Pollen =0x40,
    Cats =0x80
}

public class Allergies
{
    private Allergen _allergies = 0;

    public Allergies(int mask) => _allergies = (Allergen)mask;

    public bool IsAllergicTo(Allergen allergen)
    {
        foreach (var val in Enum.GetValues(typeof(Allergen)))
        {
            if (((Allergen)val & _allergies) == allergen)
            {
                return true;
            }
        }
        return false;
    }

    public Allergen[] List()
    {
        List<Allergen> tmpList = new List<Allergen>();
        foreach (var val in Enum.GetValues(typeof(Allergen)))
        {
            if (((Allergen)val & _allergies) == (Allergen)val)
            {
                Allergen tmpAllergen = new Allergen();
                tmpAllergen = (Allergen)val;
                tmpList.Add(tmpAllergen);
            }
        }
        return tmpList.ToArray();
        
    }
}