using System;

class PromptGenerator
{
    private string[] prompts = {
        "Who was the most interesting person I interacted with today?",
        "What am I most grateful for today?",
        "What is one small step I can take towards my biggest goal?",
        "What lesson did I learn today that I can apply to my life?",
        "If I could give my past self one piece of advice, what would it be?",
        "How can I make tomorrow even better than today?",
        "What creative idea or project am I excited to explore?",
        "What are three things I did well today?",
        "What is one thing I can forgive myself for?",
        "How did I contribute to the happiness of others today?",
        "What small act of kindness can I do for someone tomorrow?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Length)];
    }
}