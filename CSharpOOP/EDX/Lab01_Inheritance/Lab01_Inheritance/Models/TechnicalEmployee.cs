using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01_Inheritance.Models
{
    public class TechnicalEmployee : Employee
    {
        // Calls upon base-class (Employee Class) constructor from within derived class (TechnicalEmployee Class)
        // Sets baseSalary to 75000 for all TechnicalEmployee objects
        public TechnicalEmployee(string name) : base(name, 75000)
        { }

        // Creates integer variable called "successfulCheckIns" and assigns value to 5
        public int successfulCheckIns = 5;

        // This method returns the toString() method - which is the employee's ID number and name 
        // - and prints the number of successful check ins the employee has had 
        public override string employeeStatus()
        {
            return this.toString() + " has " + this.successfulCheckIns + " successful check ins";
        }
    }
}
