using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLib.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string RemoveDups(this string s)
        {
            // keep looking at the next element and the .Last one we added and only add the new one if they're different.
            List<char> tempChars = new List<char>();
            foreach (var element in s.ToCharArray())
            {
                if (tempChars.Count == 0 || tempChars.Last() != element)
                {
                    tempChars.Add(element);
                }
            }
            return string.Join("", tempChars);
        }
    }
}
