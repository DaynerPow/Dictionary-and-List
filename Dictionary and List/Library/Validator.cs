using System;
using System.Collections.Generic;

namespace Dictionary_and_List
{
    public class Validator
    {
        public static bool IsValidPhone(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c) && c != '+' && c != '#' && c != '*')
                    return false;
            }

            return true;
        }

        public static bool IsContactsEmpty(Dictionary<string, string> contacts)
        {
            if (contacts.Count == 0)
            {
                ConsoleLib.WriteLineAndSound("!Немає контактів!");
                return true;
            }
            return false;
        }

        public static bool IsSameName(string name, Dictionary<string, string> contacts)
        {
            if (contacts.ContainsKey(name))
            {
                ConsoleLib.WriteLineAndSound("!Контакт з таким ім'ям вже існує!");
                return true;
            }
            return false;
        }
    }
}
