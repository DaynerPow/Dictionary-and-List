using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Dictionary_and_List
{
    internal class Program
    {
        public static void Menu()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("МЕНЮ");
                    Console.WriteLine("1. Додати контакт");
                    Console.WriteLine("2. Редагувати контакт");
                    Console.WriteLine("3. Видалити контакт");
                    Console.WriteLine("4. Знайти контакт");
                    Console.WriteLine("5. Показати всі контакти");
                    Console.WriteLine("0. Вихід");
                    Console.Write("Ваш вибір: ");

                    string choice = Console.ReadLine();
                    Console.Clear();

                    switch (choice)
                    {
                        case "1":
                            ContactsLib.AddContact();
                            break;

                        case "2":
                            ContactsLib.RedactContact();
                            break;

                        case "3":
                            ContactsLib.DeleteContact();
                            break;

                        case "4":
                            ContactsLib.SearchContact();
                            break;

                        case "5":
                            ContactsLib.ShowContacts();
                            break;

                        case "0":
                            Console.WriteLine("До побачення!");
                            return;

                        default:
                            ConsoleLib.WriteLineAndSound("!Невірний набір!");
                            break;
                    }

                    Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("!ПОМИЛКА!  Причина: " + ex.Message);
            }
        }
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

        static public void Save(Dictionary<string, string> dictionary)
        {
            string json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
            File.WriteAllText("data.json", json);
        }

        static public Dictionary<string, string> Load()
        {
            if (!File.Exists("data.json"))
                return new Dictionary<string, string>();

            string json = File.ReadAllText("data.json");

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json)
                   ?? new Dictionary<string, string>();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            try
            {
                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("!ПОМИЛКА!  Причина: " + ex.Message);
            }
            
        }
    }
}
