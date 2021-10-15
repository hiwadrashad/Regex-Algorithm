using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Regex_Test.Tests
{
    public class Regex_Tests
    {
        [Fact]
        public void SINGLE_CHARACTER_INPUT_REGEX()
        {
            Assert.False(Regex_Implementation.Regex.Regex_Implementation.matches("aa", "a"));
        }

        [Fact]
        public void SINGLE_CHARACTER_ZERO_OR_MORE_INPUT_REGEX()
        {
            Assert.True(Regex_Implementation.Regex.Regex_Implementation.matches("aa", "a*"));
        }

        [Fact]
        public void ZERO_OR_MORE_ANY_CHARACTER_INPUT_REGEX()
        {
            Assert.True(Regex_Implementation.Regex.Regex_Implementation.matches("ab", ".*"));
        }

        [Fact]
        public void MULTIPLE_CHARACHTER_ZERO_OR_MORE_ANY_CHARACTER_INPUT_REGEX()
        {
            Assert.True(Regex_Implementation.Regex.Regex_Implementation.matches("aab", "c*a*b"));
        }


        [Fact]
        public void MISSISSIPI_INPUT_REGEX()
        {
            Assert.False(Regex_Implementation.Regex.Regex_Implementation.matches("mississippi", "mis*is*p*"));
        }
    }
}
