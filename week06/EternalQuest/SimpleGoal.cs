public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, string points)
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override void SetCompletionStatus(bool isComplete)
    {
        _isComplete = isComplete;
    }

    public override string GetStringRepresentation()
    {
        string status = _isComplete ? "[ X ]" : "[ ]";
        return $"SimpleGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{status}";
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[ X ]" : "[ ]";
        return $"SimpleGoal: {status} {GetShortName()} - {GetDescription()} ({GetPoints()} points)";
    }
}