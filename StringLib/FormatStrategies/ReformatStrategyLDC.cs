using StringLib.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLib
{
    public class ReformatStrategyLDC : IReformatStrategy
    {
        // so for LDC reformat of a string we have the following rules ...
        // The input string may be any length and can contain any character
        // 1. Output strings must not be null or empty string
        // 2. string should be truncated to max length of 15 chars
        // 3. contiguous duplicate characters in the same case should be reduced to a single character in the same case
        // 4. Dollar sign ($) should be replaced with a pound sign(£)
        // 5. underscores(_) and number 4 should be removed
        public string ReformatString(string s)
        {
            string output = s;

            // satisfy 4. and 5. I did debate using StringBuilder here but it really won't make much difference
            output = output.Replace("$", "£").Replace("_", "").Replace("4", "");

            // satisfy 3. I moved this to an extension method purely to show another (albeit trivial) skill. I think by choice
            // I would have left it here so all the formatting for this strategy was in one place
            output = output.RemoveDups();

            // moved to extension method RemoveDups
            //List<char> tempChars = new List<char>();
            //foreach (var element in output.ToCharArray())
            //{
            //    if (tempChars.Count == 0 || tempChars.Last() != element)
            //    {
            //        tempChars.Add(element);
            //    }
            //}
            //output = string.Join("", tempChars);

            // satisfy 2.
            if (output.Length > 15)
            {
                output = output.Substring(0, 15);
            }

            if (string.IsNullOrEmpty(output))
            {
                // satisfy 1.
                output = "null or empty";
            }

            return output;
        }
    }
}
