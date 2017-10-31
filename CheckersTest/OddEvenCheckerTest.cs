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
        public void TheStringIsOnlyNumbers_ReturnTrue()
        {
            Checkers.IChecker checker = new Checkers.OddEvenChecker();

            bool isOnlyNumbersAndEven = checker.Validate( "123456" );

            Assert.True( isOnlyNumbersAndEven );
        }

        [Fact]
        public void TheStringIsOnlyNumbersAndOdd_ReturnFalse()
        {
            Checkers.IChecker checker = new Checkers.OddEvenChecker();

            bool isOnlyNumbersAndOdd = checker.Validate( "1234567" );

            Assert.False( isOnlyNumbersAndOdd );
        }

        [Fact]
        public void TheStringIsEven_ReturnTrue()
        {
            Checkers.IChecker checker = new Checkers.OddEvenChecker();

            bool isEven = checker.Validate( "100" );

            Assert.True( isEven );
        }

        [Fact]
        public void TheStringIsOdd_ReturnFalse()
        {
            Checkers.IChecker checker = new Checkers.OddEvenChecker();

            bool isOdd = checker.Validate( "99" );

            Assert.False( isOdd );
        }

        [Fact]
        public void TheStringIsNotOnlyNumbers_ReturnTrue()
        {
            Checkers.IChecker checker = new Checkers.OddEvenChecker();

            bool isOnlyNumbers = checker.Validate( "12ab34cd" );

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
