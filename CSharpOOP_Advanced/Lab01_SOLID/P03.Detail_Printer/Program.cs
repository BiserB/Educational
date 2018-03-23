using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee e1 = new Employee("Pesho");
            Employee e2 = new Employee("Gosho");
            Employee e3 = new Employee("Sharo");
            List<string> docs = new List<string> { "Personal", "Salaries" };
            Manager m = new Manager("Boss", docs);

            List<Employee> department = new List<Employee> { e1, e2, e3, m };

            DetailsPrinter pr = new DetailsPrinter(department);

            pr.PrintDetails();

        }
    }
}
