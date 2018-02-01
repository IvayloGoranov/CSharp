using System;
using System.IO;

namespace AddCake
{
    using System.Runtime.InteropServices;

    class AddCake
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type:text/html\r\n\r\n");
            Console.WriteLine("<a href=\"ByTheCake.exe\">Back to home</a><br><br>");
            Console.WriteLine("<form action=\"AddCake.exe\" method=\"post\">");
            Console.WriteLine("Name: <input type=\"text\" name=\"name\"/>");
            Console.WriteLine("Price: <input type=\"text\" name=\"price\"/>");
            Console.WriteLine("<input type=\"submit\" value=\"Add Cake\"/>");
            Console.WriteLine("</form>");

            string input = Console.ReadLine();
            if (input != null)
            {

                string[] tokens = input.Split(new char[] { '&', '=' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[1].Replace("+", " ");
                double price = double.Parse(tokens[3]);
                var cake = new Cake()
                {
                    Name = name,
                    Price = price
                };

                //Add cake to database
                File.AppendAllText("database.csv", $"{cake.Name},{cake.Price}{Environment.NewLine}");
            }

        }
    }
}
