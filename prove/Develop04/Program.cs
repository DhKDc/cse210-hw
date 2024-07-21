/*
 * Showing Creativity adn exceed requirements: 
 * To maximize the variety of prompts and questions, the program 
 * ensures that all available options are used at least once within a session 
 * before any are repeated. 
 */
using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            Activity activity = null;

            switch (choice)
            {
                case 1: activity = new BreathingActivity(); break;
                case 2: activity = new ReflectionActivity(); break;
                case 3: activity = new ListingActivity(); break;
                case 4: return; 
                default: Console.WriteLine("Invalid choice."); continue; 
            }

            activity.Start();
            activity.Run();
            activity.End();
        }
    }
}