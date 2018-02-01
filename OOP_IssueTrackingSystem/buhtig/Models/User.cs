using System;
using Buhtig.Utilities;

namespace Buhtig.Models
{
    public class User
    {
        private string username;
        private string password;
        
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username 
        {
            get
            {
                return this.username;
            }
 
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The username cannot be empty.");
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The password cannot be empty.");
                }

                this.password = HashUtilities.HashPassword(value);
            }
        }
    }
}
