using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class Person
    {
        private string firstName;
        private string secondName;
        private int age;        

        public Person(string firstName, string secondName, int age)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.age = age;
            
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string SecondName
        {
            get { return this.secondName; }
            set { this.secondName = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = Age; }
        }       

        public override string ToString()
        {
            return $"{this.firstName} {this.secondName} is a {this.age} years old";
        }
    }

}
