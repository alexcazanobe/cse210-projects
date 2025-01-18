using System;
using System.Collections.Generic;
using System.IO;


public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach(var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        if (!file.EndsWith(".csv"))
        {
            file += ".csv";
        }

        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach(var entry in _entries)
            {
                writer.WriteLine($"\"{entry._date}\", \"{entry._promptText}\" \"{entry._entryText}\"");
            }
        }

        Console.WriteLine($"Journal saved to {file}");
    }

     public void LoadFromFile(string file)
     {
        if (File.Exists(file))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);
            foreach(var line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry
                    {
                        _date = parts[0],
                        _promptText = parts [1],
                        _entryText = parts [2]
                    };
                    _entries.Add(entry);
                }
            }
        
        }
        else
        {
            Console.WriteLine("File not found");
        }
     }

}