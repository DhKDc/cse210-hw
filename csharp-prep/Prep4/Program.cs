using System;
using System.Collections.Generic; 

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>(); 
        int inputNumber;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            inputNumber = Convert.ToInt32(Console.ReadLine());
            if (inputNumber != 0)
            {
                numbers.Add(inputNumber); 
            }
        } while (inputNumber != 0); 


        int sum = 0;
        int largest = int.MinValue;

        foreach (int number in numbers) 
        {
            sum += number;
            if (number > largest)
            {
                largest = number;
            }
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + largest);
    }
}