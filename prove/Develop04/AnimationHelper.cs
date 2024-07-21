using System;
using System.Threading;

public static class AnimationHelper
{
    public static void Countdown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.Write($"\r{i} seconds remaining...  "); 
            Thread.Sleep(1000); 
        }
        Console.WriteLine("\r"); 
    }
}