public abstract class Goal
{
    protected string ShortName { get; }
    protected string Description { get; }
    protected string Points { get; }

    protected Goal(string shortName, string description, string points)
    {
        ShortName = shortName;
        Description = description;
        Points = points;
    }

    public string GetShortName()
    {
        return ShortName;
    }

    public string GetDescription()
    {
        return Description;
    }

    public string GetPoints()
    {
        return Points;
    }

    public virtual void SetCompletionStatus(bool isComplete)
    {
        // Default implementation (if any)
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();
    public abstract string GetDetailsString();
}