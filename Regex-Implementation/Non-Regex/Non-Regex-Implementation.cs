using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regex_Implementation.Extension_Methods;

namespace Regex_Implementation.Non_Regex
{
    public class Non_Regex_Implementation
    {

        public static bool linearmatches(string s, string p)
        {

            List<char> segregatedinput = s.ToCharArray().ToList();
            List<char> segregatedandcleanedregex = Sub_Methods.Regex_Sub_Methods.RemoveUneccessaryDuplicates(p);
            if (p.Contains(".*"))
            {
                return true;
            }
            else
            if (s == p)
            {
                return true;
            }
            else
            {
                return Sub_Methods.Regex_Sub_Methods.IterateSubstrings(segregatedinput, segregatedandcleanedregex);
            }

        }

        public static bool recursivematch(string text, string pattern)
        {
            if (pattern == ".*")
            {
                return true;
            }
            if (pattern == "" && text != "")
            {
                return false;
            }
            if (Globals.Properties.cycles != 0)
            {
                if (text == "")
                {
                    return true;
                }
            }
            else
            {
                Globals.Properties.cycles = Globals.Properties.cycles + 1;
            }
            bool first_match = ((pattern[0] == text[0] || pattern[0] == '.'));

            if (first_match == false)
            {
                if (pattern.Length > 1)
                {
                    if (!(pattern[1] == '*'))
                    {
                        return false;
                    }
                }
            }

            if (pattern.Count() >= 2 && pattern[1] == '*')
            {

                return (recursivematch(Sub_Methods.Regex_Sub_Methods.removeinitialduplicates(text), pattern.Remove(0, 2)));
            }
            else
            {
                return first_match && recursivematch(text.Remove(0, 1), pattern.Remove(0, 1));
            }
        }



        public static bool? dynamicprogrammingmatches(string s, string p)
        {
            Globals.Properties.clm = p.Length;
            Globals.Properties.rw = s.Length;
            var finalcheckvalue = Sub_Methods.Regex_Sub_Methods.finalcheck(Globals.Properties.rw, Globals.Properties.clm);
            if (finalcheckvalue != null)
            {
                return finalcheckvalue;
            }
            Sub_Methods.Regex_Sub_Methods.asterixcheck(p);
            var finishedboard = Sub_Methods.Regex_Sub_Methods.dynamicbody(s,p);
            return Globals.Properties.board[Globals.Properties.rw, Globals.Properties.clm];
        }
    }
}
