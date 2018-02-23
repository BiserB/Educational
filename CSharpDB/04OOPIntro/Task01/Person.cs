using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }
    
    public int Age
    {
        get { return age; }
        protected set { age = value; }
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}
