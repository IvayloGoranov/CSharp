using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Views.Users
{
    class Greet : IRenderable<GreetViewModel>
    {
        public GreetViewModel Model { get; set; }

        public string Render()
        {
            return "Hello user with session id: " + Model.SessionId;
        }
    }
}
