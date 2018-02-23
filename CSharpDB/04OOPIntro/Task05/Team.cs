using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Team
{
    private string name; 
    private List<Player> players;

    public List<Player> Players
    {
        get { return this.players; }
        private set { this.players = value; }
    }
    public string Name
    {
        get { return this.name; }
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }
    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }
    
    public void AddPlayer(string input)
    {

    }


}
