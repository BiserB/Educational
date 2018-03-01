
using System.Collections.Generic;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public string Name { get; set; }
    public List<Person> FirstTeam { get;}
    public List<Person> ReserveTeam { get;}

    public Team(string name)
    {
        this.Name = name;
        this.FirstTeam = new List<Person>();
        this.ReserveTeam = new List<Person>();
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            FirstTeam.Add(person);
        }
        else
        {
            ReserveTeam.Add(person);
        }
    }
}
