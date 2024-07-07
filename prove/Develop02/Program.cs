// To show creativity and exceed the requirements i decided add the following features:
// - Rate the day from 1 to 10 to track the overall vibe.
// - Choose a word that describes the main feeling for the day.
// This helps you capture a more complete picture of how things are going.
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator prompts = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    myJournal.AddEntry(prompts.GetRandomPrompt());
                    break;
                case 2:
                    myJournal.DisplayEntries();
                    break;
                case 3:
                    myJournal.SaveToFile();
                    break;
                case 4:
                    myJournal.LoadFromFile();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}