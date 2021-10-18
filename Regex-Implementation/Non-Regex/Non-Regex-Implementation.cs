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

        public bool recusrivematches3(string s, string p)
        {
            return Sub_Methods.Regex_Sub_Methods.recursive3(s, p, 0, 0);
        }
        public static bool recursivematches2(string text, string pattern)
        {
            Globals.Properties.rw = text.Count();
            Globals.Properties.clm = pattern.Count();
            if (Globals.Properties.rw == 0 && Globals.Properties.clm == 0)
            {
                return true;
            }
            if (Globals.Properties.clm == 0)
            {
                return false;
            }

            bool[,] board = new bool[Globals.Properties.rw + 1, Globals.Properties.clm + 1];
            board[0, 0] = true;


            Sub_Methods.Regex_Sub_Methods.cleanrecursive(Globals.Properties.clm, pattern, board, 2);

            Sub_Methods.Regex_Sub_Methods.recursivemainbody(Globals.Properties.rw, Globals.Properties.clm, text, pattern, board, 1);

            return board[Globals.Properties.rw, Globals.Properties.clm];
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
            var finishedboard = Sub_Methods.Regex_Sub_Methods.dynamicbody(s, p);
            return Globals.Properties.board[Globals.Properties.rw, Globals.Properties.clm];
        }

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

        public static bool recursive5match(string s, string p)
        {

            if (p.Count() == 0)
            {
                if (s.Count() == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (p.Count() == 1 || p[1] != '*')
            {
                if (s.Count() < 1 || (p[0] != '.' && s[0] != p[0]))
                {
                    return false;
                }
                else
                {
                    return recursive5match(s.Remove(0, 1), p.Remove(0, 1));
                }

            }
            else
            {
                int l = s.Count();

                int i = -1;
                while (i < l && (i < 0 || p[0] == '.' || p[0] == s[i]))
                {
                    if (recursive5match(s.Remove(0, i + 1), p.Remove(0, 2)))
                    {
                        return true;
                    }
                    i = i + 1;
                }
                return false;
            }
        }

        public static bool linear2matches(string s, string p)
        {
            while (0 == 0)
            {
                if (p.Count() == 0)
                {
                    if (s.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (p.Count() == 1 || p[1] != '*')
                {
                    if (s.Count() < 1 || (p[0] != '.' && s[0] != p[0]))
                    {
                        return false;
                    }
                    else
                    {
                        s.Remove(0, 1);
                        p.Remove(0, 1);
                        continue;
                    }

                }
                else
                {
                    int len = s.Count();

                    int i = -1;
                    while (i < len && (i < 0 || p[0] == '.' || p[0] == s[i]))
                    {
                        s.Remove(0, i + 1);
                        p.Remove(0, 2);
                        continue;
                    }
                    return false;
                }
            }
        }

        public static int i = 0;
        public static int j = 0;
        public static bool recursive4match(string s, string p)
        {
            while (0 == 0)
            {
                if (i == s.Count() && j == p.Count())
                {
                    return true;
                }
                if (i == s.Count() && j <= p.Count() - 2 && p[j + 1] == '*')
                {
                    j = j + 2;
                    continue;
                }
                if (j == p.Count() || i == s.Count())
                {
                    return false;
                }


                if (p[j] == '.' && j + 1 < p.Count() && p[j + 1] == '*')
                {
                    i = i + 1;
                    if (recursive4match(s, p) == false)
                    {
                        i = i - 1;
                    }
                    else
                    {
                        return true;
                    }
                    j = j + 2;
                    if (recursive4match(s, p) == false)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                if (j + 1 < p.Count() && p[j + 1] == '*')
                {
                    j = j + 2;
                    if (recursive4match(s, p) == true)
                    {
                        j = j - 2;
                    }
                    else
                    {
                        return false;
                    }
                    i = i + 1;
                    if (recursive4match(s, p) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (p[j] == '.')
                {
                    i = i + 1;
                    j = j + 1;
                    if (recursive4match(s, p) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (!(s[i] == p[j]))
                {
                    return false;
                }
                else
                {
                    i = i + 1;
                    j = j + 1;
                    if (recursive4match(s, p) == true)
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

    }
}
