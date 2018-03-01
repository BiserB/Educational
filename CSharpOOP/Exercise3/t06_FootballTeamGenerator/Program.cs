using System;
using System.Linq;
using System.Collections.Generic;
using t06_FootballTeamGenerator.Models;

namespace t06_FootballTeamGenerator
{
    internal class Program
    {
        private static List<Team> teams = new List<Team>();
        
        static void Main()
        {
            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] data = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    string command = data[0];
                    string teamName = data[1];
                    Team currentTeam = teams.FirstOrDefault(t => t.Name == teamName);
                    Action<string> check = (team) => { if (currentTeam == null) { throw new ArgumentException($"Team {teamName} does not exist."); }; };
                    if (command == "Team")
                    {
                        teams.Add(new Team(teamName));
                    }
                    else if (command == "Add")
                    {
                        check(teamName);
                        string name = data[2];
                        int endurance = int.Parse(data[3]);
                        int sprint = int.Parse(data[4]);
                        int dribble = int.Parse(data[5]);
                        int passing = int.Parse(data[6]);
                        int shooting = int.Parse(data[7]);
                        Player player = new Player(name, endurance, sprint, dribble, passing, shooting);
                        currentTeam.AddPlayer(player);                        
                    }
                    else if (command == "Remove")
                    {
                        string playerName = data[2];
                        currentTeam.RemovePlayer(playerName);                                          
                    }
                    else if (command == "Rating")
                    {
                        check(teamName);
                        Console.WriteLine($"{teamName} - {currentTeam.Rating():f0}");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
