using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                                if (regex[i + 1] == '*')
                                {
                                    skipindexregex = skipindexregex + 2;
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
                    if (regex[i + skipindexregex - 3] == text[i + skipindex - 1])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void asterixcheck(string p)
        {
            Globals.Properties.board = new bool[Globals.Properties.rw + 1, Globals.Properties.clm + 1];
            Globals.Properties.board[0, 0] = true;
            for (int i = 2; i < Globals.Properties.clm + 1; i++)
            {
                if (p[i - 1] == '*')
                {
                    Globals.Properties.board[0, i] = Globals.Properties.board[0, i - 2];
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

        public static bool[,] dynamicbody(string s, string p)
        {
            for (int i = 1; i < Globals.Properties.rw + 1; i++)
            {
                for (int j = 1; j < Globals.Properties.clm + 1; j++)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
                    {
                        Globals.Properties.board[i, j] = Globals.Properties.board[i - 1, j - 1];
                    }
                    else if (j > 1 && p[j - 1] == '*')
                    {
                        Globals.Properties.board[i, j] = Globals.Properties.board[i, j - 2];
                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                        {
                            Globals.Properties.board[i, j] = Globals.Properties.board[i, j] | Globals.Properties.board[i - 1, j];
                        }
                    }
                }
            }

            return Globals.Properties.board;
        }
    }
}
