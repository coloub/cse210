using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int totalPoints = 0;

        while (true)
        {
            Console.WriteLine("\n--- Goal Tracker ---");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Create a Goal");
            Console.WriteLine("3. Record Progress");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewGoals(goals, totalPoints);
                    break;
                case "2":
                    CreateGoal(goals);
                    break;
                case "3":
                    totalPoints = RecordProgress(goals, totalPoints);
                    break;
                case "4":
                    SaveGoals(goals);
                    break;
                case "5":
                    goals = LoadGoals();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    // Displays the list of goals and the total points accumulated
    private static void ViewGoals(List<Goal> goals, int totalPoints)
    {
        Console.WriteLine("\nYour Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine(goal);
        }
        Console.WriteLine($"Total Points: {totalPoints}");
    }

    // Prompts the user to create a new goal and adds it to the list
    private static void CreateGoal(List<Goal> goals)
    {
        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter the points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        goals.Add(new Goal(name, points));
        Console.WriteLine("Goal added successfully.");
    }

    // Records progress for a selected goal and updates total points
    private static int RecordProgress(List<Goal> goals, int totalPoints)
    {
        Console.WriteLine("\nSelect a goal to record progress:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            totalPoints += goals[index].Points;
            Console.WriteLine("Progress recorded!");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

        return totalPoints;
    }

    // Saves the list of goals to a file
    private static void SaveGoals(List<Goal> goals)
    {
        using (StreamWriter writer = new StreamWriter("savegame.txt"))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.Name}|{goal.Points}");
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    // Loads goals from the saved file and returns them as a list
    private static List<Goal> LoadGoals()
    {
        List<Goal> goals = new List<Goal>();

        if (File.Exists("savegame.txt"))
        {
            string[] lines = File.ReadAllLines("savegame.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                goals.Add(new Goal(parts[0], int.Parse(parts[1])));
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }

        return goals;
    }
}

public class Goal
{
    // Properties to store the goal name and points
    public string Name { get; set; }
    public int Points { get; set; }

    // Constructor to initialize a goal with its name and points
    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    // Returns a string representation of the goal
    public override string ToString()
    {
        return $"{Name} - {Points} Points";
    }
}
