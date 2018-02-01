using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3MessageSharing.Persons;
using P3MessageSharing.Engine.Factories;

namespace P3MessageSharing.Interfaces
{
    public interface IAppEngine
    {
        PersonFactory PersonFactory { get; }

        IList<Person> Persons { get; }

        ICommandManager CommandManager { get; }

        bool IsRunning { get; set; }

        void Run();
    }
}
