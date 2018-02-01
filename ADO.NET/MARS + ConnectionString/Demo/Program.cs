using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Demo
{

    class Program
    {
        static void Main()
        {
            string connectionString = Demo.Properties.Settings.Default.ConnectionString;
            //The connection string should be adjusted if needeed 
            SqlConnection connection = new SqlConnection(connectionString);

            string villinaSelection = "SELECT VillianId, Name FROM Villians";

            string minionToVillianSelection = "SELECT Name, Age " +
                                              "FROM Minions m " +
                                              "JOIN MinionsVillians mv " +
                                              "ON m.MinionId = mv.MinionId AND mv.VillianId = @villianID";

            using (connection)
            {
                connection.Open();

                SqlCommand villianSelectionCommand = new SqlCommand(villinaSelection, connection);
                SqlDataReader villiansReader = villianSelectionCommand.ExecuteReader();

                using (villiansReader)
                {
                    while (villiansReader.Read())
                    {
                        int villianId = (int)villiansReader["VillianId"];
                        string villianName = (string)villiansReader["Name"];
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(villianName + ":");

                        SqlCommand minionsSelection = new SqlCommand(minionToVillianSelection, connection);
                        minionsSelection.Parameters.AddWithValue(@"villianID", villianId);
                        SqlDataReader minionsReader = minionsSelection.ExecuteReader();

                        using (minionsReader)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            while (minionsReader.Read())
                            {
                                string minionName = (string)minionsReader["Name"];
                                int minionAge = (int)minionsReader["Age"];
                                Console.WriteLine($"    {minionName} - {minionAge}"); 
                            }
                        }
                    }
                }                                            
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

}
