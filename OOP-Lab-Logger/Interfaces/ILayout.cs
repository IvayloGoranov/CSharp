using System;

namespace Logger.Interfaces
{
    public interface ILayout
    {
        string Format(string msg, ReportLevel level, DateTime date);
    }
}
