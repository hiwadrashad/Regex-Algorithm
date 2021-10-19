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

        public static void cleanrecursive(int columns, string pattern, bool[,] board, int x)
        {
            if (x >= columns + 1)
            {
                return;
            }
            if (pattern[x - 1] == '*')
            {
                board[0, x] = board[0, x - 2];
            }
            x = x + 1;
            cleanrecursive(columns, pattern, board, x);
        }

        public static void recursivesubbody(int columns, string text, string pattern, bool[,] board, int i, int j)
        {
            if (j >= columns + 1)
            {
                return;
            }
                if (pattern[j - 1] == '.' || text[i - 1] == pattern[j - 1])
                {
                    board[i, j] = board[i - 1, j - 1];
                }
                else if (pattern[j - 1] == '*' && j > 1)
                {
                    board[i, j] = board[i, j - 2];
                    if (pattern[j - 2] == text[i - 1] || pattern[j - 2] == '.')
                    {
                        board[i, j] = board[i - 1, j] | board[i, j] ;
                    }
                }
            
            j = j + 1;
            recursivesubbody(columns, text, pattern, board, i, j);

        }

        public static void recursivemainbody(int rows, int columns, string text, string pattern, bool[,] board, int i)
        {
            if (i >= rows +1)
            {
                return;
            }
            recursivesubbody(columns,text,pattern,board,i,1);
            i = i + 1;
            recursivemainbody(rows,columns, text, pattern,board,i);
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

            bool[,] board = new bool[rows + 1,columns + 1];
            board[0, 0] = true;


            cleanrecursive(columns, pattern, board, 2);

            recursivemainbody(rows, columns, text, pattern, board, 1);

            return board[rows,columns];
        }


        public bool recusrive3call(string s, string p)
        {
            return recursive3(s, p, 0, 0);
        }
        public bool recursive3(string s, string p, int i, int j)
        {
            if (i == s.Count() && j == p.Count())
            { 
                return true; 
            }
            if (i == s.Count() && j <= p.Count() - 2 && p[j + 1] == '*')
            {
                return recursive3(s, p, i, j + 2);
            }

            if (j == p.Count() || i == s.Count())
            {
                return false;
            }
            

            if (p[j] == '.' && j + 1 < p.Count() && p[j + 1] == '*')
            { 
                return recursive3(s, p, i + 1, j) || recursive3(s, p, i, j + 2);
            }

            if (j + 1 < p.Count() && p[j + 1] == '*')
            {
                return recursive3(s, p, i, j + 2) || (s[i] == p[j] && recursive3(s, p, i + 1, j));
            }

            if (p[j] == '.')
            {
                return recursive3(s, p, i + 1, j + 1);
            }
            
            return (s[i] == p[j] && recursive3(s, p, i + 1, j + 1));
        }

        public static int i = 0;
        public static int j = 0;



        public static bool IsMatch3(string s, string p)
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
                    if (IsMatch(s, p) == false)
                    {
                        i = i - 1;
                    }
                    else 
                    {
                        return true;
                    }
                    j = j + 2;
                    if (IsMatch(s, p) == false)
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
                    if (IsMatch(s, p) == true)
                    {
                        j = j - 2;
                    }
                    else
                    {
                        return false;
                    }
                    i = i + 1;
                    if (IsMatch(s, p) == true)
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
                    if (IsMatch(s, p) == true)
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
                    if (IsMatch(s, p) == true)
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
                    return recursive5match(s.Remove(0,1), p.Remove(0, 1));
                }

            }
            else
            {
                int len = s.Count();

                int i = -1;
                while (i < len && (i < 0 || p[0] == '.' || p[0] == s[i]))
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
                        p.Remove(0,2);
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


        static void Main(string[] args)
        {
            bool something = IsMatch2("aa", "a*");
            Console.WriteLine(something);
        }
    }
}
