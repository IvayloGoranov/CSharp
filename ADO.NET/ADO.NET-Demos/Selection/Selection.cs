using System;
using System.Data.SqlClient;

namespace Selection
{
    public class Selection
    {
        public static void Main()
        {
            string connectionString = "Server=.; Database=SoftUni; Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                string selectionCommandString = "SELECT * FROM Employees";
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
}
