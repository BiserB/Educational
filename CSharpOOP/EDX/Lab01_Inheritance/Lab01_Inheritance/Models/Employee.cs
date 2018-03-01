using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01_Inheritance.Models
{
    public class Employee
    {
        // Creates integer variable called "employeeCount" and assigns value to 1
        private static int employeeCount = 1;

        // 3 private member variables: employeeName, employeeBaseSalary, and employeeId
        private string employeeName;
        private decimal employeeBaseSalary;
        private int employeeId;

        public Employee(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
            Id = employeeCount++;
        }

        // Public properties

        public string Name
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
        public decimal BaseSalary
        {
            get { return employeeBaseSalary; }
            set { employeeBaseSalary = value; }
        }
        public int Id
        {
            get { return employeeId; }
            set { employeeId = value; }
        }        

        // This method returns the employee's base salary
        public decimal getBaseSalary()
        {
            return this.BaseSalary;
        }

        // This method returns the employee's name
        public string getName()
        {
            return this.Name;
        }

        // This method returns the employee's ID
        public int getEmployeeID()
        {
            return this.Id;
        }

        // This method returns the employee's ID and Name
        public string toString()
        {
            return this.Id + " " + this.Name;
        }

        // This method returns the employee's ID and Name and confirms that the employee is in the system
        public virtual string employeeStatus()
        {
            return toString() + " is in the company's system";
        }
    }
}
