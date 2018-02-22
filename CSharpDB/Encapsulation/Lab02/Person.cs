using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Person
    {
        private string firstName;
        private string secondName;
        public int age;
        private double salary;
        public string FirstName
        {
            get;
            set;
        }
        public string SecondName
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public double Salary
        {
            get;
            set;
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
                this.Salary += this.Salary * percent / 100;
            }  
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.SecondName} get {this.Salary} leva";
        }
    }
}
