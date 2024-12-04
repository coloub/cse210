using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Abstract base class for mindfulness activities
    abstract class Activity
    {
        public string Name { get; set; } // Activity name
        public string Description { get; set; } // Brief description of the activity
        public int Duration { get; set; } // Duration in seconds

        public Activity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // Displays the starting message for the activity and prompts the user to enter the duration
        public void DisplayStartingMessage()
        {
            Console.WriteLine($"Starting {Name}...");
            Console.WriteLine(Description);
            Console.Write("Enter duration in seconds: "); // Prompt the user for the activity duration
            Duration = int.Parse(Console.ReadLine());
        }

        // Displays a closing message after the activity is completed
        public void DisplayEndingMessage()
        {
            Console.WriteLine($"\nGreat job! You have completed {Duration} seconds of the {Name} activity.");
        }

        // Simulates a timer with a "spinner" effect to show progress
        public void PauseSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("."); // Print a dot to indicate progress
                Thread.Sleep(500); // Pause for half a second
            }
            Console.WriteLine();
        }

        // Abstract method that must be implemented in derived classes
        public abstract void Run();
    }

    // Class for the breathing activity
    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "Focus on your breathing to relax your mind and body.") { }

        // Implementation of the Run method to guide the user through breathing
        public override void Run()
        {
            DisplayStartingMessage(); // Display the initial message
            int cycles = Duration / 6; // Each breathing cycle lasts 6 seconds (4 for inhaling + 2 for exhaling)
            for (int i = 0; i < cycles; i++)
            {
                Console.Write("Breathe in... ");
                PauseSpinner(4); // Timer for inhaling
                Console.Write("Breathe out... ");
                PauseSpinner(2); // Timer for exhaling
            }
            DisplayEndingMessage(); // Display the final message
        }
    }

    // Class for the reflection activity
    class ReflectionActivity : Activity
    {
        private List<string> prompts = new List<string>
        {
            "Think of a time when you overcame a challenge.",
            "Recall a moment when you helped someone in need.",
            "Remember an accomplishment that made you proud."
        };

        public ReflectionActivity() : base("Reflection Activity", "Reflect on meaningful experiences in your life.") { }

        // Implementation of the Run method to guide the user through reflection
        public override void Run()
        {
            DisplayStartingMessage(); // Display the initial message
            Random random = new Random(); // Randomly select a prompt
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            Console.WriteLine("Take some time to reflect...");
            PauseSpinner(Duration); // Timer to allow reflection
            DisplayEndingMessage(); // Display the final message
        }
    }

    // Class for the listing activity
    class ListingActivity : Activity
    {
        private List<string> prompts = new List<string>
        {
            "List as many things as you are grateful for.",
            "List your personal strengths.",
            "List people who have positively impacted your life."
        };

        public ListingActivity() : base("Listing Activity", "List items related to a specific topic.") { }

        // Implementation of the Run method to guide the user through listing items
        public override void Run()
        {
            DisplayStartingMessage(); // Display the initial message
            Random random = new Random(); // Select a random prompt
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            Console.WriteLine("You have a few seconds to list as many items as you can.");
            Thread.Sleep(3000); // Allow time for preparation

            Console.WriteLine("Start listing:");
            DateTime endTime = DateTime.Now.AddSeconds(Duration); // Calculate the time limit
            List<string> items = new List<string>();

            // Allow the user to enter items as long as there's time left
            while (DateTime.Now < endTime)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrEmpty(item))
                {
                    items.Add(item); // Add the item to the list
                }
            }

            // Inform the user how many items they listed
            Console.WriteLine($"You listed {items.Count} items. Great job!");
            DisplayEndingMessage(); // Display the final message
        }
    }

    // Main class containing the application menu
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear(); // Clear the console for a clean menu display
                Console.WriteLine("Welcome to the Mindfulness App!");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an activity: "); // Prompt the user for their choice

                string choice = Console.ReadLine(); // Capture the user's selection

                // Execute the selected activity
                if (choice == "1")
                {
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                }
                else if (choice == "2")
                {
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                }
                else if (choice == "3")
                {
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Goodbye!");
                    break; // Exit the program
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again."); // Handle invalid input
                }

                Console.WriteLine("\nPress Enter to return to the main menu...");
                Console.ReadLine(); // Pause before returning to the menu
            }
        }
    }
}
