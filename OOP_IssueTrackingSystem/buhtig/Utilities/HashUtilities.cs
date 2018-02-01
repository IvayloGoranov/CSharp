using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Buhtig.Utilities
{
    public static class HashUtilities
    {
        public static string HashPassword(string password)
        {
            byte[] bytes = Encoding.Default.GetBytes(password);
            var sha1 = SHA1.Create();
            byte[] hashedBytes = sha1.ComputeHash(bytes);

            string result = string.Join(string.Empty, hashedBytes.Select(x => x.ToString()));

            return result;
        }
    }
}
