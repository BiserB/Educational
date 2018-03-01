using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main(string[] args)
    {
        var departments = new Dictionary<string, List<Employee>>();
        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string[] data = Console.ReadLine().Split(' ');

            string name = data[0];
            decimal salary = decimal.Parse(data[1]);
            string position = data[2];
            string department = data[3];
            if (!departments.ContainsKey(department))
            {
                departments.Add(department, new List<Employee>());
            }
            if (data.Length == 4)
            {
                var emp = new Employee(name, salary, position, department);
                departments[department].Add(emp);
            }
            if (data.Length == 6)
            {
                string email = data[4];
                int age = int.Parse(data[5]);
                var emp = new Employee(name, salary, position, department, email, age);
                departments[department].Add(emp);
            }
            if (data.Length == 5)
            {
                bool isAge = int.TryParse(data[4], out int age);
                if (isAge)
                {
                    var emp = new Employee(name, salary, position, department, age);
                    departments[department].Add(emp);
                }
                else
                {
                    string email = data[4];
                    var emp = new Employee(name, salary, position, department, email);
                    departments[department].Add(emp);
                }
            }
        }
        //------------------------------------------------------------------------
        string topDepartment = "";
        decimal topSalary = 0;
        foreach (var dep in departments)
        {
            decimal depSalary = dep.Value.Average(p => p.Salary);
            if (depSalary > topSalary)
            {
                topSalary = depSalary;
                topDepartment = dep.Key;
            }
        }
        Console.WriteLine($"Highest Average Salary: {topDepartment}");

        foreach (var emp in departments[topDepartment].OrderByDescending(p => p.Salary))
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
        }
    }
}

public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public Employee()
    {
        this.Email = "n/a";
        this.Age = -1;
    }

    public Employee(string name, decimal salary, string position, string department)
        : this()
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
    }

    public Employee(string name, decimal salary, string position, string department, string email, int age)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = email;
        this.Age = age;
    }

    public Employee(string name, decimal salary, string position, string department, string email)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = email;
        this.Age = -1;
    }

    public Employee(string name, decimal salary, string position, string department, int age)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = "n/a";
        this.Age = age;
    }
}
