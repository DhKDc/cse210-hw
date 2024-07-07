using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private const string FILE_NAME = "journal.txt"; 
    private const char SEPARATOR = '|'; 

    public void AddEntry(string prompt)
    {
        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        int evaluation;
        while (true)
        {
            Console.Write("Evaluate your day (1-10): ");
            if (int.TryParse(Console.ReadLine(), out evaluation) && evaluation >= 1 && evaluation <= 10)
                break;
            Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
        }

        string[] feelings = Entry.GetFeelings();
        Console.WriteLine("\nHow are you feeling today?");
        for (int i = 0; i < feelings.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {feelings[i]}");
        }

        int feelingChoice;
        while (true)
        {
            Console.Write("Choose a feeling (1-10): ");
            if (int.TryParse(Console.ReadLine(), out feelingChoice) && feelingChoice >= 1 && feelingChoice <= 10)
                break;
            Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
        }

        entries.Add(new Entry(prompt, response, evaluation, feelings[feelingChoice - 1]));
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
        string directoryPath = Directory.GetCurrentDirectory(); 
        string[] journalFiles = Directory.GetFiles(directoryPath, "*.txt"); 

        if (journalFiles.Length == 0)
        {
            Console.WriteLine("No journal files found.");
            return;
        }

        Console.WriteLine("\nSaved Journals:");
        for (int i = 0; i < journalFiles.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(journalFiles[i])}"); 
        }

        Console.Write("Enter the number of the journal to load (or 0 to cancel): ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > journalFiles.Length)
        {
            Console.WriteLine("Invalid choice. Please enter a valid number.");
        }

        if (choice == 0)
        {
            return; 
        }

        string fileName = journalFiles[choice - 1]; 
        try
        {
            entries.Clear(); 
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(SEPARATOR);
                    if (parts.Length >= 3) 
                    {
                        entries.Add(new Entry(parts[1], parts[2], 0, "")); 
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