using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> _scores;

    public HighScores(List<int> list) => _scores = list;

    public List<int> Scores() => _scores;

    public int Latest() => _scores[_scores.Count-1];

    public int PersonalBest() => _scores.Max();

    public List<int> PersonalTopThree() => _scores.OrderByDescending(o => o).Take(3).ToList<int>();
}
