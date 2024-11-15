using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (var entry in _entries)
            {
                outputFile.WriteLine(entry.ToString());
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string fileName)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(fileName);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                var entry = new Entry(parts[1], parts[2]);
                _entries.Add(entry);
            }
        }
        Console.WriteLine("Journal loaded from file.");
    }
}
