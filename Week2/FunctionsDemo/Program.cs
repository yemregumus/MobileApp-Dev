using System;

namespace FunctionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");

            // call void function
            sum();


            sum2(3, 5);

            Console.WriteLine($"SUM3: {sum3()}");

            Console.WriteLine($"SUM4: {sum4(2, 3)}");*/

            Employee emp1 = new Employee("Alex");

            emp1.showEmployeeDetails();

            // Alex = 2015
            showNumberOfYears(emp1.Name, emp1.getNumYearsWorked());


            // update the values of emp1 - using a property
            emp1.Name = "Smith";
            emp1.Email = "smith@blah.com";
            emp1.YearHired = 1981;
            emp1.showEmployeeDetails();

            showNumberOfYears(emp1.Name, emp1.getNumYearsWorked());

            // another emp
            Employee emp2 = new Employee("Sara", "sara@mycompany.com", 1990);
            emp2.showEmployeeDetails();
            
        }
        /*
        // void functions
        // 1. no parameters
        static void sum()
        {
            int a = 5;
            int b = 10;
            int result = a + b;
            Console.WriteLine($"SUM:  The sum of {a} and {b} is {result}");
        }

        // 2. with parameters
        static void sum2(int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"SUM2:  The sum of {a} and {b} is {result}");
        }

        // value returning functions
        // 3. no parameters
        static int sum3()
        {
            int a = 5;
            int b = 10;
            int result = a + b;
            return result;
        }

        // 4. with parameters
        static int sum4(int a, int b)
        {
            int result = a + b;
            return result;
        }
    }*/
        static void showNumberOfYears(string name, int years)
        {
            if (years == -1)
            {
                Console.WriteLine("Something went wrong. Please check if you have the right hired year.");
            }
            else
            {
                Console.WriteLine($"{name} has been an employee for {years} years");
            }
        }
    }
}
