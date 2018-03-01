using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IPopulation, ICreature, IBuyer
{
    private string id;
    private string name;
    private int age;
    private string birthdate;
    private int food;

    public Citizen(string id, string name, int age, string birthdate)
    {
        Id = id;
        Name = name;
        Age = age;
        Birthdate = birthdate;
        Food = 0;
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
    public string Birthdate
    {
        get { return birthdate; }
        set { birthdate = value; }
    }
    public int Food
    {
        get { return food; }
        set { food = value; }
    }

    public void BuyFood()
    {
        Food += 10;
    }
}
