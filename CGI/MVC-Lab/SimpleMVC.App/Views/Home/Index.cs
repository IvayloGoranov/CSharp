using SimpleMVC.App.MVC.Interfaces;
using System.Text;

namespace SimpleMVC.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h3>NotesApp</h3>");
            sb.AppendLine($"<a href=\"/users/all\">All Users</a>");
            sb.AppendLine($"<a href=\"/users/register\">Register Users</a>");

            return sb.ToString();
        }
    }
}
