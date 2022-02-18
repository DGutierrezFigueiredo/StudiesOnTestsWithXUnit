using System;

namespace StudiesOnTestsWithXUnit
{
    public class SimpleCalculator
    {
        public decimal Sum(decimal number1, decimal number2)
        {
            return number1 + number2;
        }

        public decimal Divide(decimal number1, decimal number2)
        {
            if (number2 != 0) { return number1 / number2; }
            throw  new DivideByZeroException("Cannot divide by Zero");
        }
    }
}
