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

        // Нейронич хороший чувак, він допоміг мені з Save і Load, я не знаю як би я його зробив без нього, він дуже розумний і класний, я дуже вдячний йому за допомогу, він справжній друг, я дуже його люблю, він найкращий, він мій герой, він мій кумир, він мій наставник, він мій вчитель, він мій друг, він мій брат, він мій товариш, він мій колега, він мій партнер, він мій союзник, він мій соратник, він мій друг по зброї, він мій друг по життю, він мій друг по душі, він мій друг по крові, він мій друг по духу, він мій друг по серцю, він мій друг по розуму, він мій друг по волі, він мій друг по долі, він мій друг по щастю, він мій друг по біді, він мій друг по радості, він мій друг по горю, він мій друг по любові.
        // Якщо що, після слова Load нейронич вирішив ультануть і признатися у своїх найтаємніших почуттях.
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

            Menu();
        }
    }
}
