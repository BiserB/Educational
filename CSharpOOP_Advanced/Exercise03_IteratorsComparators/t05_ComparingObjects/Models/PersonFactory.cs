
using System;

public class PersonFactory
{
    public Person Create(string name, int age, string town)
    {
        return new Person(name, age, town);
    }
}
