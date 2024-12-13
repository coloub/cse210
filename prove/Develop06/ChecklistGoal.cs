public class ChecklistGoal : Goal
{
    private int completedCount = 0;
    private int targetCount;

    public ChecklistGoal(string name, string description, int points, int targetCount)
    {
        Name = name;
        Description = description;
        Points = points;
        this.targetCount = targetCount;
    }

    public override void RecordEvent()
    {
        if (completedCount < targetCount)
        {
            completedCount++;
        }
    }

    public override string GetProgress()
    {
        return $"{completedCount}/{targetCount} completed";
    }

    public override bool IsComplete()
    {
        return completedCount >= targetCount;
    }
}
