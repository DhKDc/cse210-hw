using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you accomplished a personal goal.",
        "Think of a time when you overcame a challenge.",
        "Think of a time when you made a difficult decision."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "What emotions did you experience during this time?",
        "Did this experience change your perspective on anything?"
    };

    private List<string> remainingQuestions = new List<string>();
    private Random random = new Random();

    public ReflectionActivity() : base("Reflection Activity", "Reflect on moments that have shaped your strength and resilience. This activity will guide you through various questions to help you recognize your inner power and how you can harness it in other areas of your life.") { }

    public override void Run()
    {
        Stopwatch stopwatch = new Stopwatch();
        Stopwatch questionStopwatch = new Stopwatch();
        stopwatch.Start();

        remainingQuestions = questions.OrderBy(x => random.Next()).ToList(); 

        string currentPrompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine("\n" + currentPrompt);

        string currentQuestion = remainingQuestions[0]; 
        remainingQuestions.RemoveAt(0);
        Console.WriteLine(currentQuestion);

        questionStopwatch.Start();
        AnimationHelper.Countdown(10);

        while (stopwatch.Elapsed.TotalSeconds < duration)
        {
            if (questionStopwatch.Elapsed.TotalSeconds >= 10)
            {
                if (remainingQuestions.Count == 0)
                {
                    remainingQuestions = questions.OrderBy(x => random.Next()).ToList();
                }

                currentQuestion = remainingQuestions[0];
                remainingQuestions.RemoveAt(0);
                Console.WriteLine(currentQuestion);
                questionStopwatch.Restart();
            }

            int remainingActivityTime = (int)(duration - stopwatch.Elapsed.TotalSeconds);
            int nextQuestionTime = 10 - (int)questionStopwatch.Elapsed.TotalSeconds;
            int nextCountdown = Math.Min(remainingActivityTime, nextQuestionTime);
            if (nextCountdown > 0)
            {
                AnimationHelper.Countdown(nextCountdown);
            }
        }

        stopwatch.Stop();
    }
}