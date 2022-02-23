using System;
using System.Collections.Generic;


namespace BasicTests.EmployeeScenario
{
    public class Employee : Person
    {
        public double Salary { get; private set; }
        public ProfessionalProficiency ProfessionalProficiency { get; private set; }
        public IList<string> Skills { get; private set; }

        public Employee(string name, double salary)
        {
            Name = string.IsNullOrEmpty(name) ? "Doe" : name;
            SetSalary(salary);
            SetSkills();
        }

        public void SetSalary(double salary)
        {
            if (salary < 500) throw new ArgumentException("Salary is below permitted value");

            Salary = salary;
            if (salary < 5000) ProfessionalProficiency = ProfessionalProficiency.Junior;
            else if (salary >= 5000 && salary < 8000) ProfessionalProficiency = ProfessionalProficiency.Middle;
            else if (salary >= 8000) ProfessionalProficiency = ProfessionalProficiency.Senior;
        }

        private void SetSkills()
        {
            List<string> basicSkills = new List<string>()
            {
                "Programming Logic",
                "OOP"
            };

            Skills = basicSkills;

            switch (ProfessionalProficiency)
            {
                case ProfessionalProficiency.Middle:
                    Skills.Add("Tests");
                    break;

                case ProfessionalProficiency.Senior:
                    Skills.Add("Tests");
                    Skills.Add("Microservices");
                    break;
            }
        }
    }
}
