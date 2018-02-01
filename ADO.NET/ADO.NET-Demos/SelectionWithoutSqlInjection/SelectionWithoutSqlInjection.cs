﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionWithoutSqlInjection
{
    public class SelectionWithoutSqlInjection
    {
        public static void Main()
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

        static void Selecting(string name, SqlConnection connection)
        {
            string selectionCommandString = "SELECT * FROM Employees WHERE FirstName = @name";
            SqlCommand command = new SqlCommand(selectionCommandString, connection);
            SqlParameter parameter = new SqlParameter("@name", SqlDbType.VarChar, 50) { Value = name };
            command.Parameters.Add(parameter);
            //OR Another way to add the parameter is 
            //command.Parameters.AddWithValue("@name", nameOfFail);
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
