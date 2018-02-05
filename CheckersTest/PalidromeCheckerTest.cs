namespace CheckersTest
{
    using Checkers.ViewModels;
    using System;
    using Xunit;
    public class PalidromeCheckerTest
    {
        [Fact]
        public void PalindromeTheStringIsEmpty_ReturnFalse()
        {
            //Arrange
            IChecker checker = new PalindromeChecker();

            //Act
            bool isPalidrome = checker.Validate( String.Empty );

            //Assert
            Assert.False( isPalidrome );
        }

        [Fact]
        public void PalindromeTheStringIsAPalindromeWith2Letters_ReturnTrue()
        {
            //Arrange
            IChecker checker = new PalindromeChecker();

            //Act
            bool isPalidrome = checker.Validate( "aa" );

            //Assert
            Assert.True( isPalidrome );
        }

        [Fact]
        public void PalindromeTheStringIsAPalindromeWith3Letters_ReturnTrue()
        {
            //Arrange
            IChecker checker = new PalindromeChecker();

            //Act
            bool isPalidrome = checker.Validate( "mom" );

            //Assert
            Assert.True( isPalidrome );
        }

        [Fact]
        public void PalindromeTheStringIsNotAPalindrome_ReturnFalse()
        {
            //Arrange
            IChecker checker = new PalindromeChecker();

            //Act
            bool isPalidrome = checker.Validate( "abcd" );

            //Assert
            Assert.False( isPalidrome );
        }

        [Fact]
        public void PalindromeTheStringIsNotAPalindromeWith3Letters_ReturnFalse()
        {
            //Arrange
            IChecker checker = new PalindromeChecker();

            //Act
            bool isPalidrome = checker.Validate( "Opa" );

            //Assert
            Assert.False( isPalidrome );
        }

        [Fact]
        public void PalidromeTheStringIsAPalidromeWithSentence_ReturnTrue()
        {
            //Arrange
            IChecker checker = new PalindromeChecker();

            //Act
            bool isPalidrome = checker.Validate( "Geist ziert Leben, Mut hegt Siege, Beileid trägt belegbare Reue, Neid dient nie, nun eint Neid die Neuerer, abgelebt gärt die Liebe, Geist geht, umnebelt reizt Sieg." );

            //Assert
            Assert.True( isPalidrome );
        }
    }
}
