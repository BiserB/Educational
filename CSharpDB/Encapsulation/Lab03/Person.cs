using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    public class Person
    {
        private const int minNameLength = 3;
        private const double minSalary = 460;

        private string firstName;
        private string secondName;
        public int age;
        private double salary;
        public string FirstName
        {
            get
            {
                return this.FirstName ; 
            }
            set
            {
                if (value.Length < minNameLength)
                {
                    throw new SystemException("First name cannot be less than 3 symbols");
                }
                this.firstName = value;
            }
        }
        public string SecondName
        {
            get { return this.secondName; }
            set
            {
                if (value.Length < minNameLength)
                {
                    throw new SystemException("First name cannot be less than 3 symbols");
                }
                this.secondName = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new SystemException("Age can not be negative");
                }
                this.age = value;
            }
        }
        public double Salary
        {
            get { return this.salary; }
            set
            {
                if (value < minSalary)
                {
                    throw new SystemException($"Salary cannot be less then {minSalary}");
                }
                this.salary = value;
            }
        }

        public Person(string firstName, string secondName, int age, double salary)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
            this.Salary = salary;
        }

        public void increaseSalary(double percent)
        {            
            if (this.Age > 30)
            {
                this.Salary += this.Salary * percent / 100;
            }
            else
            {
                this.Salary += this.Salary * percent / 200;
            }  
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.SecondName} get {this.Salary} leva";
        }
    }
}
