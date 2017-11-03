namespace CheckersTest
{
    using System;
    using Xunit;
    public class PalidromeCheckerTest
    {
        [Fact]
        public void PalindromeTheStringIsEmpty_ReturnFalse()
        {
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            bool isPalidrome = checker.Validate( String.Empty );

            Assert.False( isPalidrome );
        }

        [Fact]
        public void PalindromeTheStringIsAPalindromeWith2Letters_ReturnTrue()
        {
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            bool isPalidrome = checker.Validate( "aa" );

            Assert.True( isPalidrome );
        }

        [Fact]
        public void PalindromeTheStringIsAPalindromeWith3Letters_ReturnTrue()
        {
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            bool isPalidrome = checker.Validate( "mom" );

            Assert.True( isPalidrome );
        }

        [Fact]
        public void PalindromeTheStringIsNotAPalindrome_ReturnFalse()
        {
            //Arrange
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            //Act
            bool isPalidrome = checker.Validate( "abcd" );

            //Assert
            Assert.False( isPalidrome );
        }

        [Fact]
        public void PalindromeTheStringIsNotAPalindromeWith3Letters_ReturnFalse()
        {
            //Arrange
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            //Act
            bool isPalidrome = checker.Validate( "Opa" );

            //Assert
            Assert.False( isPalidrome );
        }

        [Fact]
        public void PalidromeTheStringIsAPalidromeWithSentence_ReturnTrue()
        {
            //Arrange
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            //Act
            bool isPalidrome = checker.Validate( "Geist ziert Leben, Mut hegt Siege, Beileid trägt belegbare Reue, Neid dient nie, nun eint Neid die Neuerer, abgelebt gärt die Liebe, Geist geht, umnebelt reizt Sieg." );

            //Assert
            Assert.True( isPalidrome );
        }

        [Fact]
        public void PalidromeValidateIsNull_ReturnFalse()
        {
            //Arrange
            Checkers.IChecker checker = new Checkers.PalindromeChecker();

            //Act
            bool isPalidrome = checker.Validate( null );

            //Assert
            Assert.False( isPalidrome );
        }
    }
}
