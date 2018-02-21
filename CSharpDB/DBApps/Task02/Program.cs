//using System;
//using System.Data.SqlClient;

//namespace Task02
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            SqlConnection conn = new SqlConnection(
//                "Server = V310LENOVO; DATABASE = Minions; Integrated security = true");
//            conn.Open();
//            using (conn)
//            {
//                var command = new SqlCommand(
//                    "SELECT V.Name, COUNT(MV.MinionId) AS Count " +
//                    "FROM Villains AS V " +
//                    "JOIN MinionsVillains AS MV " +
//                    "ON MV.VillainId = V.Id " +
//                    "GROUP BY V.Name	" +
//                    "ORDER BY Count DESC"
//                    , conn);

//                var villains = command.ExecuteReader();
//                while (villains.Read())
//                {
//                    string currentV = (string)villains["Name"];
//                    int currentM = (int)villains["Count"];
//                    Console.WriteLine($"{currentV} - {currentM}");
//                }
//            }
//        }
//    }
//}
