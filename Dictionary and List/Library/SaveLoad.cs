using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dictionary_and_List
{
    static public class SaveLoad
    {
        static public void Save(Dictionary<string, string> dictionary)
        {
            try
            {
                string json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
                File.WriteAllText("data.json", json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("!ПОМИЛКА ЗБЕРЕЖЕННЯ!  Причина: " + ex.Message);
            }
        }

        static public Dictionary<string, string> Load()
        {
            try
            {
                if (!File.Exists("data.json"))
                    return new Dictionary<string, string>();

                string json = File.ReadAllText("data.json");

                return JsonConvert.DeserializeObject<Dictionary<string, string>>(json)
                       ?? new Dictionary<string, string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("!ПОМИЛКА ЗАВАНТАЖЕННЯ КОНТАКТІВ!  Причина: " + ex.Message);
                return new Dictionary<string, string>();
            }
        }

        public static void SaveContacts(string name, string phone, string text, Dictionary<string, string> contacts)
        {
            contacts[name] = phone;
            SaveLoad.Save(contacts);
            Console.WriteLine(text);
        }
    }
}
