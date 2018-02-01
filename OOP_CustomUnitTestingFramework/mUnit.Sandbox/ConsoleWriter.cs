using System;

namespace mUnit.Sandbox
{
    using Core.Interfaces;

    public class ConsoleWriter : IOutputWriter
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}
