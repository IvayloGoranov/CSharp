using System.Collections.Generic;

using PizzaMore.Data;
using PizzaMore.Utility;

namespace SignUp
{
    public class SignUp
    {
        public static IDictionary<string, string> requestParameters;
        public static Header header = new Header();

        public static void Main()
        {
            if (WebUtil.IsPost())
            {
                var context = new PizzaMoreContext();
                RegisterUser(context);
            }

            ShowPage();
        }

        private static void RegisterUser(PizzaMoreContext context)
        {
            requestParameters = WebUtil.RetrievePostParameters();
            var email = requestParameters["email"];
            var password = requestParameters["password"];
            var user = new User()
            {
                Email = email,
                Password = PasswordHasher.Hash(password)
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        private static void ShowPage()
        {
            header.Print();
            WebUtil.PrintFileContent(GlobalConstants.SigUpPath);
        }
    }
}
