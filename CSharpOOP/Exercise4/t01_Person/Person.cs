using System;

public class Person
{
    private readonly int MIN_LENGTH = 3;

    private string name;
    private int age;

    public virtual string Name
    {
        get { return this.name; }
        set
        {
            if (value.Length < MIN_LENGTH)
            {
                throw new ArgumentException($"Name's length should not be less than {MIN_LENGTH} symbols!");
            }
            this.name = value;
        }
    }
    public virtual int Age
    {
        get { return this.age; }
        set
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
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}


