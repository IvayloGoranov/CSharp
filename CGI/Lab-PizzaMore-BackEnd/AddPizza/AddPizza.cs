using System.Collections.Generic;
using System.Linq;

using PizzaMore.Data;
using PizzaMore.Utility;

namespace AddPizza
{
    public class AddPizza
    {
        private static IDictionary<string, string> postParams;
        private static Header header = new Header();
        private static Session session;

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
                //Show form to add new pizza suggestion
                ShowPage();
            }
            else if (WebUtil.IsPost())
            {
                //add suggestion to the database
                postParams = WebUtil.RetrievePostParameters();
                var user = context.Users.Find(session.UserId);
                user.Suggestions.Add(new Pizza()
                {
                    Title = postParams["title"],
                    Recipe = postParams["recipe"],
                    ImageUrl = postParams["url"],
                    UpVotes = 0,
                    DownVotes = 0,
                    OwnerId = user.Id
                });
                context.SaveChanges();

                ShowPage();
            }
        }

        private static void ShowPage()
        {
            header.Print();
            WebUtil.PrintFileContent(GlobalConstants.AddPizzaPath);
        }
    }
}
