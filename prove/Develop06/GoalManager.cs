using System;
using System.IO;
using System.Collections.Generic;

public static class GoalManager
{
    public static void SaveGoals(List<Goal> goals, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public static List<Goal> LoadGoals(string fileName)
    {
        List<Goal> goals = new List<Goal>();

        try
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(":");
                    string type = parts[0];
                    string[] data = parts[1].Split(",");

                    if (type == "SimpleGoal")
                    {
                        goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2])));
                    }
                    else if (type == "EternalGoal")
                    {
                        goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    }
                    else if (type == "ChecklistGoal")
                    {
                        goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3])));
                    }
                }
            }
            else
            {
                Console.WriteLine($"File '{fileName}' does not exist. Please try again.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }

        return goals;
    }

    public static List<string> ListSavedFiles(string directory)
    {
        try
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return new List<string>(Directory.GetFiles(directory, "*.txt"));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error listing files: {ex.Message}");
            return new List<string>();
        }
    }
}
