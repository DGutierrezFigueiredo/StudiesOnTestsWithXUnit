using StudiesOnTestsWithXUnit;
using System;
using Xunit;

namespace BasicTests.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Sum_SumOfTwoNumbers_ShouldBeRight()
        {
            //Arrange
            SimpleCalculator simpleCalculator = new SimpleCalculator();
            decimal result;

            //Act
            result = simpleCalculator.Sum((decimal)5000.25, (decimal)5000.23);

            //Assert
            Assert.Equal((decimal)10000.48, result, 2);

        }

        [Fact]
        public void Divide_DivisionOfTwoNumbers_ShouldBeRight()
        {
            //Arrange
            SimpleCalculator simpleCalculator = new SimpleCalculator();
            decimal result;

            //Act
            result = simpleCalculator.Divide((decimal)5000, (decimal)1300);

            //Assert
            Assert.Equal((decimal)3.85, result, 2);

        }
        [Fact]
        public void Divide_DivisionByZero_ShouldThrowException()
        {
            //Arrange
            SimpleCalculator simpleCalculator = new SimpleCalculator();


            //Act
            Action act = () => simpleCalculator.Divide((decimal)5000, (decimal)0);

            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Cannot divide by Zero", exception.Message);
        }
    }
}
