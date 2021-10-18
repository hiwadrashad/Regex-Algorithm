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
            if (Globals.Properties.textclone == null)
            {
                Globals.Properties.textclone = "";
            }
            if (Globals.Properties.cycles == 0)
            {
                Globals.Properties.textclone = (string)text.Clone();
            }

            if (pattern == "" && text == "")
            {
                return true;
            }
            pattern = new string(Sub_Methods.Regex_Sub_Methods.RemoveUneccessaryDuplicates(pattern).ToArray());
            if (pattern == ".*")
            {
                return true;
            }
            if (pattern != "" && text == "" && Globals.Properties.wildcardcharacters.Count == 0 && !pattern.Contains("*"))
            {
                return false;
            }
            if (pattern == "" && text != "" && Globals.Properties.wildcardcharacters.Count == 0)
            {
                return false;
            }
            else
            {
                Globals.Properties.cycles = Globals.Properties.cycles + 1;
            }

            bool first_match;

            if (text == "" && Globals.Properties.wildcardcharacters.Count > 0)
            {
                first_match = false;
            }
            else
            if (pattern == "" && Globals.Properties.wildcardcharacters.Count > 0)
            {
                return false;
            }
            else
            {
                try
                {
                    first_match = ((pattern[0] == text[0] || pattern[0] == '.') || Globals.Properties.wildcardcharacters.Contains(pattern[0].ToString()));
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
                        if (Globals.Properties.textclone.Count() > 0)
                        {
                            if (Globals.Properties.textclone[0] == pattern[0])
                            {
                                Globals.Properties.textclone = Globals.Properties.textclone.Remove(0, 1);
                                return (recursivematch(text, pattern.Remove(0, 1)));
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
                        Globals.Properties.wildcardcharacters.Add(pattern[0].ToString());
                        return (recursivematch(text, pattern.Remove(0, 2)));
                    }
                }
                else
                {
                    if (Globals.Properties.textclone.Count() > 0)
                    {
                        if (Globals.Properties.textclone[0] == pattern[0])
                        {
                            Globals.Properties.textclone = Globals.Properties.textclone.Remove(0, 1);
                            return (recursivematch(text, pattern.Remove(0, 1)));
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
                    Globals.Properties.wildcardcharacters.Add(pattern[0].ToString());
                    return (recursivematch(Sub_Methods.Regex_Sub_Methods.removeinitialduplicates(text), pattern.Remove(0, 2)));
                }
                else
                {
                    Globals.Properties.wildcardcharacters.Clear();
                    if (text.Count() == 0 && pattern.Count() != 0)
                    {
                        return recursivematch(text, pattern.Remove(0, 1));
                    }
                    else if (text.Count() != 0 && pattern.Count() == 0)
                    {
                        return recursivematch(text.Remove(0, 1), pattern);
                    }
                    else if (text.Count() == 0 && pattern.Count() == 0)
                    {
                        return recursivematch(text, pattern);
                    }
                    else
                    {
                        if (Globals.Properties.textclone.Count() > 0)
                        {
                            Globals.Properties.textclone = Globals.Properties.textclone.Remove(0, 1);
                        }
                        return recursivematch(text.Remove(0, 1), pattern.Remove(0, 1));
                    }
                }
            }
        }


        public static bool recursivematches2(string text, string pattern)
        {
            int rows = text.Count();
            int columns = pattern.Count();
            if (rows == 0 && columns == 0)
            {
                return true;
            }
            if (columns == 0)
            {
                return false;
            }

            bool[,] board = new bool[rows + 1, columns + 1];
            board[0, 0] = true;


            Sub_Methods.Regex_Sub_Methods.cleanrecursive(columns, pattern, board, 2);

            Sub_Methods.Regex_Sub_Methods.recursivemainbody(rows, columns, text, pattern, board, 1);

            return board[rows, columns];
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
