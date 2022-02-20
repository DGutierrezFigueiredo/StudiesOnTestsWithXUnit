
using BasicTests.EmployeeScenario;
using System;
using Xunit;

namespace BasicTests.Tests
{
    public class EmployeeScenarioTests
    {
        //Booleans

        [Fact(DisplayName = "Employee name shouldn't be empty - Bool")]
        [Trait("Category", "EmployeeScenario")]
        public void Employee_Name_EmployeeNameShouldNotBeNullOrEmpty()
        {
            //Arrange & Act
            Employee newEmployee = new Employee("", 4000);

            //Assert
            Assert.False(string.IsNullOrEmpty(newEmployee.Name));

        }

        [Fact(DisplayName = "Employee shouldn't have a nickname - Bool")]
        [Trait("Category", "EmployeeScenario")]
        public void Employee_Nickanme_ShouldNotHaveANickname()
        {
            //Arrange & Act
            Employee newEmployee = new Employee("Diego", 4000);

            //Assert
            Assert.Null(newEmployee.NickName);

            //Assert bool
            Assert.True(string.IsNullOrEmpty(newEmployee.NickName));
            Assert.False(newEmployee.NickName?.Length > 0);
        }

        //Collections

        [Fact(DisplayName = "Skills can't be empty - Collections")]
        [Trait("Category", "EmployeeScenario")]
        public void Employee_Skills_ShouldNotHaveEmptySkills()
        {
            //Arrange & Act
            Employee newEmployee = EmployeeFactory.CreateEmployee("Sandro", 10000);

            //Assert
            Assert.All(newEmployee.Skills, skill => Assert.False(string.IsNullOrEmpty(skill)));

        }

        [Fact(DisplayName = "Junior Must Have Basic Skills only - Collections")]
        [Trait("Category", "EmployeeScenario")]
        public void Employee_JuniorEmployee_MustHaveBasicSkills()
        {
            //Arrange & Act
            Employee newEmployee = EmployeeFactory.CreateEmployee("Diego", 4000);

            //Assert
            Assert.Contains("OOP", newEmployee.Skills);
        }

        [Fact(DisplayName = "Junior shouldn't have Advanced Skills - Collections")]
        [Trait("Category", "EmployeeScenario")]
        public void Employee_JuniorEmployee_ShouldNotHaveAdvancedSkills()
        {
            //Arrange & Act
            Employee newEmployee = EmployeeFactory.CreateEmployee("Diego", 4000);

            //Assert
            Assert.DoesNotContain("Microservices", newEmployee.Skills);
        }

        [Fact(DisplayName = "Senior should have ALL Skills - Collections")]
        [Trait("Category", "EmployeeScenario")]
        public void Employee_SeniorEmployee_ShoulHaveAllSkills()
        {
            //Arrange & Act
            Employee newEmployee = EmployeeFactory.CreateEmployee("Mila", 15000);

            string[] arrOfAllSkills = new string[]
            {
                "Programming Logic",
                "OOP",
                "Tests",
                "Microservices"
            };


            //Assert
            Assert.Equal(arrOfAllSkills, newEmployee.Skills);
        }
        [Fact(DisplayName = "Salary below forbidden valeu should throw exception - Exceptions")]
        [Trait("Category", "EmployeeScenario")]
        public void Employee_EmployeeSalary_ShouldThrowExceptionWhenBelowPermittedValue()
        {
            //Arrange & Act
            Action action = () => EmployeeFactory.CreateEmployee("Sue", 400);

            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(action);
            Assert.Equal("Salary is below permitted value", exception.Message);
        }

        //Or
        [Fact(DisplayName = "Salary below forbidden valeu should throw exception method 2 - Exceptions")]
        [Trait("Category", "EmployeeScenario")]
        public void Employee_EmployeeSalary_ShouldThrowExceptionWhenBelowPermittedValue2()
        {
            //Arrange & Act & Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(() => EmployeeFactory.CreateEmployee("Sue", 400));

            Assert.Equal("Salary is below permitted value", exception.Message);
        }

        //Object types
        [Fact(DisplayName = "Factory Created employee should be type Employee  - Object Types")]
        [Trait("Category", "EmployeeScenario")]
        public void EmployeeFactory_CreateEmployee_ShouldReturnEmployeeObject()
        {
            //Arrange & Act
            Employee newEmployee = EmployeeFactory.CreateEmployee("Diego", 4000);

            //Assert
            Assert.IsType<Employee>(newEmployee);
        }

        [Fact(DisplayName = "Factory Created employee should derive from Person  - Object Types")]
        [Trait("Category", "EmployeeScenario")]
        public void EmployeeFactory_CreateEmployee_ShouldReturnAPersonDerivedTypeObject()
        {
            //Arrange & Act
            Employee newEmployee = EmployeeFactory.CreateEmployee("Diego", 4000);

            //Assert
            Assert.IsAssignableFrom<Person>(newEmployee);
        }

        //Ranges
        [Theory(DisplayName = "Proficiency and salaries should be aligned as designed  - Ranges")]
        [Trait("Category", "EmployeeScenario")]
        [InlineData(500)]
        [InlineData(700)]
        [InlineData(4500)]
        [InlineData(5001)]
        [InlineData(18000)]
        public void Employee_SalaryRange_ProfessionalProficiencyShouldSatisfySalaryRanges(double salary)
        {
            //Arrange & Act
            Employee newEmployee = new Employee("Diego", salary);

            //Assert
            if (newEmployee.ProfessionalProficiency == ProfessionalProficiency.Junior)
            {
                Assert.InRange(newEmployee.Salary, 500, 5000);
            }
            if (newEmployee.ProfessionalProficiency == ProfessionalProficiency.Middle)
            {
                Assert.InRange(newEmployee.Salary, 5001, 8000);
            }
            if (newEmployee.ProfessionalProficiency == ProfessionalProficiency.Senior)
            {
                Assert.InRange(newEmployee.Salary, 8001, double.MaxValue);
            }

            Assert.NotInRange(newEmployee.Salary, double.MinValue, 499);
        }
    }
}
