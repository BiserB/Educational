using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    public class Person
    {
        private string firstName;
        private string secondName;
        private int age;
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
    }
}
