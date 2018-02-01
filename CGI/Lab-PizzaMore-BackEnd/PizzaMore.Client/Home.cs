using System.Collections.Generic;
using System.Linq;

using PizzaMore.Data;
using PizzaMore.Utility;

namespace Home
{
    public class Home
    {
        private static Header header = new Header();
        private static IDictionary<string, string> requestParameters;
        private static Session session;
        private static string language;

        static void Main()
        {
            var context = new PizzaMoreContext();

            header = new Header();
            AddDefaultLanguageCookie();

            if (WebUtil.IsGet())
            {
                requestParameters = WebUtil.RetrieveGetParameters();
                TryLogOut(context);
                language = WebUtil.GetCookies()["lang"].Value;
            }
            else if (WebUtil.IsPost())
            {
                requestParameters = WebUtil.RetrievePostParameters();
                header.AddCookie(new Cookie("lang", requestParameters["language"]));
                language = requestParameters["language"];
            }

            ShowPage();
        }

        private static void AddDefaultLanguageCookie()
        {
            if (!WebUtil.GetCookies().ContainsKey("lang"))
            {
                header.AddCookie(new Cookie("lang", "EN"));
                language = "EN";
                ShowPage();
            }
        }

        private static void ShowPage()
        {
            header.Print();
            if (language.Equals("DE"))
            {
                ServeHtmlDe();
            }
            else
            {
                ServeHtmlEn();
            }
        }

        private static void ServeHtmlDe()
        {
            WebUtil.PrintFileContent(GlobalConstants.HomeDEPath);
        }

        private static void ServeHtmlEn()
        {
            WebUtil.PrintFileContent(GlobalConstants.HomeENPath);
        }

        private static void TryLogOut(PizzaMoreContext context)
        {
            if (requestParameters.ContainsKey("logout"))
            {
                if (requestParameters["logout"] == "true")
                {
                    string sessionId = WebUtil.GetSessionId();
                    session = context.Sessions
                        .FirstOrDefault(s => s.Id == sessionId);
                    context.Sessions.Remove(session);
                    context.SaveChanges();
                }
            }
        }
    }
}
