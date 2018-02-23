using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Player
{
    private string name;
    private Stat statistics;

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
    public Stat Statistics
    {
        get { return this.statistics; }
        private set { this.statistics = value; }
    }

    public Player(string name, Stat statistics)
    {
        this.Name = name;
        this.Statistics = statistics;
    }
    
}
