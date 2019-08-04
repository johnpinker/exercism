using System;
using System.Collections.Generic;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{    
    public List<string> students = new List<string> {"Alice", "Bob", "Charlie", "David", "Eve", "Fred", 
        "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"};
    List<char> row1 , row2;
    public KindergartenGarden(string diagram)
    {
        string[] rows = diagram.Split('\n');
        row1 = ProcessRow(rows[0]);
        row2 = ProcessRow(rows[1]);
    }

    private List<char> ProcessRow(string row)
    {
        List<char> row1 = new List<char>();
        foreach (char c in row)
            row1.Add(c);
        return row1;
    }
    private Plant ParsePlant(char c)
    {
        switch (c)
        {
            case 'C': return Plant.Clover;
            case 'V': return Plant.Violets;
            case 'G': return Plant.Grass;
            case 'R': return Plant.Radishes;
        }
        throw new ArgumentException();
    }
    public IEnumerable<Plant> Plants(string student)
    {
        List<Plant> plants = new List<Plant>();
        int studentNum = students.IndexOf(student);
        studentNum *= 2;
        plants.Add(ParsePlant(row1[studentNum]));
        plants.Add(ParsePlant(row1[studentNum+1]));
        plants.Add(ParsePlant(row2[studentNum]));
        plants.Add(ParsePlant(row2[studentNum+1]));
        return plants;

    }
}