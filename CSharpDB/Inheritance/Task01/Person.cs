using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person
{
    private string name;
    private int age;   

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }
            this.name = value;
        }
    }
    public int Age
    {
        get { return this.age; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            this.age = value;
        }
    }
    

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }


    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}
