using System;
using System.Data.SqlClient;

namespace SelectionWithSqlInjection
{
    public class SelectionWithSqlInjection
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=.; Database=SoftUni; Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                Selecting("Guy", connection);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("First query passed");

                Console.ForegroundColor = ConsoleColor.White;
                Selecting("' OR 1=1 --", connection);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Second query passed");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Selecting(string name, SqlConnection connection)
        {
            string selectionCommandString = 
                string.Format("SELECT * FROM Employees WHERE FirstName = '{0}'", name);
            SqlCommand command = new SqlCommand(selectionCommandString, connection);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write("{0} ", reader[i]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
