using System;

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
    }
}
