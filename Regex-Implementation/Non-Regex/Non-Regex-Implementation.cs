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
