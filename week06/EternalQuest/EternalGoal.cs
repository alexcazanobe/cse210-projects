public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, string points)
        : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        
    }

    public override bool IsComplete()
    {
        
        return false;
    }

    public override string GetStringRepresentation()
    {
        
        return $"EternalGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}";
    }

    public override string GetDetailsString()
    {
        
        return $"EternalGoal: {GetShortName()} - {GetDescription()} ({GetPoints()} points)";
    }
}