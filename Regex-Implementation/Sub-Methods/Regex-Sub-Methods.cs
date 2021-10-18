using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Regex_Implementation.Globals.Properties;

namespace Regex_Implementation.Sub_Methods
{
    public class Regex_Sub_Methods
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
                                if (SegregatedString[j + 2] == SegregatedString[i - itemsremoved])
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

        public static void emptyboard(int patternlength, bool[,] prototypeboard)
        {
            for (int i = 0; i < patternlength + 1; i++)
            {
                for (int j = 0; j < patternlength + 1; j++)
                {
                    prototypeboard[i, j] = false;
                }
            }
        }

        public static void dynamicprototypebody(string str, string pattern, bool[,] prototypeboard,int textlength, int patternlength)
        {
            for (int j = 1; j <= patternlength; j++)
            {
                if (pattern[j - 1] == '*')
                {
                    prototypeboard[0, j] = prototypeboard[0, j - 1];
                }
            }

            for (int i = 1; i <= textlength; i++)
            {
                for (int j = 1; j <= patternlength; j++)
                {

                    if (pattern[j - 1] == '*')
                    {
                        prototypeboard[i, j] = prototypeboard[i, j - 1]
                                       || prototypeboard[i - 1, j];
                    }
                    else if (pattern[j - 1] == '.'
                             || str[i - 1] == pattern[j - 1])
                    {
                        prototypeboard[i, j] = prototypeboard[i - 1, j - 1];
                    }

                    else
                    {
                        prototypeboard[i, j] = false;
                    }
                }
            }
        }

        public static bool dynamicprototype(string str,
                 string pattern,
                 int textlength, int patternlength)
        {
            if (pattern == ".*")
            {
                return true;
            }
            if (patternlength == 0)
            {
                return (textlength == 0);
            }

            bool[,] prototypeboard = new bool[textlength + 1, patternlength + 1];
            emptyboard(patternlength,prototypeboard);
            prototypeboard[0, 0] = true;
            dynamicprototypebody(str,pattern,prototypeboard,textlength,patternlength);
            return prototypeboard[textlength, patternlength];
        }

        public static void asterixcheck(string pattern)
        {
            board = new bool[rw + 1, clm + 1];
            board[0, 0] = true;
            for (int index = 2; index < clm + 1; index++)
            {
                if (pattern[index - 1] == '*')
                {
                    board[0, index] = board[0, index - 2];
                }
            }
        }

        public static bool? finalcheck(int rw, int clm)
        {
            if (rw == 0 && clm == 0)
            {
                return true;
            }
            if (clm == 0)
            {
                return false;
            }
            else
            {
                return null;
            }
        }

        public static bool[,] dynamicbody(string text, string pattern)
        {
            for (int index1 = 1; index1 < rw + 1; index1++)
            {
                for (int index2 = 1; index2 < clm + 1; index2++)
                {
                    if (text[index1 - 1] == pattern[index2 - 1] || pattern[index2 - 1] == '.')
                    {
                        board[index1, index2] = board[index1 - 1, index2 - 1];
                    }
                    else if (index2 > 1 && pattern[index2 - 1] == '*')
                    {
                        board[index1, index2] = board[index1, index2 - 2];
                        if (pattern[index2 - 2] == '.' || pattern[index2 - 2] == text[index1 - 1])
                        {
                            board[index1, index2] = board[index1, index2] | board[index1 - 1, index2];
                        }
                    }
                }
            }

            return board;
        }

        public static void cleanrecursive(int columns, string pattern, bool[,] board, int index)
        {
            if (index >= columns + 1)
            {
                return;
            }
            if (pattern[index - 1] == '*')
            {
                board[0, index] = board[0, index - 2];
            }
            index = index + 1;
            cleanrecursive(columns, pattern, board, index);
        }

        public static void recursivesubbody(int columns, string text, string pattern, bool[,] board, int index, int index2)
        {
            if (index2 >= columns + 1)
            {
                return;
            }
            if (pattern[index2 - 1] == '.' || text[index - 1] == pattern[index2 - 1])
            {
                board[index, index2] = board[index - 1, index2 - 1];
            }
            else if (pattern[index2 - 1] == '*' && index2 > 1)
            {
                board[index, index2] = board[index, index2 - 2];
                if (pattern[index2 - 2] == text[index - 1] || pattern[index2 - 2] == '.')
                {
                    board[index, index2] = board[index - 1, index2] | board[index, index2];
                }
            }

            index2 = index2 + 1;
            recursivesubbody(columns, text, pattern, board, index, index2);

        }

        public static void recursivemainbody(int rows, int columns, string text, string pattern, bool[,] board, int index)
        {
            if (index >= rows + 1)
            {
                return;
            }
            recursivesubbody(columns, text, pattern, board, index, 1);
            index = index + 1;
            recursivemainbody(rows, columns, text, pattern, board, index);
        }

        public static bool recursive3(string text, string pattern, int index, int index2)
        {
            if (index == text.Count() && index2 == pattern.Count())
            {
                return true;
            }
            if (index == text.Count() && index2 <= pattern.Count() - 2 && pattern[index2 + 1] == '*')
            {
                return recursive3(text, pattern, index, index2 + 2);
            }

            if (index2 == pattern.Count() || index == text.Count())
            {
                return false;
            }


            if (pattern[index2] == '.' && index2 + 1 < pattern.Count() && pattern[index2 + 1] == '*')
            {
                return recursive3(text, pattern, index + 1, index2) || recursive3(text, pattern, index, index2 + 2);
            }

            if (index2 + 1 < pattern.Count() && pattern[index2 + 1] == '*')
            {
                return recursive3(text, pattern, index, index2 + 2) || (text[index] == pattern[index2] && recursive3(text, pattern, index + 1, index2));
            }

            if (pattern[index2] == '.')
            {
                return recursive3(text, pattern, index + 1, index2 + 1);
            }

            return (text[index] == pattern[index2] && recursive3(text, pattern, index + 1, index2 + 1));
        }
    }
}
