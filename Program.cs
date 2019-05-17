using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SecondHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"Choose variant input");
                Console.WriteLine(" 1. File input");
                Console.WriteLine(" 2. Console input");
                string a = Console.ReadLine();
                Console.Clear();
                string words;
                switch (a)
                {
                    case "1":
                        words = FileInput();
                        break;
                    case "2":
                        words = ConsoleInput();
                        break;
                    default:
                        throw new InvalidOperationException($"Bad value for type: {a}");
                }
                FrequencyOfWords(SplitWords(words));
                Console.WriteLine("     Click Escape to exit or any other button to continue.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static string FileInput()
        {
            Console.WriteLine("Enter the path");
            string name = @Console.ReadLine();
            Console.WriteLine(name);

            string fileContent = File.ReadAllText(name);
            Console.Clear();
            return fileContent;
        }

        private static string ConsoleInput()
        {
            Console.WriteLine("Enter the text");
            string fileContent = Console.ReadLine();
            Console.Clear();
            return fileContent;
        }

        private static string[] SplitWords(string fileContent)
            {
                string[] words = fileContent.ToLower().Split(" ,.?!()\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                return words;
            }

            private static void FrequencyOfWords(string[] words)
            {
                var WordsList = new SortedList<string, int>();
                foreach (var word in words)
                {
                    if (!WordsList.ContainsKey(word)) WordsList.Add(word, 1);
                    else WordsList[word]++;
                }

                var res = WordsList.OrderByDescending(x => x.Value);
                foreach (var word in res) Console.WriteLine("{0} {1:P2}", word.Key, (float)word.Value / words.Length);
            }
        }
}
