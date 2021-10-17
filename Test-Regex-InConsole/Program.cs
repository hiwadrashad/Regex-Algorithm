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
            int skipindex = 0;
            int skipindexregex = 0;
            for (int i = 0; i < regex.Count; i++)
            {
                if (i + skipindexregex < regex.Count)
                {
                    if ((i + skipindex) < text.Count)
                    {

                        if (regex[i + skipindexregex] == '*')
                        {
                            skipindexregex = skipindexregex + 1;
                        }
                        if ((text[i + skipindex] == regex[i + skipindexregex]) || (regex[i + skipindexregex] == '.'))
                        {

                            if (i + skipindexregex + 1 < regex.Count)
                            {

                                if (regex[i + skipindexregex + 1] == '*')
                                {
                                    if ((i + skipindex + 1) < text.Count)
                                    {

                                        for (int x = (i + skipindex) + 1; x < text.Count; x++)
                                        {
                                            if (text[x] == text[i + skipindex])
                                            {
                                                skipindex = skipindex = skipindex + 1;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }


                                    }

                                }

                            }
                            else
                            {
                                if ((i + skipindex + 1) != text.Count)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }

                        }
                        else
                        {
                            if (i + 1 < regex.Count)
                            {

                                if (regex[i + 1 + skipindexregex] == '*')
                                {
                                    skipindex = skipindex - 1;
                                    skipindexregex = skipindexregex + 1;
                                }
                                else
                                {
                                    return false;
                                }

                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if ((i + skipindexregex) < regex.Count)
                    {
                        if (regex[i + skipindexregex - 3] == text[i + skipindex - 1])
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool matches(string s, string p)
        {

            List<char> segregatedinput = s.ToCharArray().ToList();
            List<char> segregatedandcleanedregex = RemoveUneccessaryDuplicates(p);
            if (!p.Contains(".") && !p.Contains("*"))
            {
                if (s != p)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            if (p == ".*")
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
              return IterateSubstrings(segregatedinput,segregatedandcleanedregex);
            }

        }



            public bool isMatch(string text, string pattern)
            {
            if (pattern.IsNullOrWhiteSpace())
            { 
                return true; 
            }
              bool first_match = (!text.IsNullOrWhiteSpace() &&
                                   (pattern[0] == text[0] || pattern[0] == '.'));

            if (pattern.Count() >= 2 && pattern[1] == '*')
            {
                return (isMatch(text, pattern.Remove(0,2)) ||
                        (first_match && isMatch(text.Remove(0,1), pattern)));
            }
            else
            {
                return first_match && isMatch(text.Remove(0,1), pattern.Remove(0,1));
            }
        }





        public static string removeinitialduplicates(string input)
        {
            if (input.Length == 0 || input.All(ch => ch == input[0]))
            {
                return "";
            }
            char initialcharacter = input[0];
            for (int i = 0; i < input.Count(); i++)
            {
                if (input[i] != initialcharacter)
                {
                    return (input.Remove(0, i));
                }
            }

            return input;
        }


        public static bool recursivematch(string text, string pattern)
        {
            if (pattern == ".*")
            {
                return true;
            }
            if (pattern != "" && text == "")
            {
                return false;
            }
            if (pattern == "" && text != "")
            {
                return false;
            }
            if (cycles != 0)
            {
                if (pattern == "")
                {
                    return true;
                }
            }
            else
            {
                cycles = cycles + 1;
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

            if (pattern.Count() >= 2 && pattern[1] == '*' && !first_match)
            {
                return (recursivematch(text, pattern.Remove(0, 2)));
            }
            if (pattern.Count() >= 2 && pattern[1] == '*')
            {
                var item2 = removeinitialduplicates(text);
                return (recursivematch(removeinitialduplicates(text), pattern.Remove(0, 2)));
            }
            else
            {
                return recursivematch(text.Remove(0, 1), pattern.Remove(0, 1));
            }
        }



        public static int cycles = 0;

        public static List<string> wildcardcharacters = new List<string>();
        public static string textclone = "";

        public static bool IsMatch(string text, string pattern)
        {
            if (textclone == null)
            {
                textclone = "";
            }
            if (cycles == 0)
            {
                textclone = (string)text.Clone();
            }
            
            if (pattern == "" && text == "")
            {
                return true;
            }
            pattern = new string (RemoveUneccessaryDuplicates(pattern).ToArray());
            if (pattern == ".*")
            {
                return true;
            }
            if (pattern != "" && text == "" && wildcardcharacters.Count == 0 && !pattern.Contains("*"))
            {
                return false;
            }
            if (pattern == "" && text != "" && wildcardcharacters.Count == 0)
            {
                return false;
            }
            else
            {
                cycles = cycles + 1;
            }

            bool first_match;

            if (text == "" && wildcardcharacters.Count > 0)
            {
                first_match = false;
            }
            else
            if (pattern == "" && wildcardcharacters.Count > 0)
            {
                return false;
            }
            else
            {
                try
                {
                    first_match = ((pattern[0] == text[0] || pattern[0] == '.') || wildcardcharacters.Contains(pattern[0].ToString()));
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (IndexOutOfRangeException ex)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    first_match = false;
                }
       
            }


            if (first_match == false)
            {

                if (pattern.Length > 1)
                {
                    if (!(pattern[1] == '*'))
                    {
                        if (textclone.Count() > 0)
                        {
                            if (textclone[0] == pattern[0])
                            {
                                textclone = textclone.Remove(0, 1);
                                return (IsMatch(text, pattern.Remove(0, 1)));
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        wildcardcharacters.Add(pattern[0].ToString());
                        return (IsMatch(text, pattern.Remove(0, 2)));
                    }
                }
                else
                {
                    if (textclone.Count() > 0)
                    {
                        if (textclone[0] == pattern[0])
                        {
                            textclone = textclone.Remove(0, 1);
                            return (IsMatch(text, pattern.Remove(0, 1)));
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            else
            {
                if (pattern.Count() >= 2 && pattern[1] == '*')
                {
                    wildcardcharacters.Add(pattern[0].ToString());
                    return (IsMatch(removeinitialduplicates(text), pattern.Remove(0, 2)));
                }
                else
                {
                    wildcardcharacters.Clear();
                    if (text.Count() == 0 && pattern.Count() != 0)
                    {
                        return IsMatch(text, pattern.Remove(0, 1));
                    }
                    else if (text.Count() != 0 && pattern.Count() == 0)
                    {
                        return IsMatch(text.Remove(0, 1), pattern);
                    }
                    else if (text.Count() == 0 && pattern.Count() == 0)
                    {
                        return IsMatch(text, pattern);
                    }
                    else
                    {  
                        if (textclone.Count() > 0)
                        {
                            textclone = textclone.Remove(0, 1);
                        }
                        return IsMatch(text.Remove(0, 1), pattern.Remove(0, 1));
                    }
                }
            }
        }

 
        static void Main(string[] args)
        {
            bool something = IsMatch("aaa", "ab*a*c*a");
            Console.WriteLine(something);
        }
    }
}
