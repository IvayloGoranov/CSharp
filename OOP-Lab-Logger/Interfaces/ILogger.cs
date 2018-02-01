using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    public interface ILogger
    {
        IEnumerable<IAppender> Appenders { get; }

        ReportLevel ReportLevel { get; set; }

        void Info(string msg);

        void Warn(string msg);

        void Error(string msg);

        void Critical(string msg);

        void Fatal(string msg);
    }
}
