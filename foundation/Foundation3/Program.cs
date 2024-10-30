using System;

public class Activity
{
    protected DateTime Date { get; set; }
    protected int DurationInMinutes { get; set; }

    public Activity(DateTime date, int durationInMinutes)
    {
        Date = date;
        DurationInMinutes = durationInMinutes;
    }

    public virtual double GetDistance() { return 0; }
    public virtual double GetSpeed() { return 0; }
    public virtual double GetPace() { return 0; }

    public string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name} ({DurationInMinutes} min) - " +
               $"Distance {GetDistance():F1} km, Speed {GetSpeed():F1} kph, Pace {GetPace():F2} min per km";
    }
}

public class RunningActivity : Activity
{
    private double DistanceInKilometers { get; set; }

    public RunningActivity(DateTime date, int durationInMinutes, double distanceInKilometers) : base(date, durationInMinutes)
    {
        DistanceInKilometers = distanceInKilometers;
    }

    public override double GetDistance() => DistanceInKilometers;
    public override double GetSpeed() => DistanceInKilometers / DurationInMinutes * 60;
    public override double GetPace() => DurationInMinutes / DistanceInKilometers;
}

public class CyclingActivity : Activity
{
    private double AverageSpeedInKph { get; set; }

    public CyclingActivity(DateTime date, int durationInMinutes, double averageSpeedInKph) : base(date, durationInMinutes)
    {
        AverageSpeedInKph = averageSpeedInKph;
    }

    public override double GetDistance() => AverageSpeedInKph * DurationInMinutes / 60;
    public override double GetSpeed() => AverageSpeedInKph;
    public override double GetPace() => 60 / AverageSpeedInKph;
}

public class SwimmingActivity : Activity
{
    private int Laps { get; set; }

    public SwimmingActivity(DateTime date, int durationInMinutes, int laps) : base(date, durationInMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance() => Laps * 50 / 1000;
    public override double GetSpeed() => GetDistance() / DurationInMinutes * 60;
    public override double GetPace() => DurationInMinutes / GetDistance();
}

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new RunningActivity(new DateTime(2022, 11, 3), 30, 4.8),
            new CyclingActivity(new DateTime(2022, 11, 4), 45, 20),
            new SwimmingActivity(new DateTime(2022, 11, 5), 35, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
