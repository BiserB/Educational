using System;
using System.Collections.Generic;
using System.Text;


public class Employee
{    
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public Employee(string name, decimal salary, string position, string department)
        : this(name, salary, position, department, "n/a", -1)
    {
    }

    public Employee(string name, decimal salary, string position, string department, string email)
       : this(name, salary, position, department, email, -1)
    {
    }

    public Employee(string name, decimal salary, string position, string department, int age)
       : this(name, salary, position, department, "n/a", age)
    {
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

    public override string ToString()
    {
        return $"{this.Name} {this.Salary} {this.Email} {this.Age}";
    }
}
