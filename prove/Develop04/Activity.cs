using System;
using System.Threading;

public class Activity
{
    protected int duration;
    private string name;
    private string description;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void Start()
    {
        Console.WriteLine($"\n{name}");
        Console.WriteLine(description);

        Console.Write("Duration (seconds): ");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        Thread.Sleep(3000); 
    }

    public void End()
    {
        Console.WriteLine("\nGood job!");
        Thread.Sleep(2000); 
        Console.WriteLine($"You have completed the {name} activity ({duration} seconds).");
        Thread.Sleep(3000);
    }

    public virtual void Run()
    {
    }
}