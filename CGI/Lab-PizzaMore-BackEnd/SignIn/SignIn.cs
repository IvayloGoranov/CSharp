using System;
using System.Collections.Generic;
using System.Linq;

using PizzaMore.Utility;
using PizzaMore.Data;

namespace SignIn
{
    public class SignIn
    {
        private static IDictionary<string, string> requestParameters;
        private static Header Header = new Header();

        static void Main()
        {
            if (WebUtil.IsPost())
            {
                var context = new PizzaMoreContext();
                LogIn(context);
            }

            ShowPage();
        }

        private static void LogIn(PizzaMoreContext context)
        {
            requestParameters = WebUtil.RetrievePostParameters();
            string email = requestParameters["email"];
            string password = requestParameters["password"];
            string hashedPassword = PasswordHasher.Hash(requestParameters["password"]);
            var user = context.Users.SingleOrDefault(u => u.Email == email);
            if (hashedPassword == user.Password)
            {
                var session = new Session()
                {
                    Id = new Random().Next().ToString(),
                    User = user
                };

                if (user != null)
                {
                    Header.AddCookie(new Cookie("sid", session.Id));
                }

                context.Sessions.Add(session);
                context.SaveChanges();
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(GlobalConstants.SigInPath);
        }
    }
}
