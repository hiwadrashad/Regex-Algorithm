using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Regex_Implementation.Extension_Methods;
using System.Linq;

namespace Test_Regex_InConsole
{
    class Program
    {

        public static List<char> RemoveUneccessaryDuplicates(string input)
        {
            List<char> SegregatedString = new List<char>();
            SegregatedString = input.ToCharArray().ToList();
            int itemsremoved = 0;
            for (int i = 0; i < SegregatedString.Count; i++)
            {
                if (SegregatedString.Count > i + 2)
                {
                    if (SegregatedString[i + 1] == '*')
                    {
                        for (int j = i; i < SegregatedString.Count; i++)
                        {
                            if (j + 2 < SegregatedString.Count)
                            {
                                if (SegregatedString[j + 2] == SegregatedString[i-itemsremoved])
                                {
                                    SegregatedString.RemoveAt(j + 2);
                                    itemsremoved++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                return SegregatedString;
                            }
                        }
                    }
                }
            }
            return SegregatedString;


        }

        public static bool IterateSubstrings(List<char> text, List<char> regex)
        {
            for (int i = 0; i < text.Count; i++)
            {
                for ()
                { 
                
                }
            }
        }
        public static bool matches(string s, string p)
        {

            List<char> segregatedinput = s.ToCharArray().ToList();
            List<char> segregatedandcleanedregex = RemoveUneccessaryDuplicates(p);
            if (s.Contains(".*"))
            {
                return true;
            }
            else 
            {
               
            }
            return false;

        }
        static void Main(string[] args)
        {
            var CleanedCharList = RemoveUneccessaryDuplicates("ba*aab*");
            Console.WriteLine();
        }
    }
}
