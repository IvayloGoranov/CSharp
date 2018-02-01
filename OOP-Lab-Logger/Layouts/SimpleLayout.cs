using Logger.Interfaces;
using System;

namespace Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format(string msg, ReportLevel level, DateTime date)
        {
            string output = string.Format("{0} - {1} - {2}{3}", date, level, msg, Environment.NewLine);
            
            return output;
        }
    }
}
