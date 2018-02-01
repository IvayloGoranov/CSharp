using System;
using System.Collections.Generic;

using PizzaMore.Utility;
using PizzaMore.Data;

namespace DetailsPizza
{
    public class DetailsPizza
    {
        private static IDictionary<string, string> getParams;
        private static Header header = new Header();

        public static void Main()
        {
            getParams = WebUtil.RetrieveGetParameters();
            var context = new PizzaMoreContext();

            var pizza = context.PizzaSuggestions.Find(int.Parse(getParams["pizzaid"]));
            header.Print();

            Console.WriteLine("<!doctype html><html lang=\"en\"><head><meta charset=\"UTF-8\" /><title>PizzaMore - Details</title><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" /><link rel=\"stylesheet\" href=\"/pm/bootstrap/css/bootstrap.min.css\" /><link rel=\"stylesheet\" href=\"/pm/css/signin.css\" /></head><body><div class=\"container\">");
            Console.WriteLine("<div class=\"jumbotron\">");
            Console.WriteLine("<a class=\"btn btn-danger\" href=\"Menu.exe\">All Suggestions</a>");
            Console.WriteLine($"<h3>{pizza.Title}</h3>");
            Console.WriteLine($"<img src=\"{pizza.ImageUrl}\" width=\"300px\"/>");
            Console.WriteLine($"<p>{pizza.Recipe}</p>");
            Console.WriteLine($"<p>Up: {pizza.UpVotes}</p>");
            Console.WriteLine($"<p>Down: {pizza.DownVotes}</p>");
            Console.WriteLine("</div>");
            Console.WriteLine("</div><script src=\"/pm/jquery/jquery-3.1.1.js\"></script><script src=\"/pm/bootstrap/js/bootstrap.min.js\"></script></body></html>");
        }
    }
}
