using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class Program2
{
    static void Main(string[] args)
    {
        SqlConnection conn = new SqlConnection(
            "Server = V310LENOVO; DATABASE = Minions; Integrated security = true");
        conn.Open();
        using (conn)
        {
            var command = new SqlCommand(
                "SELECT V.Name, MV.MinionId " +
                "FROM Villains AS V " +
                "JOIN MinionsVillains AS MV " +
                "ON MV.VillainId = V.Id "                 
                , conn);

            var villains = command.ExecuteReader();

            var register = new List<Master>();

            while (villains.Read())
            {
                string currentV = (string)villains["Name"];
                int currentM = (int)villains["MinionId"];
                Master newMaster = new Master(currentV, currentM);
                register.Add(newMaster);
                //Console.WriteLine($"{currentV} - {currentM}");
            }

            var ordered = register.GroupBy(p => p.Name)
                                  .OrderByDescending(m => m.Count())
                                  .ToList();
            foreach (var m in ordered)
            {
                Console.Write($"{m.Key} - {m.Count()}");
                
                Console.WriteLine();
            }
        }
    }
}



