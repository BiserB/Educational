using System.Collections.Generic;

internal class Person
{
    public string Name { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Relative> Children { get; set; }
    public List<Relative> Parents { get; set; }

    public Person(string name)
    {
        this.Name = name;
        this.Company = null;
        this.Car = null;
        this.Pokemons = new List<Pokemon>();
        this.Children = new List<Relative>();
        this.Parents = new List<Relative>();
    }
}