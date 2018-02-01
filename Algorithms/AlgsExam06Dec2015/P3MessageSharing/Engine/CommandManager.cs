using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3MessageSharing.Interfaces;
using P3MessageSharing.Engine.Commands;

namespace P3MessageSharing.Engine
{
    public class CommandManager : ICommandManager
    {
        protected readonly Dictionary<string, Command> commandsByName;

        public CommandManager()
        {
            this.commandsByName = new Dictionary<string, Command>();
        }

        public IAppEngine Engine { get; set; }

        public void ProcessCommand(string input)
        {
            string commandString = input.Replace(" ", string.Empty); //Remove empty spaces from string.
            string[] commandArgs = commandString.Split(new char[] {':', ','}, StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandArgs[0];

            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(string.Format(
                    "Command {0} does not exist.", commandName));
            }

            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }

        public virtual void SeedCommands()
        {
            this.commandsByName["People"] = new CreatePersonsCommand(this.Engine);
            this.commandsByName["Connections"] = new AddConnectionsCommand(this.Engine);
            this.commandsByName["Start"] = new StartMessageSharingCommand(this.Engine);
        }
    }
}
