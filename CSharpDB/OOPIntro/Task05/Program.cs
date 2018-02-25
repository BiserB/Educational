using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static List<Team> teams = new List<Team>();
    static void Main(string[] args)
    {                   
            string input = Console.ReadLine();
            while (input != "END")
            {
            string[] data = input.Split(';');
            try
            {
                switch (data[0])
                {
                    case "Team":
                        AddTeam(data[1]);
                        break;
                    case "Add":
                        AddPlayer(data);
                        break;
                    case "Remove":
                        RemovePlayer(data);
                        break;
                    case "Rating":
                        Rating(data);
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

    public static void AddTeam(string teamName)
    {
        if (!teams.Any(t => t.Name == teamName))
        {
            teams.Add(new Team(teamName));
        }
    }
    public static void AddPlayer(string[] data)
    {
        Team team = teams.FirstOrDefault(t => t.Name == data[1]);
        if (team == null)
        {
            throw new ArgumentException($"Team {data[1]} does not exist.");
        }
        string playerName = data[2];
        int endurance = int.Parse(data[3]);
        int sprint = int.Parse(data[4]);
        int dribble = int.Parse(data[5]);
        int passing = int.Parse(data[6]);
        int shooting = int.Parse(data[7]);
        Stat playerStat = new Stat(endurance, sprint, dribble, passing, shooting);
        Player newPlayer = new Player(playerName, playerStat);
        team.AddPlayer(newPlayer);
    }
    public static void Rating(string[] data)
    {
        Team team = teams.FirstOrDefault(t => t.Name == data[1]);
        if (team == null)
        {
            throw new ArgumentException($"Team {data[1]} does not exist.");
        }

        Console.WriteLine($"{data[1]} - {team.Rating()}");
    }
    public static void RemovePlayer(string[] data)
    {
        Team team = teams.FirstOrDefault(t => t.Name == data[1]);
        string playerName = data[2];
        team.RemovePlayer(playerName);       
    }
}
