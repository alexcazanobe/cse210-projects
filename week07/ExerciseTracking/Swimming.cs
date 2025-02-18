using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps; 
    }

    public override double GetSpeed()
    {
        double distanceInKm = (_laps * 50) / 1000.0;
        return (distanceInKm / GetLength()) * 60;
    }

    public override double GetPace()
    {
        double distanceInKm = (_laps * 50) / 1000.0;
        return GetLength() / distanceInKm;
    }

    public override string GetSummary()
    {
        return $"{GetDate().ToString("dd MMM yyyy")} Swimming ({GetLength()} min) - Distance {GetDistance():0} laps - Speed {GetSpeed():0.0} kph - Pace: {GetPace():0.0} min per km";
    }
}