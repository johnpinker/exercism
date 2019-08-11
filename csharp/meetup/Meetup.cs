using System;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private int Month { get; set; }
    private int Year { get; set; }
    public Meetup(int month, int year)
    {
        Month = month;
        Year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        DateTime tmpDate;
        switch (schedule)
        {
            case Schedule.First:
                return new DateTime(Year, Month, GetFirst(dayOfWeek));
            case Schedule.Second:
                return new DateTime(Year, Month, GetFirst(dayOfWeek)+7);
            case Schedule.Third:
                return new DateTime(Year, Month, GetFirst(dayOfWeek)+14);
            case Schedule.Fourth:
                tmpDate = new DateTime(Year, Month, GetFirst(dayOfWeek)+21);
                if (tmpDate.Month != Month)
                    throw new ArgumentException();
                else
                    return tmpDate;
            case Schedule.Last:
                tmpDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
                while (tmpDate.DayOfWeek != dayOfWeek) tmpDate = tmpDate.AddDays(-1);
                return tmpDate;
            case Schedule.Teenth:
                tmpDate = new DateTime(Year, Month, 13);
                while (tmpDate.DayOfWeek != dayOfWeek) tmpDate = tmpDate.AddDays(1);
                return tmpDate;
            default:
                throw new ArgumentException();
        }
    }

    private int GetFirst(DayOfWeek day)
    {
        DateTime baseDate = new DateTime(Year, Month, 1);
        while (baseDate.DayOfWeek != day) baseDate = baseDate.AddDays(1);
        return baseDate.Day;
    }
}