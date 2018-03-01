using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace t06_FootballTeamGenerator.Models
{
    internal class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            Players = new List<Player>();
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
        private List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public void AddPlayer(Player p)
        {
            players.Add(p);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = Players.FirstOrDefault(p => p.Name == playerName);
            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
            Players.Remove(player);
        }

        public decimal Rating()
        {
            decimal rating = 0;
            if (Players.Count > 0)
            {
                rating = (int)Math.Round(Players.Average(p => p.SkillLevel()));
            }            
            return rating;
        }

    }
}
