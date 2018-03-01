using System.Collections.Generic;

internal class Person
{    
    public string Name { get; set; }
    public string Date { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public Person( string name, string date)
    {        
        this.Name = name;
        this.Date = date;
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Date}";
    }
}