using System;
using System.Collections.Generic;

namespace Dictionary_and_List
{
    public class ContactsOperations
    {
        private static Dictionary<string, string> contacts = SaveLoad.Load();


        public static void AddContact()
        {
            try
            {
                string name = ConsoleLib.Input("Введіть ім'я контакту:");
                string phone = ConsoleLib.Input("Введіть номер телефону:");

                ConsoleLib.InvalidPhoneMessage(phone);

                if (name.Length > 2 && phone.Length >= 5 && phone.Length <= 13)
                {
                    SaveLoad.SaveContacts(name, phone, "Контакт " + name + " з номером телефону " + phone + " додано.", contacts);
                }
                else
                    ConsoleLib.WriteLineAndSound("!Невірні дані! Ім'я має бути більше 2 символів, а номер телефону від 5 до 13 символів.");
                return;
            }
            catch (Exception ex)
            {
                ConsoleLib.WriteLineAndSound("!Помилка: " + ex.Message);
                return;
            }
        }


        public static void RedactContact()
        {
            try
            {
                if (Validator.IsContactsEmpty(contacts))
                    return;

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
                            SaveLoad.SaveContacts(newName, phone, "Контакт " + name + " перейменовано на " + newName + ".", contacts);
                        }
                        else
                            ConsoleLib.WriteLineAndSound("!Невірне ім'я контакту! Ім'я має бути більше 2 символів.");
                        return;


                    case "2":
                        string newPhone = ConsoleLib.Input("Введіть новий номер телефону:");

                        ConsoleLib.InvalidPhoneMessage(newPhone);

                        if (newPhone.Length >= 5 && newPhone.Length <= 13)
                        {
                            SaveLoad.SaveContacts(name, newPhone, "Контакт " + name + " оновлено.", contacts);
                        }
                        else
                            ConsoleLib.WriteLineAndSound("!Невірний номер телефону! Номер телефону має бути від 5 до 13 символів.");
                        return;


                    default:
                        ConsoleLib.WriteLineAndSound("!Невірний набір!");
                        break;
                }
                return;
            }
            catch (Exception ex)
            {
                ConsoleLib.WriteLineAndSound("!Помилка: " + ex.Message);
                return;
            }
        }


        public static void ShowContacts()
        {
            try
            {
                if (Validator.IsContactsEmpty(contacts))
                    return;

                Console.WriteLine("СПИСОК КОНТАКТІВ");
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact.Key + " - " + contact.Value);
                }
                return;
            }
            catch (Exception ex)
            {
                ConsoleLib.WriteLineAndSound("!Помилка: " + ex.Message);
                return;
            }
        }


        public static void SearchContact()
        {
            try
            {
                if (Validator.IsContactsEmpty(contacts))
                    return;

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
                {
                    ConsoleLib.WriteLineAndSound("Контакти не знайдені.");
                }
                return;
            }
            catch (Exception ex)
            {
                ConsoleLib.WriteLineAndSound("!Помилка: " + ex.Message);
                return;
            }
        }


        public static void DeleteContact()
        {
            try
            {
                if (Validator.IsContactsEmpty(contacts))
                    return;

                string name = ConsoleLib.Input("Введіть ім'я контакту для видалення:");

                if (contacts.ContainsKey(name))
                {
                    contacts.Remove(name);
                    SaveLoad.Save(contacts);
                    Console.WriteLine("Контакт " + name + " видалено.");
                }
                else
                {
                    ConsoleLib.WriteLineAndSound("!Контакт не знайдено!");
                }
                return;
            }
            catch (Exception ex)
            {
                ConsoleLib.WriteLineAndSound("!Помилка: " + ex.Message);
                return;
            }
        }
    }
}
