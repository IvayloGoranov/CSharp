using System;
using System.Data.SqlClient;

namespace SimpleInsertion
{
    public class SimpleInsertion
    {
        public static void Main()
        {
            string connectionString = "Server=.; Database=MinionsDB; Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            //using (connection)
            //{
            //    string creationCommandString = "INSERT INTO JudgeFails VALUES " +
            //                                   "('Judge RIP', 300), " +
            //                                   "('Judge Reborn', 200)";
            //    SqlCommand createCommand = new SqlCommand(creationCommandString, connection);
            //    Console.WriteLine(createCommand.ExecuteNonQuery());
            //}
        }
    }
}
