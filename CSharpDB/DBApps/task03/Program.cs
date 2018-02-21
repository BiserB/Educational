using System;
using System.Data.SqlClient;

namespace task03
{
    public class Program
    {
        static void Main(string[] args)
        {
            string param = "Server = V310LENOVO; " +
                           "DATABASE = Minions;" +
                           "Integrated security = True;";
            SqlConnection conn = new SqlConnection(param);
            conn.Open();
            using (conn)
            {
                int ID = int.Parse(Console.ReadLine());
                string query1 = "SELECT [Name] FROM Villains WHERE Id = @ID" ;
                SqlCommand comm1 = new SqlCommand(query1, conn);
                comm1.Parameters.AddWithValue("@ID", ID);

                string result1 = (string)comm1.ExecuteScalar();
                if (result1 != null)
                {
                    Console.WriteLine("Villain: " + result1);

                    string query2 = "SELECT M.Name, M.Age " +
                                    "FROM Minions AS M " +
                                    "JOIN MinionsVillains AS MV " +
                                    "ON MV.MinionId = M.Id " +
                                    "JOIN Villains AS V " +
                                    "ON V.Id = MV.VillainId " +
                                    "WHERE V.Id = @ID";


                    SqlCommand comm2 = new SqlCommand(query2, conn);
                    comm2.Parameters.AddWithValue("@ID", ID);

                    var result = comm2.ExecuteReader();
                    int count = 1;
                    while (result.Read())
                    {
                        string output1 = (string)result["Name"];
                        int output2 = (int)result["Age"];
                        Console.Write($"{count}. {output1} {output2}");
                        Console.WriteLine();
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine($"No villain with ID {ID} exists in the database.");
                }
            }
        }
    }
}
