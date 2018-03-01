using System.Collections.Generic;

internal class Person
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string Date { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public Person(int number, string name, string date)
    {
        this.Number = number;
        this.Name = name;
        this.Date = date;
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }
}