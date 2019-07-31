using System;

public class Clock : IEquatable<Clock>
{
    private DateTime _time;

    public Clock(int hours, int minutes)
    {
        DateTime t = DateTime.Now;
        _time = new DateTime(t.Year, t.Month, t.Day, 0, 0, 0);
        _time = _time.AddHours(hours);
        _time = _time.AddMinutes(minutes);
    }

    public int Hours => int.Parse(_time.ToString("HH"));

    public int Minutes => int.Parse(_time.ToString("mm"));

    public Clock Add(int minutesToAdd)
    {
        Clock c = new Clock(this.Hours, this.Minutes);
        c._time = c._time.AddMinutes(minutesToAdd);
        return c;
    }

    public bool Equals(Clock other)
    {
        if (other == null) return false;
        return other.Hours == Hours && other.Minutes == Minutes;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        Clock c = new Clock(Hours, Minutes);
        c._time = c._time.Subtract(new TimeSpan(0, minutesToSubtract, 0));
        return c;
    }

    public override string ToString() => $"{_time.Hour:D2}:{_time.Minute:D2}";
}