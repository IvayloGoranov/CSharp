using SimpleMVC.App.MVC.Interfaces;
using System.Text;

namespace SimpleMVC.App.Views.Users
{
    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"/home/index\"> &lt; Home</a><h3>Login</h3>");
            sb.AppendLine("<form action=\"login\" method=\"POST\"><br/>");
            sb.AppendLine("Username: <input type=\"text\" name=\"Username\"/><br/>");
            sb.AppendLine("Password: <input type=\"password\" name=\"Password\"/><br/>");
            sb.AppendLine("<input type=\"submit\" value=\"Log In\"/>");
            sb.AppendLine("</form><br/>");
            return sb.ToString();
        }
    }
}
