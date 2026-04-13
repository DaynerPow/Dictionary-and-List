using System;
using System.Collections.Generic;

namespace Dictionary_and_List
{
    public class ContactsLib
    {
        private static Dictionary<string, string> contacts = Program.Load();


        public static void AddContact()
        {
            string name = ConsoleLib.Input("Введіть ім'я контакту:");
            string phone = ConsoleLib.Input("Введіть номер телефону:");

            if (!IsValidPhone(phone))
            {
                ConsoleLib.WriteLineAndSound("!Невірний номер телефону! Номер може містити лише цифри, '+', '#' або '*'.");
                return;
            }

            if (name.Length > 2  &&  phone.Length >= 5  &&  phone.Length <= 13)
            {           
                contacts[name] = phone;
                Program.Save(contacts);
                Console.WriteLine("Контакт " + name + " з номером телефону " + phone + " додано.");
            }
            else
                ConsoleLib.WriteLineAndSound("!Невірні дані! Ім'я має бути більше 2 символів, а номер телефону від 5 до 13 символів.");
            return;
        }


        public static void RedactContact()
        {
            string name = ConsoleLib.Input("Введіть ім'я контакту для редагування:");

            if (!contacts.ContainsKey(name))
            {
                ConsoleLib.WriteLineAndSound("!Контакт не знайдено!");
                return;
            }
            else

                Console.WriteLine("Редагуємо:" + "\n1. Ім'я контакту" + "\n2. Номер телефону");
                string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                        string newName = ConsoleLib.Input("Введіть нове ім'я контакту:");

                    if (newName.Length > 2)
                        {
                            string phone = contacts[name];
                            contacts.Remove(name);
                            contacts[newName] = phone;
                            Program.Save(contacts);
                        Console.WriteLine("Контакт " + name + " перейменовано на " + newName + ".");
                        }
                        else
                            ConsoleLib.WriteLineAndSound("!Невірне ім'я контакту!");
                    return;
                    

                case "2":
                        string newPhone = ConsoleLib.Input("Введіть новий номер телефону:");

                    if (!IsValidPhone(newPhone))
                    {
                        ConsoleLib.WriteLineAndSound("!Невірний номер телефону! Номер може містити лише цифри, '+', '#' або '*'.");
                        return;
                    }

                    if (newPhone.Length >= 5 && newPhone.Length <= 13)
                        {
                            contacts[name] = newPhone;
                            Program.Save(contacts);
                        Console.WriteLine("Контакт " + name + " оновлено.");
                        }
                        else
                            ConsoleLib.WriteLineAndSound("!Невірний номер телефону!");
                    return;
                    

                default:
                    ConsoleLib.WriteLineAndSound("!Невірний набір!");
                    break;
            }
            return;
        }


        public static void ShowContacts()
        {
            if (contacts.Count == 0)
            {
                ConsoleLib.WriteLineAndSound("Немає контактів.");
                return;
            }

            Console.WriteLine("СПИСОК КОНТАКТІВ");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.Key + " - " + contact.Value);
            }
            return;
        }


        public static void SearchContact()
        {
            string searchContact = ConsoleLib.Input("Введіть ім'я контакту для пошуку:");

            bool found = false;

            foreach (var contact in contacts)
            {
                if (contact.Key.Contains(searchContact))
                {
                    Console.WriteLine(contact.Key + " - " + contact.Value);
                    found = true;
                }
            }
            if (!found)
                ConsoleLib.WriteLineAndSound("Контакти не знайдені.");
            return;
        }


        public static void DeleteContact()
        {
            string name = ConsoleLib.Input("Введіть ім'я контакту для видалення:");
    
            if (contacts.ContainsKey(name))
            {
                contacts.Remove(name);
                Program.Save(contacts);
                Console.WriteLine("Контакт " + name + " видалено.");
            }
            else
            {
                ConsoleLib.WriteLineAndSound("!Контакт не знайдено!");
            }
            return;
        }

        static bool IsValidPhone(string input)
        {
            foreach (char c in input) 
            {
                if (!char.IsDigit(c) && c != '+' && c != '#' && c != '*')
                    return false;
            }

            return true;
        }
    }
}
