using System;
using System.Collections.Generic;
using System.Linq;

using PizzaMore.Data;
using PizzaMore.Utility;

namespace YourSuggestions
{
    public class YourSuggestions
    {
        private static IDictionary<string, string> postParams;
        private static Session session;
        private static Header header = new Header();

        public static void Main()
        {
            var context = new PizzaMoreContext();

            string sessionId = WebUtil.GetSessionId();
            session = context.Sessions
                .FirstOrDefault(s => s.Id == sessionId);

            if (session == null)
            {
                header.Print();
                WebUtil.PageNotAllowed();
                return;
            }

            if (WebUtil.IsGet())
            {
                ShowPage(context);
            }
            else if (WebUtil.IsPost())
            {
                DeletePizza(context);
                ShowPage(context);
            }
        }

        private static void DeletePizza(PizzaMoreContext context)
        {
            postParams = WebUtil.RetrievePostParameters();
            var pizza = context.PizzaSuggestions.Find(int.Parse(postParams["pizzaId"]));
            context.PizzaSuggestions.Remove(pizza);
            context.SaveChanges();
        }

        private static void ShowPage(PizzaMoreContext context)
        {
            header.Print();
            WebUtil.PrintFileContent(GlobalConstants.YourSuggestionsTopPath);
            PrintListOfSuggestedItems(context);
            WebUtil.PrintFileContent(GlobalConstants.YourSuggestionsBottomPath);
        }

        private static void PrintListOfSuggestedItems(PizzaMoreContext context)
        {
            var suggestions = context.PizzaSuggestions.Where(p => p.OwnerId == session.UserId);
            Console.WriteLine("<ul>");
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine("<form method=\"POST\">");
                Console.WriteLine($"<li><a href=\"DetailsPizza.exe?pizzaid={suggestion.Id}\">{suggestion.Title}</a> <input type=\"hidden\" name=\"pizzaId\" value=\"{suggestion.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
                Console.WriteLine("</form>");
            }

            Console.WriteLine("</ul>");
        }
    }
}
