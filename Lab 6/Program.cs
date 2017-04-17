using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Brett Merrifield
 * 04/17/17
 */
namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Pig Latin Translator";
            Console.WriteLine("Welcome to the Pig Latin Translator!\n");

            bool loop = true;
            while (loop)
            {
                string input = GetLetterInput();
                string[] words = SplitIntoWords(input);
                PrintPigLatin(words);
                if (!ContinueApp())
                    loop = false;
            }
        }
        public static string GetLetterInput()
        {
            while (true)
            {
                Console.Write("Enter a line to be translated: ");

                //Trims input and converts to all lowercase
                string input = Console.ReadLine().Trim().ToLower();

                //Validates if input is all letters/spaces and is not empty
                if (input.All(c => Char.IsLetter(c) || c == ' ') && !string.IsNullOrWhiteSpace(input)) 
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Invalid input!\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        public static string[] SplitIntoWords(string input)
        {
            //Splits sentence into words array
            string[] wordList = input.Split(' ');
            return wordList;
        }
        public static void PrintPigLatin(string[] input)
        {
            char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
            for (int i = 0; i < input.Length; i++)
            {
                //If the word starts with a vowel
                if (input[i].IndexOfAny(vowels) == 0)
                { 
                    Console.Write(input[i] + "way ");
                }
                //If the word does not contain a vowel
                else if (input[i].IndexOfAny(vowels) == -1) 
                {
                    Console.Write(input[i] + "ay ");
                }
                else
                {
                    //Creates a substring starting at index 0 to the length of the index of the first vowel
                    string starting = input[i].Substring(0, input[i].IndexOfAny(vowels));

                    //Creates a substring at index of the first vowel to the end of the word
                    string ending = input[i].Substring(input[i].IndexOfAny(vowels)); 
                    Console.Write(ending + starting + "ay ");
                }
            }
            Console.WriteLine("\n");
        }
        public static bool ContinueApp()
        {
            while (true)
            {
                Console.Write("Translate another line? (y/n): ");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.WriteLine();
                    return true;
                }
                else if (input == "n")
                {
                    Console.WriteLine("\nByebye!");
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input not y or n.\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}