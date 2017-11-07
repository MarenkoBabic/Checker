namespace CheckersTest
{
    using Checkers.ViewModels;
    using Xunit;
    public class OddEvenCheckerTest
    {
        [Fact]
        public void OddEvenTheStringIsOnlyNumbers_ReturnTrue()
        {
            //Arrange
            IChecker checker = new OddEvenChecker();

            //Act
            bool isOnlyNumbersAndEven = checker.Validate( "1234567890" );

            //Assert
            Assert.True( isOnlyNumbersAndEven );
        }

        [Fact]
        public void OddEvenTheStringIsOnlyNumbersAndOdd_ReturnFalse()
        {
            //Arrange
             IChecker checker = new  OddEvenChecker();

            //Act
            bool isOnlyNumbersAndOdd = checker.Validate( "1234567" );

            //Assert
            Assert.False( isOnlyNumbersAndOdd );
        }

        [Fact]
        public void OddEvenTheStringIsEven_ReturnTrue()
        {
            //Arrange
             IChecker checker = new  OddEvenChecker();

            //Act
            bool isEven = checker.Validate( "100" );

            //Assert
            Assert.True( isEven );
        }

        [Fact]
        public void OddEvenTheStringIsOdd_ReturnFalse()
        {
            //Arrange
             IChecker checker = new  OddEvenChecker();

            //Act
            bool isOdd = checker.Validate( "99" );

            //Assert
            Assert.False( isOdd );
        }

        [Fact]
        public void OddEvenTheStringIsNotOnlyNumbers_ReturnTrue()
        {
            //Arrange
             IChecker checker = new  OddEvenChecker();

            //Act
            bool isOnlyNumbers = checker.Validate( "12ab34cd" );

            //Assert
            Assert.True( isOnlyNumbers );
        }

        [Fact]
        public void OddEvenTheStringIsNull_ReturnFalse()
        {
            //Arrange
             IChecker checker = new  OddEvenChecker();

            //Act
            bool isNull = checker.Validate( null );

            //Assert
            Assert.False( isNull );
        }
    }
}
