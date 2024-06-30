using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,100);
        Console.WriteLine("Welcome to Guess the number.");
        int guessNumber = 0;
        do
        {
            Console.WriteLine("What is your guess? (1-100): ");
            string guessAnswer = Console.ReadLine();
            guessNumber = int.Parse(guessAnswer);
            if (guessNumber>magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guessNumber<magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.Write("Correct!");
            }
        } while (guessNumber!=magicNumber);
    }
}