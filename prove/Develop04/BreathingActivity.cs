using System;
using System.Diagnostics; 

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "Unwind and find tranquility through conscious breathing. This activity will guide you through a series of deep breaths, promoting relaxation and calmness.") { }

    public override void Run()
    {
        Stopwatch stopwatch = new Stopwatch(); 
        stopwatch.Start();

        for (int i = 0; stopwatch.Elapsed.TotalSeconds < duration;) 
        {
            if (i % 2 == 0)
            {
                Console.WriteLine("Breathe in...");
            }
            else
            {
                Console.WriteLine("Breathe out...");
            }
            AnimationHelper.Countdown(2);
            i++;
        }

        stopwatch.Stop();
    }
}