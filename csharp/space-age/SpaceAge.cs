using System;

public class SpaceAge
{
    private int _earthSeconds = 0;
    public SpaceAge(int seconds) => _earthSeconds = seconds;

    public double OnEarth() => _earthSeconds / 31557600.0;

    public double OnMercury() => this.OnEarth() / 0.2408467;

    public double OnVenus() => this.OnEarth() / 0.61519726;

    public double OnMars() => this.OnEarth() / 1.8808158;

    public double OnJupiter() => this.OnEarth() / 11.862615;

    public double OnSaturn() => this.OnEarth() / 29.447498;

    public double OnUranus() => this.OnEarth() / 84.016846;

    public double OnNeptune() => this.OnEarth() / 164.79132;
}