using System;

class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }
    public int Evaluation { get; }
    public string MainFeeling { get; }
    private static readonly string[] _feelings = {
        "Happy", "Sad", "Angry", "Frustrated", "Peaceful",
        "Grateful", "Energetic", "Tired", "Creative", "Productive"
    };

    public Entry(string prompt, string response, int evaluation, string mainFeeling)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
        Evaluation = evaluation;
        MainFeeling = mainFeeling;
    }

    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response} | {Evaluation}/10 | {MainFeeling}";
    }

    public static string[] GetFeelings()
    {
        return _feelings;
    }
}