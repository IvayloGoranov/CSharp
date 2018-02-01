using System.Collections.Generic;

namespace Fruits.Web.IdentityData.DbContextExtensions
{
    public static class Roles
    {
        private static readonly string[] roles = { "FruitAdmin", "FruitClient" };

        public static string Admin
        {
            get
            {
                return roles[0];
            }
        }

        public static string Client
        {
            get
            {
                return roles[1];
            }
        }

        public static IEnumerable<string> All
        {
            get
            {
                return roles;
            }
        }
    }
}
