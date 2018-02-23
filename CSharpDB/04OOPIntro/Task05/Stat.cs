using System;


public class Stat
{   
    //endurance, sprint, dribble, passing and shooting
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;
    private int summary;

    public int Endurance
    {
        get { return this.endurance; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Endurance should be between 0 and 100.");
            }
            this.endurance = value;
        }
    }
    public int Sprint
    {
        get { return this.sprint; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Sprint should be between 0 and 100.");
            }
            this.sprint = value;
        }
    }    
    public int Dribble
    {
        get { return this.dribble; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Dribble should be between 0 and 100.");
            }
            this.dribble = value;
        }
    }
    public int Passing
    {
        get { return this.passing; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Passing should be between 0 and 100.");
            }
            this.passing = value;
        }
    }
    public int Shooting
    {
        get { return this.shooting; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Shooting should be between 0 and 100.");
            }
            this.shooting = value;
        }
    }
    public int Summary
    {
        get { return (int)Math.Round((this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0); }        
    }


    public Stat(int endurance, int sprint, int dribble, int passing,int shooting)
    {
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;        
    }

}
