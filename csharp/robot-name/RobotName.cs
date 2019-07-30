using System;
using System.Collections.Generic;

public class Robot
{
    private static List<string> _names = new List<string>();
    private string _name;

    public Robot() => this.Reset();

    public string Name
    {
        get => _name;
        
    }

    private string GenName()
    {
        Random r = new Random();
        string tmpName = "";
        tmpName += (char)('A' + r.Next(25));
        tmpName += (char)('A' + r.Next(25));
        tmpName += r.Next(9);
        tmpName += r.Next(9);
        tmpName += r.Next(9);
        return tmpName;
    }

    public void Reset()
    {
        string tmpName = GenName();
        while (_names.Contains(tmpName) == true)
            tmpName = GenName();

        _name = tmpName;
        _names.Add(tmpName);
        
    }
}