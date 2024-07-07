using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private const string FILE_NAME = "journal.txt"; // Default file name
    private const char SEPARATOR = '|'; // Separator character for file

    public void AddEntry(string prompt)
    {
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        entries.Add(new Entry(prompt, response));
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
        }
        else
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine(entry); 
            }
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter file name (or press Enter to use default): ");
        string fileName = Console.ReadLine().Trim();
        if (string.IsNullOrEmpty(fileName))
        {
            fileName = FILE_NAME;
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine(entry.ToString());
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error saving journal: {e.Message}");
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Enter file name to load: ");
        string fileName = Console.ReadLine().Trim();

        try
        {
            entries.Clear(); // Clear existing entries
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(SEPARATOR);
                    if (parts.Length == 3) 
                    {
                        entries.Add(new Entry(parts[1], parts[2]));
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error loading journal: {e.Message}");
        }
    }
}