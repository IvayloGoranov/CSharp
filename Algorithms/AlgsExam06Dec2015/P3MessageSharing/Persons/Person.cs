using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3MessageSharing.Persons
{
    public class Person
    {
        private string name;
        public Person(string name)
        {
            this.Name = name;
            this.HasReceivedMessage = false;
            this.HasSharedMessage = false;
            this.Connections = new List<Person>();
            this.ReceivedMessageAtStep = -1;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Person Name", "Name should not be empty!");
                }
                value = value.Trim();
                //if (value.Length < 2)
                //{
                //    throw new ArgumentException("Person Name", "Name should be at least two letters!");
                //}
                foreach (char letter in value)
                {
                    if (IsValidName(letter) == false)
                    {
                        throw new ArgumentException("Person Name", "Name should contain letters or numbers only!");
                    }
                }
                this.name = value;
            }
        }
        public IList<Person> Connections { get; private set; }
        public bool HasReceivedMessage { get; set; }
        public bool HasSharedMessage { get; set; }
        public int ReceivedMessageAtStep { get; set; }
        public void ShareMessage()
        {
            if (this.HasReceivedMessage == false || this.ReceivedMessageAtStep < 0)
            {
                throw new ArgumentException(string.Format("{0} should first receive the message before sharing it", this.Name));
            }
            //if (this.Connections.Count == 0)
            //{
            //    throw new ArgumentException(string.Format("{0} has no connections.", this.Name));
            //}
            if (this.Connections.Count > 0)
            {
                foreach (var connection in this.Connections)
                {
                    if (connection.HasReceivedMessage == false)
                    {
                        connection.HasReceivedMessage = true;
                        connection.ReceivedMessageAtStep = this.ReceivedMessageAtStep + 1;
                        this.HasSharedMessage = true;
                    }
                }
            }
        }
        static bool IsValidName(char letter)
        {
            bool isValidLetter = (char.IsLetter(letter)) || (char.IsNumber(letter));
            return isValidLetter;
        }
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }
    }
}
