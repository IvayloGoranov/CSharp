using Logger.Interfaces;
using System;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }
        
        public override void Append(string message, ReportLevel level, DateTime date)
        {
            string output = this.Layout.Format(message, level, date);
            Console.WriteLine(output);
        }
    }
}
