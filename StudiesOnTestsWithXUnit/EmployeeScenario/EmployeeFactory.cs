

namespace BasicTests.EmployeeScenario
{
    public class EmployeeFactory
    {
        public static Employee CreateEmployee(string name, double salary)
        {
            return new Employee(name, salary);
        }
    }
}
