/*
 * To demonstrate creativity and exceed requirements, instead of using a single 
 * scripture, I've implemented a list of scriptures and added functionality to 
 * randomly select one at the beginning of each round. This enhances the 
 * user experience and allows for a wider range of scriptures to be memorized.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5), "Trust in the LORD with all thine heart; and lean not unto thine own understanding."),
            new Scripture(new Reference("Matthew", 22, 37-39), "Jesus said unto him, Thou shalt love the Lord thy God with all thy heart, and with all thy soul, and with all thy mind. This is the first and great commandment. And the second is like unto it, Thou shalt love thy neighbour as thyself."),
            new Scripture(new Reference("Romans", 8, 28), "And we know that all things work together for good to them that love God, to them who are the called according to his purpose."),
            new Scripture(new Reference("1 Corinthians", 13, 4, 8), "Love is patient, love is kind. It does not envy, it does not boast, it is not proud. It does not dishonor others, it is not self-seeking, it is not easily angered, it keeps no record of wrongs. Love does not delight in evil but rejoices with the truth. It always protects, always trusts, always hopes, always perseveres. Love never fails."),
            new Scripture(new Reference("1 John", 4, 19), "We love because he first loved us."),
            new Scripture(new Reference("Galatians", 5, 22, 23), "But the fruit of the Spirit is love, joy, peace, forbearance, kindness, goodness, faithfulness, gentleness and self-control. Against such things there is no law."),
            new Scripture(new Reference("Philippians", 4, 6, 7), "Do not be anxious about anything, but in every situation, by prayer and petition, with thanksgiving, present your requests to God. And the peace of God, which transcends all understanding, will guard your hearts and your minds in Christ Jesus."),
            new Scripture(new Reference("Psalm", 23, 1, 3), "The LORD is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters. He restoreth my soul: he leadeth me in the paths of righteousness for his name's sake."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("Isaiah", 40, 31), "but they who wait for the LORD shall renew their strength; they shall mount up with wings like eagles; they shall run and not be weary; they shall walk and not faint."),
            new Scripture(new Reference("Deuteronomy", 6, 5), "Love the LORD your God with all your heart and with all your soul and with all your strength."),
            new Scripture(new Reference("Micah", 6, 8), "He has shown you, O mortal, what is good. And what does the Lord require of you? To act justly and to love mercy and to walk humbly with your God."),
        };

        var random = new Random();

        while (true)
        {
            int randomIndex = random.Next(scriptures.Count);
            Scripture selectedScripture = scriptures[randomIndex]; 

            while (!selectedScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.GetDisplayText());

                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
                string input = Console.ReadLine().ToLower();
                if (input == "quit")
                    return; 

                int wordsToHide = Math.Min(3, selectedScripture.GetRemainingWordCount()); 
                selectedScripture.HideRandomWords(wordsToHide);
            }

            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText()); 
            Console.WriteLine("\nScripture completed! Press Enter to continue or type 'quit' to exit:");
            if (Console.ReadLine().ToLower() == "quit")
                return; 

            selectedScripture.ShowAllWords(); 
        }
    }
}