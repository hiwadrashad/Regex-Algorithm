using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Regex_Implementation.Regex
{
    public class Regex_Implementation
    {
        public static bool matches(string input, string rgxstring)
        {
            if (rgxstring.Contains(".*"))
            {
                return true;
            }
            if (!rgxstring.Contains("*") && !rgxstring.Contains(".") && input.Length != rgxstring.Length)
            {
                return false;
            }
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex($"{rgxstring}");
            List<string> allstrings = new List<string>();
            List<char> allcharacters = new List<char>();
            var item1 = regex.Matches(input);
            foreach (var item in item1)
            {
                allstrings.Add(item.ToString());
            }
            foreach (var sub in allstrings)
            {
                var choppedupstring = sub.ToCharArray().ToList();
                foreach (var subchar in choppedupstring)
                {
                    allcharacters.Add(subchar);
                }
            }
            if (input.Length == allcharacters.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
