using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_and_List
{
    public class ContactsLib
    {
        private static Dictionary<string, string> contacts = new Dictionary<string, string>();


        public static void AddContact()
        {
            Console.WriteLine("Введіть ім'я контакту:");
            string name = Console.ReadLine();

            Console.WriteLine("Введіть номер телефону:");
            string phone = Console.ReadLine();

            if (name.Length > 2  &&  phone.Length >= 10  &&  phone.Length <= 12)
            {
                contacts[name] = phone;
                Console.WriteLine($"Контакт '{name}' з номером телефону '{phone}' додано.");
            }
            else Console.WriteLine("!Невірні дані! Ім'я має бути більше 2 символів, а номер телефону - від 10 до 12 символів.");
            Program.Menu();
        }


        public static void RedactContact()
        {
            Console.WriteLine("Введіть ім'я контакту для редагування:");
            string name = Console.ReadLine();

            if (!contacts.ContainsKey(name))
            {
                Console.WriteLine("!Контакт не знайдено!");
                Program.Menu();
            }


                Console.WriteLine("Редагуємо:" + "\n1. Ім'я контакту" + "\n2. Номер телефону");
                string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (contacts.ContainsKey(name))
                    {
                        Console.WriteLine("Введіть нове ім'я:");
                        string newName = Console.ReadLine();

                        if (newName.Length > 2)
                        {
                            string phone = contacts[name];
                            contacts.Remove(name);
                            contacts[newName] = phone;
                            Console.WriteLine($"Контакт '{name}' перейменовано на '{newName}'.");
                        }
                        else
                            Console.WriteLine("!Невірне ім'я! Ім'я має бути більше 2 символів.");
                    }
                    else
                    {
                        Console.WriteLine("!Контакт не знайдено!");
                    }
                    Program.Menu();
                    break;


                case "2":
                    if (contacts.ContainsKey(name))
                    {
                        Console.WriteLine("Введіть новий номер телефону:");
                        string newPhone = Console.ReadLine();

                        if (newPhone.Length >= 10 && newPhone.Length <= 12)
                        {
                            contacts[name] = newPhone;
                            Console.WriteLine($"Контакт '{name}' оновлено.");
                        }
                        else
                            Console.WriteLine("!Невірний номер телефону!");
                    }
                    else
                    {
                        Console.WriteLine("!Контакт не знайдено!");
                    }
                    Program.Menu();
                    break;


                default:
                    Console.WriteLine("!Невірний набір!");
                    break;
            }
        }


        public static void ShowContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Немає контактів.");
                return;
            }

            Console.WriteLine("=== СПИСОК КОНТАКТІВ ===");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.Key + " - " + contact.Value);
            }
        }


        public static void SearchContact()
        {
            Console.WriteLine("Введіть ім'я контакту для пошуку:");
            string searchContact = Console.ReadLine();

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
                Console.WriteLine("Контакти не знайдені.");
        }


        public static void DeleteContact()
        {
            Console.WriteLine("Введіть ім'я контакту для видалення:");
            string name = Console.ReadLine();

            if (contacts.ContainsKey(name))
            {
                contacts.Remove(name);
                Console.WriteLine($"Контакт '{name}' видалено.");
            }
            else
            {
                Console.WriteLine("!Контакт не знайдено!");
            }

        }
    }
}
