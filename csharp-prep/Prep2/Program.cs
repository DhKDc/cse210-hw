using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the grade percentage?: ");
        string gradeInput = Console.ReadLine();
        int gradePercentage = int.Parse(gradeInput);

        string gradeLetter="";
        
        if (gradePercentage >= 90)
        {
            gradeLetter = "A";
        }
        else if (gradePercentage >= 80)
        {
            gradeLetter = "B";
        }
        else if (gradePercentage>= 70)
        {
            gradeLetter = "C";
        }
        else if (gradePercentage>= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }

        Console.WriteLine($"Your grade is: {gradeLetter}");
        
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed!");
        }
        else
        {
            Console.WriteLine("Sorry, You did not pass. Keep studying!");
        }
    }
}