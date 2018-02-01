using P3MessageSharing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3MessageSharing.Engine.Commands
{
    public abstract class Command
    {
        protected Command(IAppEngine appEngine)
        {
            this.AppEngine = appEngine;
        }

        public IAppEngine AppEngine { get; set; }

        public abstract void Execute(string[] commandArgs);
    }
}
