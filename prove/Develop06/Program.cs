using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalScore = 0;
    static string saveDirectory = "SavedGoals";

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine($"\n--- Eternal Quest ---");
            Console.WriteLine($"Total Points: {totalScore}");
            Console.WriteLine("1. Create a Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    Console.WriteLine($"Total Score: {totalScore}");
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose an option: ");
        string type = Console.ReadLine();

        Console.Write("Enter Goal Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Goal Description: ");
        string description = Console.ReadLine();
        Console.Write("Enter Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Enter Target Count: ");
            int target = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, description, points, target));
        }

        Console.WriteLine("Goal created successfully!");
    }

    static void RecordEvent()
    {
        Console.WriteLine("\nChoose a goal to record an event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name} - {goals[i].GetProgress()}");
        }

        Console.Write("Enter the goal number: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < goals.Count)
        {
            int pointsGained = goals[choice].Points;
            goals[choice].RecordEvent();

            if (goals[choice].IsComplete())
            {
                Console.WriteLine($"\nCongratulations! You earned {pointsGained} points!");
                totalScore += pointsGained;
            }
            else
            {
                Console.WriteLine("\nEvent recorded!");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    static void ShowGoals()
    {
        Console.WriteLine("\nGoals:");
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name} - {goal.GetProgress()}");
        }
    }

    static void SaveGoals()
    {
        Console.Write("\nEnter the name of the file to save your goals (e.g., goals.txt): ");
        string fileName = Console.ReadLine();

        // Ensure the file has a .txt extension
        if (!fileName.EndsWith(".txt"))
        {
            fileName += ".txt";
        }

        string fullPath = Path.Combine(saveDirectory, fileName);

        try
        {   
            GoalManager.SaveGoals(goals, fullPath);
            Console.WriteLine($"Goals saved successfully to '{fullPath}'!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    static void LoadGoals()
    {
        Console.WriteLine("\nSaved Goal Files:");

        List<string> files = GoalManager.ListSavedFiles(saveDirectory);

        if (files.Count == 0)
        {
        Console.WriteLine("No saved goals found.");
        return;
        }

        //Display saved files
        for (int i = 0; i < files.Count; i++)
        {
        Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
        }

        Console.Write("\nEnter the name of the file to load (without extension): ");
        string fileName = Console.ReadLine();

        // Ensure the file has a .txt extension
        if (!fileName.EndsWith(".txt"))
        {
            fileName += ".txt";
        }

        string fullPath = Path.Combine(saveDirectory, fileName);

        if (File.Exists(fullPath))
        {
            goals = GoalManager.LoadGoals(fullPath);
            Console.WriteLine($"Goals loaded successfully from '{fullPath}'!");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' does not exist in the directory '{saveDirectory}'.");
        }
    }

}
