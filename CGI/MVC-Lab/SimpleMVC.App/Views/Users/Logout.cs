using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Views.Users
{
    public class Logout : IRenderable

    {
        public string Render()
        {
            return "logged out";
        }
    }
}
