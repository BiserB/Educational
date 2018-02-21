using System;
using System.Data.SqlClient;

namespace Task04
{
    public class Program
    {
        static void Main(string[] args)
        {

            string param = "Server = V310LENOVO; " +
                           "DATABASE = Minions; " +
                           "Integrated security = True;";
            var conn = new SqlConnection(param);
            conn.Open();
            using (conn)
            {
                string[] minionData = Console.ReadLine().Split(' ');
                string[] villainData = Console.ReadLine().Split(' ');
                string name = minionData[1];
                int age = int.Parse(minionData[2]);
                string town = minionData[3];
                string villain = villainData[1];


                string query1 = "SELECT COUNT(*) FROM Towns WHERE Name = " + name;              
                SqlCommand comm1 = new SqlCommand(query1, conn);
                string result1 = (string)comm1.ExecuteScalar();
                if (result1 == null) 
                {
                    string query2 = $"INSERT INTO Towns(Name) VALUES ({name})";
                    Console.WriteLine("Inserted");
                }

            }
        }
    }
}
