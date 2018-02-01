using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Logger.Appenders;

namespace Logger
{
    public class Logger : ILogger
    {
        private List<IAppender> appenders;
        
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders.ToList();
            this.ReportLevel = ReportLevel.Info;
        }

        public ReportLevel ReportLevel { get; set; }
        
        public IEnumerable<IAppender> Appenders 
        {
            get
            {
                return this.appenders;
            }
        }

        public void Info(string msg)
        {
            this.Log(msg, ReportLevel.Info);
        }

        public void Warn(string msg)
        {
            this.Log(msg, ReportLevel.Warn);
        }

        public void Error(string msg)
        {
            this.Log(msg, ReportLevel.Error);
        }

        public void Critical(string msg)
        {
            this.Log(msg, ReportLevel.Critical);
        }

        public void Fatal(string msg)
        {
            this.Log(msg, ReportLevel.Fatal);
        }

        public void AddAppender(IAppender appenderType)
        {
            var existingAppender = this.appenders.FirstOrDefault(a => a.GetType().Name == appenderType.GetType().Name);
            if (existingAppender != null)
            {
                throw new InvalidOperationException(
                    string.Format("The type of appender {0} is already being used by the logger.", appenderType.GetType().Name));
            }

            this.appenders.Add(appenderType);
        }

        public void RemoveAppender(IAppender appender)
        {
            var existingAppender = this.appenders.FirstOrDefault(a => a.GetType().Name == appender.GetType().Name);
            if (existingAppender != null)
            {
                throw new InvalidOperationException(
                    string.Format("No appender of type {0} is currently in useby the logger.", appender.GetType().Name));
            }

            this.appenders.Remove(existingAppender);
        }

        private void Log(string msg, ReportLevel level)
        {
            var date = DateTime.Now;
            foreach (var appender in this.appenders)
            {
                if (level >= this.ReportLevel)
                {
                    appender.Append(msg, level, date);
                }
            }
        }
    }
}
