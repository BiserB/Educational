using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Family
{
    private List<Person> persons;

    public List<Person> Persons
    {
        get { return this.persons; }
        set { this.persons = value; }
    }

    public Family()
    {
        this.Persons = new List<Person>();
    }

    public void AddMember(Person member)
    {
        Persons.Add(member);
    }

    public Person GetOldestMember()
    {
        int max = this.Persons.Select(p => p.Age).ToList().Max();
        return this.Persons.FirstOrDefault(p => p.Age == max);
    }        


}
