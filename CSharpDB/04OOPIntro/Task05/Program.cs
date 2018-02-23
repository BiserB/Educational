using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main(string[] args)
    {
        
            Dictionary<string, List<Player>> teams = new Dictionary<string, List<Player>>();
            string input = Console.ReadLine();
            while (input != "END")
            {
            string[] data = input.Split(';');
            try
            {
                switch (data[0])
                {
                    case "Team":
                        AddTeam(data[1], teams);
                        break;
                    case "Add":
                        AddPlayer(data, teams);
                        break;
                    case "Remove":
                        RemovePlayer(data, teams);
                        break;
                    case "Rating":
                        Rating(data, teams);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }  
                input = Console.ReadLine();
            } 
    }

    public static void AddTeam(string team, Dictionary<string, List<Player>> teams)
    {
        if (!teams.ContainsKey(team))
        {
            teams[team] = new List<Player>();
        }
    }
    public static void AddPlayer(string[] data, Dictionary<string, List<Player>> teams)
    {
        string team = data[1];
        if (!teams.ContainsKey(team))
        {
            throw new ArgumentException("Team [team name] does not exist.");
        }
        string playerName = data[2];
        int endurance = int.Parse(data[3]);
        int sprint = int.Parse(data[4]);
        int dribble = int.Parse(data[5]);
        int passing = int.Parse(data[6]);
        int shooting = int.Parse(data[7]);
        Stat playerStat = new Stat(endurance, sprint, dribble, passing, shooting);
        Player newPlayer = new Player(playerName, playerStat);
        teams[team].Add(newPlayer);
    }
    public static void Rating(string[] data, Dictionary<string, List<Player>> teams)
    {
        string team = data[1];
        int rating = 0;
        if (teams[team].Count() > 0)
        {
            rating = (int)Math.Round((teams[team].Average(p => p.Statistics.Skill)));
        }        
        Console.WriteLine($"{team} - {rating}");
    }
    public static void RemovePlayer(string[] data, Dictionary<string, List<Player>> teams)
    {
        string team = data[1];
        string playerName = data[2];
        if (!teams.ContainsKey(team))
        {
            Console.WriteLine($"Team {team} does not exist.");
        }
        else
        {
            int count = teams[team].Count();
            int index = 0;
            bool toRemove = false;
            for (int i = 0; i < count; i++)
            {
                if (teams[team][i].Name == playerName)
                {
                    index = i;
                    toRemove = true;
                    break;
                }
            }
            if (toRemove)
            {
                teams[team].RemoveAt(index);
            }
            else
            {
                Console.WriteLine($"Player {playerName} is not in {team} team.");
            }
        }
    }
}
