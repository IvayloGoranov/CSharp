using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3MessageSharing.Interfaces;
using P3MessageSharing.Persons;

namespace P3MessageSharing.Engine.Commands
{
    public class StartMessageSharingCommand : Command
    {
        public StartMessageSharingCommand(IAppEngine appEngine)
            : base(appEngine)
        {
        }
        
        public override void Execute(string[] commandArgs)
        {
            Queue<Person> connectionNodes = new Queue<Person>();
            for (int i = 1; i < commandArgs.Length; i++)
            {
                string currentPersonSharingMessageName = commandArgs[i];
                var currentPerson = this.AppEngine.Persons.FirstOrDefault(person => person.Name == currentPersonSharingMessageName);
                currentPerson.HasReceivedMessage = true;
                currentPerson.ReceivedMessageAtStep = 0;
                connectionNodes.Enqueue(currentPerson);
            }

            while (connectionNodes.Count != 0)
            {
                var currentPerson = connectionNodes.Dequeue();
                foreach (var connection in currentPerson.Connections)
                {
                    if (connection.HasReceivedMessage == false)
                    {
                        connectionNodes.Enqueue(connection);
                    }
                }
                if (currentPerson.HasSharedMessage == false)
                {
                    currentPerson.ShareMessage();
                }
            }

            int personsTotalCount = this.AppEngine.Persons.Count;
            int personsReceivedMessageCount = 0;
            foreach (var person in this.AppEngine.Persons)
	        {
		        if (person.HasReceivedMessage)
	            {
		            personsReceivedMessageCount++;
	            }
	        }
            if (personsTotalCount == personsReceivedMessageCount)
            {
                int maxStep = this.AppEngine.Persons.
                    OrderByDescending(person => person.ReceivedMessageAtStep).
                    FirstOrDefault().ReceivedMessageAtStep;
                Console.WriteLine("All people reached in {0} steps", maxStep);
                var lastReachedPersons = this.AppEngine.Persons.
                    Where(person => person.ReceivedMessageAtStep == maxStep).
                    OrderBy(person => person.Name);
                Console.WriteLine("People at last step: {0}", string.Join(", ", lastReachedPersons));
            }
            else
            {
                var unreachedPersons = this.AppEngine.Persons.
                    Where(person => person.HasReceivedMessage == false).
                    OrderBy(person => person.Name);
                Console.WriteLine("Cannot reach: {0}", string.Join(", ", unreachedPersons));
            }
            this.AppEngine.IsRunning = false;
        }
    }
}
