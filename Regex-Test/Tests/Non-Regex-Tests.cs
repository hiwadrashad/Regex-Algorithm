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
        public void SINGLE_CHARACTER_INPUT_NON_REGEX_DYNAMIC()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.linearmatches("aa", "a"));
        }

        [Fact]
        public void SINGLE_CHARACTER_ZERO_OR_MORE_INPUT_NON_REGEX_DYNAMIC()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.linearmatches("aa", "a*"));
        }

        [Fact]
        public void ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX_DYNAMIC()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.linearmatches("ab", ".*"));
        }

        [Fact]
        public void MULTIPLE_CHARACHTER_ZERO_OR_MORE_ANY_CHARACTER_INPUT_NON_REGEX_DYNAMIC()
        {
            Assert.True(Regex_Implementation.Non_Regex.Non_Regex_Implementation.linearmatches("aab", "c*a*b"));
        }


        [Fact]
        public void MISSISSIPI_INPUT_NON_REGEX_DYNAMIC()
        {
            Assert.False(Regex_Implementation.Non_Regex.Non_Regex_Implementation.linearmatches("mississippi", "mis*is*p*"));
        }
    }
}
