using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
