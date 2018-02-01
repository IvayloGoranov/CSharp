using System;

namespace Login
{
    class Login
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type:text/html\r\n\r\n");
            Console.WriteLine("<form action=\"Login.exe\" method=\"post\">");
            Console.WriteLine("Username: <input type=\"text\" name=\"username\"/></br>");
            Console.WriteLine("Password: <input type=\"password\" name=\"password\"/></br>");
            Console.WriteLine("<input type=\"submit\"value=\"Log in\"/>");
            Console.WriteLine("</form>");

            string post = Console.ReadLine();
            if (post != null)
            {
                string[] paramPairs = post.Split(new char[] { '&', '=' }, StringSplitOptions.RemoveEmptyEntries);
                string username = paramPairs[1];
                string password = paramPairs[3];
                Console.WriteLine($"Hi {username}, your password is {password}");
            }
        }
    }
}
