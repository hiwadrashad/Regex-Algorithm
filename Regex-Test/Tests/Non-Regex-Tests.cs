using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regex_Test.Tests
{
    public class Non_Regex_Tests
    {
        [Fact]
        public void SINGLE_CHARACTER_INPUT_NON_REGEX()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.linearmatches("aa", "a"));
        }

        [Fact]
        public void SINGLE_CHARACTER_ZERO_OR_MORE_INPUT_NON_REGEX()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.linearmatches("aa", "a*"));
        }

        [Fact]
        public void ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.linearmatches("ab", ".*"));
        }

        [Fact]
        public void MULTIPLE_CHARACHTER_ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.linearmatches("aab", "c*a*b"));
        }


        [Fact]
        public void MISSISSIPI_INPUT_NON_REGEX()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.linearmatches("mississippi", "mis*is*p*"));
        }

        [Fact]
        public void SINGLE_CHARACTER_INPUT_NON_REGEX_RECURSIVE_2()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursivematches2("aa", "a"));
        }

        [Fact]
        public void SINGLE_CHARACTER_ZERO_OR_MORE_INPUT_NON_REGEX_RECURSIVE_2()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursivematches2("aa", "a*"));
        }

        [Fact]
        public void ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX_RECURSIVE_2()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursivematches2("ab", ".*"));
        }

        [Fact]
        public void MULTIPLE_CHARACHTER_ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX_RECURSIVE_2()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursivematches2("aab", "c*a*b"));
        }


        [Fact]
        public void MISSISSIPI_INPUT_NON_REGEX_RECURSIVE_2()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursivematches2("mississippi", "mis*is*p*"));
        }



        [Fact]
        public void SINGLE_CHARACTER_INPUT_NON_REGEX_RECURSIVE_5()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursive5match("aa", "a"));
        }

        [Fact]
        public void SINGLE_CHARACTER_ZERO_OR_MORE_INPUT_NON_REGEX_RECURSIVE_5()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursive5match("aa", "a*"));
        }

        [Fact]
        public void ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX_RECURSIVE_5()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursive5match("ab", ".*"));
        }

        [Fact]
        public void MULTIPLE_CHARACHTER_ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX_RECURSIVE_5()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursive5match("aab", "c*a*b"));
        }


        [Fact]
        public void MISSISSIPI_INPUT_NON_REGEX_RECURSIVE_5()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursive5match("mississippi", "mis*is*p*"));
        }


        [Fact]
        public void SINGLE_CHARACTER_INPUT_NON_REGEX_DYNAMIC()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.dynamicprogrammingmatches("aa", "a"));
        }

        [Fact]
        public void SINGLE_CHARACTER_ZERO_OR_MORE_INPUT_NON_REGEX_DYNAMIC()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.dynamicprogrammingmatches("aa", "a*"));
        }

        [Fact]
        public void ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX_DYNAMIC()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.dynamicprogrammingmatches("ab", ".*"));
        }

        [Fact]
        public void MULTIPLE_CHARACHTER_ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX_DYNAMIC()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.dynamicprogrammingmatches("aab", "c*a*b"));
        }


        [Fact]
        public void MISSISSIPI_INPUT_NON_REGEX_DYNAMIC()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.dynamicprogrammingmatches("mississippi", "mis*is*p*"));
        }

        [Fact]
        public void SINGLE_CHARACTER_INPUT_NON_REGEX_RECURSIVE()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursivematch("aa", "a"));
        }

        [Fact]
        public void SINGLE_CHARACTER_ZERO_OR_MORE_INPUT_NON_REGEX_RECURSIVE()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursivematch("aa", "a*"));
        }

        [Fact]
        public void ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX_RECURSIVE()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursivematch("ab", ".*"));
        }

        [Fact]
        public void MULTIPLE_CHARACHTER_ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX_RECURSIVE()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursivematch("aab", "c*a*b"));
        }


        [Fact]
        public void MISSISSIPI_INPUT_NON_REGEX_RECURSIVE()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.recursivematch("mississippi", "mis*is*p*"));
        }
    }
}
