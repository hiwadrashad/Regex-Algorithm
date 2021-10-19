using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regex_Implementation.Extension_Methods;
using Regex_Implementation.Globals;
using Regex_Implementation.Sub_Methods;
using static Regex_Implementation.Globals.Properties;
using static Regex_Implementation.Sub_Methods.Regex_Sub_Methods;

namespace Regex_Implementation.Non_Regex
{
    public class Non_Regex_Implementation
    {

        public bool recusrivematches3(string s, string p)
        {
            return recursive3(s, p, 0, 0);
        }
        public static bool recursivematches2(string text, string pattern)
        {
            rw = text.Count();
            clm = pattern.Count();
            if (rw == 0 && clm == 0)
            {
                return true;
            }
            if (clm == 0)
            {
                return false;
            }

            bool[,] board = new bool[rw + 1, clm + 1];
            board[0, 0] = true;


            cleanrecursive(clm, pattern, board, 2);

            recursivemainbody(rw, clm, text, pattern, board, 1);

            return board[rw, clm];
        }

        public static bool? dynamicprogrammingmatches(string s, string p)
        {
            clm = p.Length;
            rw = s.Length;
            var finalcheckvalue = finalcheck(rw, clm);
            if (finalcheckvalue != null)
            {
                return finalcheckvalue;
            }
            asterixcheck(p);
            var finishedboard = dynamicbody(s, p);
            return board[rw, clm];
        }

        public static bool linearmatches(string s, string p)
        {

            List<char> segregatedinput = s.ToCharArray().ToList();
            List<char> segregatedandcleanedregex = RemoveUneccessaryDuplicates(p);
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
                return IterateSubstrings(segregatedinput, segregatedandcleanedregex);
            }

        }
        public static bool recursivematch(string text, string pattern)
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
            pattern = new string(RemoveUneccessaryDuplicates(pattern).ToArray());
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
                        wildcardcharacters.Add(pattern[0].ToString());
                        return (recursivematch(text, pattern.Remove(0, 2)));
                    }
                }
                else
                {
                    if (textclone.Count() > 0)
                    {
                        if (textclone[0] == pattern[0])
                        {
                            textclone = textclone.Remove(0, 1);
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
                    wildcardcharacters.Add(pattern[0].ToString());
                    return (recursivematch(removeinitialduplicates(text), pattern.Remove(0, 2)));
                }
                else
                {
                    wildcardcharacters.Clear();
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
                        if (textclone.Count() > 0)
                        {
                            textclone = textclone.Remove(0, 1);
                        }
                        return recursivematch(text.Remove(0, 1), pattern.Remove(0, 1));
                    }
                }
            }
        }

        public static bool recursive5match(string text, string pattern)
        {

            if (pattern.Count() == 0)
            {
                if (text.Count() == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (pattern.Count() == 1 || pattern[1] != '*')
            {
                if (text.Count() < 1 || (pattern[0] != '.' && text[0] != pattern[0]))
                {
                    return false;
                }
                else
                {
                    return recursive5match(text.Remove(0, 1), pattern.Remove(0, 1));
                }

            }
            else
            {
                int l = text.Count();

                int i = -1;
                while (i < l && (i < 0 || pattern[0] == '.' || pattern[0] == text[i]))
                {
                    if (recursive5match(text.Remove(0, i + 1), pattern.Remove(0, 2)))
                    {
                        return true;
                    }
                    i = i + 1;
                }
                return false;
            }
        }

        public static bool linear2matches(string text, string pattern)
        {
            while (0 == 0)
            {
                if (pattern.Count() == 0)
                {
                    if (text.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (pattern.Count() == 1 || pattern[1] != '*')
                {
                    if (text.Count() < 1 || (pattern[0] != '.' && text[0] != pattern[0]))
                    {
                        return false;
                    }
                    else
                    {
                        text.Remove(0, 1);
                        pattern.Remove(0, 1);
                        continue;
                    }

                }
                else
                {
                    int len = text.Count();

                    int i = -1;
                    while (i < len && (i < 0 || pattern[0] == '.' || pattern[0] == text[i]))
                    {
                        text.Remove(0, i + 1);
                        pattern.Remove(0, 2);
                        continue;
                    }
                    return false;
                }
            }
        }


        public bool recursive6match(string text, string pattern)
        {
            if (pattern.Count() == 0)
            {
                if (text.Count() == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            bool equalityfirstcharacter;
            if (!(text == "") && (pattern[0] == text[0] || pattern[0] == '.'))
            {
                equalityfirstcharacter = true;
            }
            else
            {
                equalityfirstcharacter = false;
            }


            if (pattern.Count() >= 2 && pattern[1] == '*')
            {
                if (recursive6match(text, pattern.Remove(0, 2)) || (equalityfirstcharacter && recursive6match(text.Remove(0, 1), pattern)))
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
                if (equalityfirstcharacter && recursive6match(text.Remove(0, 1), pattern.Remove(0, 1)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int index1 = 0;
        public static int index2 = 0;
        public static bool recursive4match(string text, string pattern)
        {
            while (0 == 0)
            {
                if (index1 == text.Count() && index2 == pattern.Count())
                {
                    return true;
                }
                if (index1 == text.Count() && index2 <= pattern.Count() - 2 && pattern[index2 + 1] == '*')
                {
                    index2 = index2 + 2;
                    continue;
                }
                if (index2 == pattern.Count() || index1 == text.Count())
                {
                    return false;
                }


                if (pattern[index2] == '.' && index2 + 1 < pattern.Count() && pattern[index2 + 1] == '*')
                {
                    index1 = index1 + 1;
                    if (recursive4match(text, pattern) == false)
                    {
                        index1 = index1 - 1;
                    }
                    else
                    {
                        return true;
                    }
                    index2 = index2 + 2;
                    if (recursive4match(text, pattern) == false)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                if (index2 + 1 < pattern.Count() && pattern[index2 + 1] == '*')
                {
                    index2 = index2 + 2;
                    if (recursive4match(text, pattern) == true)
                    {
                        index2 = index2 - 2;
                    }
                    else
                    {
                        return false;
                    }
                    index1 = index1 + 1;
                    if (recursive4match(text, pattern) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (pattern[index2] == '.')
                {
                    index1 = index1 + 1;
                    index2 = index2 + 1;
                    if (recursive4match(text, pattern) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (!(text[index1] == pattern[index2]))
                {
                    return false;
                }
                else
                {
                    index1 = index1 + 1;
                    index2 = index2 + 1;
                    if (recursive4match(text, pattern) == true)
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
