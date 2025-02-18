public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, string points)
        : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Implement logic for recording an event for an EternalGoal
    }

    public override bool IsComplete()
    {
        // Eternal goals are never complete
        return false;
    }

    public override string GetStringRepresentation()
    {
        // Return a string representation of the EternalGoal
        return $"EternalGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}";
    }

    public override string GetDetailsString()
    {
        // Return a detailed string representation of the EternalGoal
        return $"EternalGoal: {GetShortName()} - {GetDescription()} ({GetPoints()} points)";
    }
}