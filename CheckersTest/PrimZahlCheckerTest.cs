namespace CheckersTest
{
    using Checkers.ViewModels;
    using Xunit;
    public class PrimZahlCheckerTest
    {
        [Fact]
        public void PrimzahlCheckerStringIsNull_ReturnFalse()
        {
            //Arrange
            IChecker checker = new PrimzahlChecker();

            //Act
            bool isPrimzahl = checker.Validate(null);

            //Assert
            Assert.False( isPrimzahl );
        }

        [Fact]
        public void PrimzahlCheckerStringIsEmpty_ReturnFalse()
        {
            //Arrange
            IChecker checker = new PrimzahlChecker();

            //Act
            bool isPrimzahl = checker.Validate(string.Empty);

            //Assert
            Assert.False( isPrimzahl );
        }

        [Fact]
        public void PrimzahlCheckerStringIsToLong_ReturnFalse()
        {
            //Arrange
            IChecker checker = new PrimzahlChecker();

            //Act
            bool isPrimzahl = checker.Validate("123456789123456");

            //Assert
            Assert.False( isPrimzahl );
        }

        [Fact]
        public void PrimzahlCheckerStringIsPrimzahl1Number_ReturnTrue()
        {
            //Arrange
            IChecker checker = new PrimzahlChecker();

            //Act
            bool isPrimzahl = checker.Validate("3");

            //Assert
            Assert.True( isPrimzahl );
        }

        [Fact]
        public void PrimzahlCheckerStringIsPrimzahl2Number_ReturnTrue()
        {
            //Arrange
            IChecker checker = new PrimzahlChecker();

            //Act
            bool isPrimzahl = checker.Validate("17");

            //Assert
            Assert.True( isPrimzahl );
        }

        [Fact]
        public void PrimzahlCheckerStringIsPrimzahl3Number_ReturnTrue()
        {
            //Arrange
            IChecker checker = new PrimzahlChecker();

            //Act
            bool isPrimzahl = checker.Validate("433");

            //Assert
            Assert.True( isPrimzahl );
        }
        [Fact]
        public void PrimzahlCheckerStringIsNotPrimzahl3Number_ReturnTrue()
        {
            //Arrange
            IChecker checker = new PrimzahlChecker();

            //Act
            bool isPrimzahl = checker.Validate( "434" );

            //Assert
            Assert.False( isPrimzahl );
        }




    }
}
