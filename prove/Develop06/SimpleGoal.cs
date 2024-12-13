public class SimpleGoal : Goal
{
    private bool isComplete = false;

    public SimpleGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public override void RecordEvent()
    {
        isComplete = true;
    }

    public override string GetProgress()
    {
        return isComplete ? "Complete" : "Incomplete";
    }

    public override bool IsComplete()
    {
        return isComplete;
    }
}
