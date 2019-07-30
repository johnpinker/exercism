using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Dictionary<int, List<string>> _db = new Dictionary<int, List<string>>();

    public void Add(string student, int grade)
    {
        if (_db.ContainsKey(grade))
        {
            _db[grade].Add(student);
        }
        else
        {
            _db.Add(grade, new List<string>() { student });
        }
    }

    public IEnumerable<string> Roster()
    {
        List<string> tmpList = new List<string>();
        foreach (var v in _db.OrderBy(t => t.Key))
        {
            tmpList.AddRange(v.Value.OrderBy(s => s));
        }
        return tmpList;
    }

    public IEnumerable<string> Grade(int grade)
    {
        return _db.ContainsKey(grade) ? _db[grade].OrderBy(s => s).ToList<string>() : new List<string>();
    }
}