using P3MessageSharing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3MessageSharing.Persons;
using P3MessageSharing.Engine.Factories;

namespace P3MessageSharing.Engine
{
    public sealed class AppEngine : IAppEngine
    {
        public AppEngine(ICommandManager commandManager)
        {
            this.CommandManager = commandManager;
            this.PersonFactory = new PersonFactory();
            this.Persons = new List<Person>();
        }

        public PersonFactory PersonFactory { get; private set; }

        public IList<Person> Persons { get; private set; }

        public ICommandManager CommandManager { get; set; }

        public bool IsRunning { get; set; }

        public void Run()
        {
            this.IsRunning = true;
            this.CommandManager.Engine = this;
            this.CommandManager.SeedCommands();

            do
            {
                string command = Console.ReadLine();

                try
                {
                    this.CommandManager.ProcessCommand(command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (this.IsRunning);
        }
    }
}
