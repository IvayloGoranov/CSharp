using P3MessageSharing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3MessageSharing.Engine;

namespace P3MessageSharing
{
    class MessageSharingMain
    {
        static void Main()
        {
            ICommandManager commandManager = new CommandManager();
            IAppEngine engine = new AppEngine(commandManager);
            engine.Run();
        }
    }
}
