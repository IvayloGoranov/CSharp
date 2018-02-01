using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3MessageSharing.Interfaces;

namespace P3MessageSharing.Engine.Commands
{
    public class AddConnectionsCommand : Command
    {
        public AddConnectionsCommand(IAppEngine appEngine)
            : base(appEngine)
        {
        }
        
        public override void Execute(string[] commandArgs)
        {
            for (int i = 1; i < commandArgs.Length; i++)
            {
                string currentConnection = commandArgs[i];
                string[] currentConnectionArgs = currentConnection.Split('-');
                string firstPersonName = currentConnectionArgs[0];
                string secondPersonName = currentConnectionArgs[1];
                var firstPerson = this.AppEngine.Persons.FirstOrDefault(person => person.Name == firstPersonName);
                var secondPerson = this.AppEngine.Persons.FirstOrDefault(person => person.Name == secondPersonName);
                if (firstPerson == null)
                {
                    throw new ArgumentNullException(string.Format("{0} does not exist in persons database", firstPerson));
                }
                if (secondPerson == null)
                {
                    throw new ArgumentNullException(string.Format("{0} does not exist in persons database", firstPerson));
                }
                if ((firstPerson.Connections.Any(person => person.Name == secondPerson.Name)) == false)
                {
                    firstPerson.Connections.Add(secondPerson);
                }
                if ((secondPerson.Connections.Any(person => person.Name == firstPerson.Name)) == false)
                {
                    secondPerson.Connections.Add(firstPerson);
                }
            }
        }
    }
}
