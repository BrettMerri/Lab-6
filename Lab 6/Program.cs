using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            while(true)
            {
                Console.Write("Enter a line to be translated: ");
                string input = Console.ReadLine().Trim().ToLower(); //Trims input and converts to all lowercase
                if (input.All(c => Char.IsLetter(c) || c == ' ') && !string.IsNullOrWhiteSpace(input)) //Validates if input is all letters/spaces and is not empty
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Error: Invalid input!\n");
                }
            }
        }
        public static string[] SplitIntoWords(string input)
        {
            string[] WordList = input.Split(' ');
            return WordList;
        }
        public static void PrintPigLatin(string[] input)
        {
            char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].IndexOfAny(vowels) == 0) { //If the word starts with a vowel
                    Console.Write(input[i] + "way ");
                }
                else if (input[i].IndexOfAny(vowels) == -1) //If a word with a "y" vowel like "my" is typed
                {
                    Console.Write(input[i] + "ay ");
                }
                else
                {
                    string starting = input[i].Substring(0, input[i].IndexOfAny(vowels)); //Creates a substring starting at index 0 to the length of the index of the first vowel
                    string ending = input[i].Substring(input[i].IndexOfAny(vowels)); //Creates a substring at index of the first vowel to the end of the word
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
                    return false;
                else
                {
                    Console.WriteLine("Error: Input not y or n.\n");
                }
            }
        }
    }
}
