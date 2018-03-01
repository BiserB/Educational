using System;
using System.Collections.Generic;
using System.Text;

namespace t06_FootballTeamGenerator.Models
{
    internal class Player
    {
        // endurance, sprint, dribble, passing and shooting.
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }  
        public int Endurance
        {
            get { return endurance; }
            private set { endurance = Check("Endurance", value); }
        } 
        public int Sprint
        {
            get { return sprint; }
            private set { sprint = Check("Sprint", value); }
        } 
        public int Dribble
        {
            get { return dribble; }
            private set { dribble = Check("Dribble", value); }
        } 
        public int Passing
        {
            get { return passing; }
            private set { passing = Check("Passing", value); }
        }
        public int Shooting
        {
            get { return shooting; }
            private set { shooting = Check("Shooting", value); }
        }

        public decimal SkillLevel()
        {
            return ((Endurance + Sprint + Dribble + Passing + Shooting) / 5m);
        }

        private int Check(string stat, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{stat} should be between 0 and 100.");
            }
            return value;
        }

    }
}
