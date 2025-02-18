public class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _amountCompleted;

    public ChecklistGoal(string shortName, string description, string points, int target, int bonus)
        : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

    public override string GetStringRepresentation()
    {
        string status = IsComplete() ? "[ X ]" : "[ ]";
        return $"ChecklistGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_amountCompleted}/{_target}|{_bonus}|{status}";
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[ X ]" : "[ ]";
        return $"ChecklistGoal: {status} {GetShortName()} - {GetDescription()} ({GetPoints()} points, {_amountCompleted}/{_target} completed, {_bonus} bonus)";
    }
}