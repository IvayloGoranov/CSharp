using SimpleHttpServer.Models;
using SimpleMVC.App.MVC.Interfaces.Security;
using System.Linq;

namespace SimpleMVC.App.MVC.Security
{

    public class SignInManager
    {
        private IDbIdentityContext dbContext;
        public SignInManager(IDbIdentityContext context)
        {
            this.dbContext = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            if (session == null)
            {
                return false;
            }
            var sess = dbContext.Logins.FirstOrDefault(s => s.SessionId == session.Id && s.IsActive == true);
            if (sess == null)
            {
                return false;
            }
            return true;
        }

        internal void Logout(HttpSession session)
        {
            var login = dbContext.Logins.FirstOrDefault(s => s.SessionId == session.Id && s.IsActive == true);
            login.IsActive = false;
            dbContext.SaveChanges();
        }
    }


}
