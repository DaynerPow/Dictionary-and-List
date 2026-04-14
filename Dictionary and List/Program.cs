using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary_and_List
{
    internal class Program
    {
        //Ось перша задача якщо що
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
            catch(Exception ex) 
            {
                Console.WriteLine("!ПОМИЛКА!  Причина: " + ex.Message);
            }
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            try
            {
                ConsoleLib.Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("!ПОМИЛКА!  Причина: " + ex.Message);
            }
            
        }
    }
}
