using P3MessageSharing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3MessageSharing.Engine.Commands
{
    public class CreatePersonsCommand : Command
    {
        public CreatePersonsCommand(IAppEngine appEngine)
            : base(appEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            for (int i = 1; i < commandArgs.Length; i++)
            {
                string currentPersonName = commandArgs[i];
                var person = this.AppEngine.PersonFactory.CreatePerson(currentPersonName);
                this.AppEngine.Persons.Add(person);
            }
        }
    }
}
