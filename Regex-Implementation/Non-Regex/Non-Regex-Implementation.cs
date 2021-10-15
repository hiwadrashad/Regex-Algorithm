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


        /// <summary>
        /// individual non inter-dependant algorithms
        /// </summary>
        /// 
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

        /// <summary>
        /// non custom code
        /// </summary>
        /// 
        public static bool matches2(string s, string p)
        {
            int rows = s.Length;
            int columns = p.Length;
            if (rows == 0 && columns == 0)
            {
                return true;
            }
            if (columns == 0)
            {
                return false;
            }
            bool[,] dp = new bool[rows + 1,columns + 1];
            dp[0,0] = true;
            for (int i = 2; i < columns + 1; i++)
            {
                if (p[i - 1] == '*')
                {
                    dp[0,i] = dp[0,i - 2];
                }
            }
            for (int i = 1; i < rows + 1; i++)
            {
                for (int j = 1; j < columns + 1; j++)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
                    {
                        dp[i,j] = dp[i - 1,j - 1];
                    }
                    else if (j > 1 && p[j - 1] == '*')
                    {
                        dp[i,j] = dp[i,j - 2];
                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                        {
                            dp[i,j] = dp[i,j] | dp[i - 1,j];
                        }
                    }
                }
            }
            return dp[rows,columns];
        }
        public bool matches3(string text, string pattern)
        {
            if (pattern.IsNullOrWhiteSpace()) return text.IsNullOrWhiteSpace();
            bool first_match = (!text.IsNullOrWhiteSpace() &&
                                   (pattern[0] == text[0] || pattern[0] == '.'));

            if (pattern.Length >= 2 && pattern[1] == '*')
            {
                return (matches3(text, pattern[2].ToString()) ||
                        (first_match && matches3(text.Substring(1), pattern)));
            }
            else
            {
                return first_match && matches3(text.Substring(1), pattern.Substring(1));
            }
        }
    }
}
