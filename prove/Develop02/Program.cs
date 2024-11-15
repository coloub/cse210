using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("\nJournal Program Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your entry: ");
                    string entryText = Console.ReadLine();
                    Entry newEntry = new Entry(prompt, entryText);
                    journal.AddEntry(newEntry);
                    break;
                
                case "2":
                    journal.DisplayAll();
                    break;
                
                case "3":
                    Console.Write("Enter filename to save to: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;
                
                case "4":
                    Console.Write("Enter filename to load from: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;
                
                case "5":
                    Console.WriteLine("Exiting program...");
                    return;
                
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}