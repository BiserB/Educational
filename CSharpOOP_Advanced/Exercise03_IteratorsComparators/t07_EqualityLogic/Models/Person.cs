using System;
using System.Collections.Generic;
using System.Text;


public class Person : IComparable<Person>
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }    

    public string  Name
    {
        get { return name; }
        private set { name = value; }
    }   

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }   


    public int CompareTo(Person other)
    {
        int result = this.name.CompareTo(other.name);

        if (result == 0)
        {
            result = this.age.CompareTo(other.age);
        }        

        return result;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Person other = obj as Person;
        return this.CompareTo(other) == 0;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() + Age.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Name} {Age}"; 
    }
}
