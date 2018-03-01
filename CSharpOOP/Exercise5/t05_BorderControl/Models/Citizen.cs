using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IPopulation
{
    private string id;
    private string name;
    private int age;

    public Citizen(string id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public override string ToString()
    {
        return $"{Name}--{Age}--{Id}";
    }
}
