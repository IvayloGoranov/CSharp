using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.Enitities;
using CameraBazaar.Models.ViewModels;

namespace CameraBazaar.Services
{
    public class UsersService : Service
    {
        public void RegisterUser(RegisterUserBm bind)
        {
            User model = Mapper.Map<RegisterUserBm, User>(bind);
            this.Context.Users.Add(model);
            this.Context.SaveChanges();
        }

        public void LoginUser(LoginUserBm bind, string sessionSessionId)
        {
            if (!this.Context.Logins.Any(login => login.SessionId == sessionSessionId))
            {
                this.Context.Logins.Add(new Login() { SessionId = sessionSessionId, LoginStamp = DateTime.Now});
                this.Context.SaveChanges();
            }

            Login mylogin = this.Context.Logins.FirstOrDefault(login => login.SessionId == sessionSessionId);
            mylogin.IsActive = true;
            User model =
                this.Context.Users.FirstOrDefault(
                    user => user.Username == bind.Username && user.Password == bind.Password);

            mylogin.User = model;               
            this.Context.SaveChanges();
        }

        public bool UserExists(LoginUserBm bind)
        {
            if (this.Context.Users.Any(user => user.Username == bind.Username && user.Password == bind.Password))
            {
                return true;
            }

            return false;
        }

        public ProfilePageVm GetProfilePage(string wantedUsername, string currentUsername)
        {
            User user = this.Context.Users.First(user1 => user1.Username == wantedUsername);
            if (user == null)
            {
                return null;
            }

            ProfilePageVm page = new ProfilePageVm();
            page.Username = wantedUsername;
            page.Email = user.Email;
            page.InStockCameras = user.Cameras.Count(camera => camera.Quantity > 0);
            page.OutOfStockCameras = user.Cameras.Count(camera => camera.Quantity == 0);
            page.Phone = user.Phone;
            page.Id = user.Id;
            if (currentUsername == wantedUsername)
            {
                page.Id = 0;
            }

            page.Cameras = Mapper.Map<IEnumerable<Camera>, IEnumerable<ShortCameraVm>>(user.Cameras);
            return page;
        }

        public EditUserVm GetEditUserVm(User user)
        {
            EditUserVm vm = new EditUserVm();
            User currentUser = this.Context.Users.Find(user.Id);
            vm.Email = currentUser.Email;
            vm.Phone = currentUser.Phone;

            return vm;
        }

        public void EditUser(EditUserBm bind, User user)
        {
            User currentUser = this.Context.Users.Find(user.Id);
            currentUser.Email = bind.Email;
            currentUser.Password = bind.Password;
            currentUser.Phone = bind.Phone;
            this.Context.SaveChanges();
        }
    }
}
