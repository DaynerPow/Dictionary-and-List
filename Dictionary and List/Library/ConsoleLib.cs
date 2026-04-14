using System;
using System.Media;

namespace Dictionary_and_List
{
    public class ConsoleLib
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
                            ContactsOperations.AddContact();
                            break;

                        case "2":
                            ContactsOperations.RedactContact();
                            break;

                        case "3":
                            ContactsOperations.DeleteContact();
                            break;

                        case "4":
                            ContactsOperations.SearchContact();
                            break;

                        case "5":
                            ContactsOperations.ShowContacts();
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


        public static void WriteLineAndSound(string message)
        {
            SystemSounds.Exclamation.Play();
            Console.WriteLine(message);
        }

        public static string Input(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }

        public static void InvalidPhoneMessage(string phone)
        {
            if (!Validator.IsValidPhone(phone))
            {
                ConsoleLib.WriteLineAndSound("!Невірний номер телефону! Номер може містити лише цифри, '+', '#' або '*'.");
                return;
            }
        }
    }
}
