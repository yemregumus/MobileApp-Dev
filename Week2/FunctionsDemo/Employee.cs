using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsDemo
{
    // definition of a custom data type (class) called Employee
    public class Employee
    {
        // field (attributes)
        public string Name { get; set; }
        public string Email { get; set; }
        public int YearHired { get; set; } = 2015;

        // initializer (constructor)
        public Employee(string name)
        {
            this.Name = name;
            this.Email = $"{this.Name}@mycompany.com";
        }
        public Employee(string name, string email, int yearHired)
        {
            this.Name = name;
            this.Email = email;
            this.YearHired = yearHired;
        }

        // methods (behaviour)
        public void showEmployeeDetails()
        {
            Console.WriteLine("|------------------------------|");
            Console.WriteLine($"| EMPLOYEE NAME: {this.Name}");
            Console.WriteLine($"| EMPLOYEE EMAIL: {this.Email}");
            Console.WriteLine($"| EMPLOYEE SINCE: {this.YearHired}");
            Console.WriteLine("|------------------------------|");
        }

        // method that returns a value
        public int getNumYearsWorked()
        {
            // 1. Get the current year
            DateTime today = DateTime.Now;
            int currYear = today.Year;

            // 2. error handling
            // check if the dateHired is in the future or before 1980 (company est. year)
            if (currYear > this.YearHired && this.YearHired >= 1980)
            {
                // 3. Difference between the current year and the hired year
                int yearsWorked = currYear - this.YearHired;

                // 4. Return the difference
                return yearsWorked;
            }

            return -1;
        }

       
    }
}
