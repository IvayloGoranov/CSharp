using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BrowseCakes
{
    class BrowseCakes
    {
        static void Main()
        {
            Console.WriteLine("Content-type:text/html\r\n\r\n");
            Console.WriteLine("<a href=\"ByTheCake.exe\">Back to home</a></br></br>");
            Console.WriteLine("<form action=\"BrowseCakes.exe\" method=\"get\">");
            Console.WriteLine("<input type=\"text\" name=\"name\"/>");
            Console.WriteLine("<input type=\"submit\"value=\"Search\"/>");
            Console.WriteLine("</form>");

            var request = Environment.GetEnvironmentVariable("QUERY_STRING");
            if (request != null)
            {
                var tokens = request.Split('=');
                var keyword = tokens[1].ToLower();
                var cakes = new List<Cake>();
                using (var reader = new StreamReader("database.csv"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] cakeInfo = line.Split(',');
                        string name = cakeInfo[0];
                        double price = double.Parse(cakeInfo[1]);
                        var cake = new Cake()
                        {
                            Name = name,
                            Price = price
                        };
                        cakes.Add(cake);
                    }
                }
                var filteredCakes = cakes.Where(c => c.Name.ToLower().Contains(keyword));
                foreach (var cake in filteredCakes)
                {
                    Console.WriteLine($"{cake.Name} ${cake.Price} </br>");
                }
            }
        }
    }
}
