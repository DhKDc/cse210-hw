using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;

public class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "List as many things as you can that you are grateful for in your life.",
        "Think of a recent accomplishment and list all the steps you took to achieve it.",
        "Brainstorm as many ideas as possible for a creative project you'd like to undertake.",
        "List all the things you love about your favorite hobby.",
        "Enumerate the positive qualities you admire in the people you care about.",
        "Think of a place you find peaceful and list all the details you can remember about it.",
        "Imagine your dream vacation and list everything you'd like to do and see.",
        "List all the things you enjoy doing in your free time.",
        "Think of a skill you'd like to learn and list all the resources you could use to learn it.",
        "List as many words as you can that describe a positive emotion you're feeling right now."
    };

    private Random random = new Random();
    private List<string> remainingPrompts = new List<string>();

    public ListingActivity() : base("Listing Activity", "Take a moment to appreciate the positive aspects of your life.  This activity will guide you through listing as many things as you can in a specific area, fostering a sense of gratitude") { }

    public override void Run()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        remainingPrompts = new List<string>(prompts);

        while (stopwatch.Elapsed.TotalSeconds < duration)
        {

            if (remainingPrompts.Count == 0) 
            {
                remainingPrompts = new List<string>(prompts); 
            }
            
            string prompt = remainingPrompts[random.Next(remainingPrompts.Count)];
            remainingPrompts.Remove(prompt); 
            Console.WriteLine("\n" + prompt);

            Console.WriteLine("Start listing items in:");
            AnimationHelper.Countdown(3);

            List<string> items = new List<string>();

            while (stopwatch.Elapsed.TotalSeconds < duration) 
            {
                if (Console.KeyAvailable) 
                {
                    string item = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        items.Add(item);
                    }
                }
            }

            Console.WriteLine($"\nYou listed {items.Count} items.");
        }
    }
}