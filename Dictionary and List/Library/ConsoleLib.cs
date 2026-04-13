using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_and_List
{
    public class ConsoleLib
    {
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
    }
}
