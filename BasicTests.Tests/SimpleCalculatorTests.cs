using StudiesOnTestsWithXUnit;
using System;
using Xunit;

namespace BasicTests.Tests
{
    public class SimpleCalculatorTests
    {
        [Fact]
        public void Sum_SumOfTwoNumbers_ShouldBeRightResult()
        {
            //Arrange
            SimpleCalculator simpleCalculator = new SimpleCalculator();
            decimal result;

            //Act
            result = simpleCalculator.Sum((decimal)5000.25, (decimal)5000.23);

            //Assert
            Assert.Equal((decimal)10000.48, result, 2);

        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(105, 100, 205)]
        [InlineData(5000.25, 5000.23, 10000.48)]
        [InlineData(-587, 20, -567)]
        public void Sum_SumOfTwoNumbers_ShouldBeRightResultUsingMultipleScenarios(decimal value1, decimal value2, decimal sumResult)
        {
            //Arrange
            SimpleCalculator simpleCalculator = new SimpleCalculator();
            decimal result;

            //Act
            result = simpleCalculator.Sum(value1, value2);

            //Assert
            Assert.Equal(sumResult, result, 2);
        }

        [Fact]
        public void Divide_DivisionOfTwoNumbers_ShouldBeRightResult()
        {
            //Arrange
            SimpleCalculator simpleCalculator = new SimpleCalculator();
            decimal result;

            //Act
            result = simpleCalculator.Divide((decimal)5000, (decimal)1300);

            //Assert
            Assert.Equal((decimal)3.85, result, 2);

        }

        [Theory]
        [InlineData(10, 5, 2)]
        [InlineData(13, 5, 2.6)]
        [InlineData(-8000, -300, 26.67)]
        [InlineData(500, -5, -100)]
        public void Divide_DivisionOfTwoNumbers_ShouldBeRightResultMultipleScenarios(decimal value1, decimal value2, decimal divisionResult)
        {
            //Arrange
            SimpleCalculator simpleCalculator = new SimpleCalculator();
            decimal result;

            //Act
            result = simpleCalculator.Divide(value1, value2);

            //Assert
            Assert.Equal(result, divisionResult, 2);
        }

        [Fact]
        public void Divide_DivisionByZero_ShouldThrowArgumentException()
        {
            //Arrange
            SimpleCalculator simpleCalculator = new SimpleCalculator();


            //Act
            Action act = () => simpleCalculator.Divide((decimal)5000, (decimal)0);

            //Assert
            DivideByZeroException exception = Assert.Throws<DivideByZeroException>(act);
            Assert.Equal("Cannot divide by Zero", exception.Message);
        }

        //Or

        [Fact]
        public void Divide_DivisionByZero_ShouldThrowArgumentException2()
        {
            //Arrange 
            SimpleCalculator simpleCalculator = new SimpleCalculator();


            //Act & Assert
            DivideByZeroException exception = Assert.Throws<DivideByZeroException>(() => simpleCalculator.Divide((decimal)5000, (decimal)0));                 
            Assert.Equal("Cannot divide by Zero", exception.Message);
        }
    }
}
