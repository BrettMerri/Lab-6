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
            Console.WriteLine("Welcome to the Pig Latin Translator!\n");
            string input = GetLetterInput();
            string[] words = SplitIntoWords(input);
            PrintPigLatin(words);
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
                if (input[i].IndexOfAny(vowels) == 0) {
                    Console.Write(input[i] + "way ");
                }
                else
                {
                    string starting = input[i].Substring(0, input[i].IndexOfAny(vowels));
                    string ending = input[i].Substring(input[i].IndexOfAny(vowels));
                    Console.Write(ending + starting + "ay ");
                }
            }
            Console.WriteLine();
        }
    }
}
