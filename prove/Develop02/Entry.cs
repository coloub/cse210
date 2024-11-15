using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;
    public Entry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToShortDateString(); // Get the current date
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine("---------------------------");
    }

    public override string ToString()
    {
        return $"{_date}|{_promptText}|{_entryText}"; // Format for saving to file
    }
}
