using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckersTest
{
    public class PalidromeCheckerTest
    {
        [Fact]
        public void TheStringIsEmpty_ReturnFalse()
        {
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            bool isPalidrome = checker.Validate( " " );

            Assert.False( isPalidrome );
        }

        [Fact]
        public void TheStringIsAPalindromeWith2Letters_ReturnTrue()
        {
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            bool isPalidrome = checker.Validate( "aa" );

            Assert.True( isPalidrome );
        }

        [Fact]
        public void TheStringIsAPalindromeWith3Letters_ReturnTrue()
        {
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            bool isPalidrome = checker.Validate( "mom" );

            Assert.True( isPalidrome );

        }


        [Fact]
        public void TheStringIsNotAPalindrome_ReturnFalse()
        {
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            bool isPalidrome = checker.Validate( "abcd" );

            Assert.False( isPalidrome );
        }

        [Fact]
        public void TheStringIsNotAPalindromeWith3Letters_ReturnFalse()
        {
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            bool isPalidrome = checker.Validate( "Opa" );

            Assert.False( isPalidrome );

        }

    }
}
