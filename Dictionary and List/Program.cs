using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_and_List
{
    internal class Program
    {
        static void Task1()
        {
            try
            {
                Console.WriteLine("Напишіть любі слова:");
                string words = Console.ReadLine().Trim();

                if (words.Length == 0)
                {
                    Console.WriteLine("!Немає слів!");
                    return;
                }


                List<string> wordsList = new List<string>();
                wordsList.AddRange(words.Split(' ' , ',' , '.'));

                Console.WriteLine("Список слів:");
                foreach (string word in wordsList)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                        Console.WriteLine(word);
                }

            }
            catch
            {
                Console.WriteLine("!Невірний набір!");
            }
        }


        static void Task2()
        {
            Dictionary<string, string> contacts = new Dictionary<string, string>();


        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Виберіть задачу (1, 2, 3):");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;

                /*case "2":
                    Task2();
                    break;

                case "3":
                    Task3();
                    break;*/

                default:
                    Console.WriteLine("!Невірний набір!");
                    break;
            }
        }
    }
}
