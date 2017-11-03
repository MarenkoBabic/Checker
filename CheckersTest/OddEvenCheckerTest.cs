using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckersTest
{
    public class OddEvenCheckerTest
    {
        [Fact]
        public void OddEvenTheStringIsOnlyNumbers_ReturnTrue()
        {
            //Arrange
            Checkers.IChecker checker = new Checkers.OddEvenChecker();

            //Act
            bool isOnlyNumbersAndEven = checker.Validate( "1234567890" );

            //Assert
            Assert.True( isOnlyNumbersAndEven );
        }

        [Fact]
        public void OddEvenTheStringIsOnlyNumbersAndOdd_ReturnFalse()
        {
            //Arrange
            Checkers.IChecker checker = new Checkers.OddEvenChecker();

            //Act
            bool isOnlyNumbersAndOdd = checker.Validate( "1234567" );

            //Assert
            Assert.False( isOnlyNumbersAndOdd );
        }

        [Fact]
        public void OddEvenTheStringIsEven_ReturnTrue()
        {
            //Arrange
            Checkers.IChecker checker = new Checkers.OddEvenChecker();

            //Act
            bool isEven = checker.Validate( "100" );

            //Assert
            Assert.True( isEven );
        }

        [Fact]
        public void OddEvenTheStringIsOdd_ReturnFalse()
        {
            //Arrange
            Checkers.IChecker checker = new Checkers.OddEvenChecker();

            //Act
            bool isOdd = checker.Validate( "99" );

            //Assert
            Assert.False( isOdd );
        }

        [Fact]
        public void OddEvenTheStringIsNotOnlyNumbers_ReturnTrue()
        {
            //Arrange
            Checkers.IChecker checker = new Checkers.OddEvenChecker();

            //Act
            bool isOnlyNumbers = checker.Validate( "12ab34cd" );

            //Assert
            Assert.True( isOnlyNumbers );
        }

        [Fact]
        public void OddEvenTheStringIsNull_ReturnFalse()
        {
            //Arrange
            Checkers.IChecker checker = new Checkers.OddEvenChecker();

            //Act
            bool isNull = checker.Validate( null );

            //Assert
            Assert.False( isNull );
        }
    }
}
