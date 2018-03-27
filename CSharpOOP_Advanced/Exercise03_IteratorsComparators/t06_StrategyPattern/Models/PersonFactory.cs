
using System;

public class PersonFactory
{
    public Person Create(string name, int age)
    {
        return new Person(name, age);
    }
}
