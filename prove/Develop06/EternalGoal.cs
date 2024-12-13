public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public override void RecordEvent()
    {
        // No cambia el estado, ya que nunca se completa.
    }

    public override string GetProgress()
    {
        return "Ongoing";
    }

    public override bool IsComplete()
    {
        return false;
    }
}
