
namespace PizzaMore.Utility
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            string hashedPassword = "SECRET" + password;

            return hashedPassword;
        }
    }
}
