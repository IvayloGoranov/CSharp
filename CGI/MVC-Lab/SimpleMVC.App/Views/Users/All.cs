using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;
using System.Text;

namespace SimpleMVC.App.Views.Users
{
    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"/home/index\"> &lt; Home</a><h3>All users</h3>");
            sb.AppendLine("<ul>");
            //foreach (var username in Model.Usernames)
            //{
            //    sb.AppendLine($"<li><a href=\"#\">{username}</a></li>");
            //}
            sb.AppendLine("<ul>");

            return sb.ToString();
        }
    }
}
