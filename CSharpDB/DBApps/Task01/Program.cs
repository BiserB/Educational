using System;
using System.Data.SqlClient;

namespace Task01
{
    public class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection(
                "Server = V310LENOVO;" +
                "Database = master;" +
                "Integrated security = True;");
            connection.Open();
            using (connection)
            {
                var command = new SqlCommand("Create DATABASE Minions", connection);
                var affected = command.ExecuteNonQuery();
                Console.WriteLine("affected:" + affected);
            }
               
            var conn = new SqlConnection(
                 "Server = V310LENOVO;" +
                 "Database = Minions;" +
                 "Integrated security = True;");
            conn.Open();
            using (conn)
            {
              
                var command1 = new SqlCommand(
                    "CREATE TABLE Countries( Id INT Primary Key Identity, Name VARCHAR(30))", conn);
                command1.ExecuteNonQuery();
                var command2 = new SqlCommand(
                    "CREATE TABLE Towns( Id INT Primary Key Identity, Name VARCHAR(30) NOT NULL, CountryId INT REFERENCES Countries(Id))", conn);
                command2.ExecuteNonQuery();
                var command3 = new SqlCommand(
                    "CREATE TABLE Minions( Id INT Primary Key Identity, Name VARCHAR(30) NOT NULL,Age INT NOT NULL, TownId INT REFERENCES Towns(Id))", conn);
                command3.ExecuteNonQuery();
                var command4 = new SqlCommand(
                    "CREATE TABLE EvilnessFactor( Id INT Primary Key Identity, Name VARCHAR(30) NOT NULL)", conn);
                command4.ExecuteNonQuery();
                var command5 = new SqlCommand(
                    "CREATE TABLE Villains( Id INT Primary Key Identity, Name VARCHAR(30) NOT NULL, EvilnessFactorId INT REFERENCES EvilnessFactor(Id))", conn);
                command5.ExecuteNonQuery();
                var command6 = new SqlCommand(
                    "CREATE TABLE MinionsVillains( MinionId INT, VillainId INT,Primary Key(MinionId, VillainId),FOREIGN KEY (MinionId) REFERENCES Minions(Id),FOREIGN KEY (VillainId) REFERENCES Villains(Id) )", conn);
                command6.ExecuteNonQuery();
                
            }

        }
    }
}
