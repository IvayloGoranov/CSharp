using System.Linq;
using AutoMapper;
using CarDealer.Models.BindingModels.Users;
using CarDealer.Models.EntityModels;

namespace CarDealer.Services
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
                this.Context.Logins.Add(new Login() { SessionId = sessionSessionId });
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
    }
}
