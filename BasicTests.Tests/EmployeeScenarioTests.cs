
using BasicTests.EmployeeScenario;
using Xunit;

namespace BasicTests.Tests
{
    public class EmployeeScenarioTests
    {
        //Booleans

        [Fact]
        public void Employee_Name_EmployeeNameShouldNotBeNullOrEmpty()
        {
            //Arrange & Act
            Employee newEmployee = new Employee("", 4000);

            //Assert
            Assert.False(string.IsNullOrEmpty(newEmployee.Name));

        }

        [Fact]
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

        [Fact]
        public void Employee_Skills_ShouldNotHaveEmptySkills()
        {
            //Arrange & Act
            Employee newEmployee = EmployeeFactory.CreateEmployee("Sandro", 10000);

            //Assert
            Assert.All(newEmployee.Skills, skill => Assert.False(string.IsNullOrEmpty(skill)));

        }

        [Fact]
        public void Employee_JuniorEmployee_MustHaveBasicSkills()
        {
            //Arrange & Act
            Employee newEmployee = EmployeeFactory.CreateEmployee("Diego", 4000);

            //Assert
            Assert.Contains("OOP", newEmployee.Skills);
        }

        [Fact]
        public void Employee_JuniorEmployee_ShouldNotHaveAdvancedSkills()
        {
            //Arrange & Act
            Employee newEmployee = EmployeeFactory.CreateEmployee("Diego", 4000);

            //Assert
            Assert.DoesNotContain("Microservices", newEmployee.Skills);
        }

        [Fact]
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
    }
}
