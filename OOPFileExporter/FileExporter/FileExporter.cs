using Exporter.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Exporter
{
    public class FileExporter
    {
        private List<IFileAppender> appenders;

        public FileExporter(params IFileAppender[] appenders)
        {
            this.appenders = appenders.ToList();
        }

        public IEnumerable<IFileAppender> Appenders 
        {
            get
            {
                return this.appenders;
            }
        }

        public void AddAppender(IFileAppender appenderType)
        {
            var existingAppender = this.appenders.FirstOrDefault(a => a.GetType().Name == appenderType.GetType().Name);
            if (existingAppender != null)
            {
                throw new InvalidOperationException(
                    string.Format("The type of appender {0} is already being used by the File Exporter.", 
                    appenderType.GetType().Name));
            }

            this.appenders.Add(appenderType);
        }

        public void RemoveAppender(IFileAppender appender)
        {
            var existingAppender = this.appenders.FirstOrDefault(a => a.GetType().Name == appender.GetType().Name);
            if (existingAppender != null)
            {
                throw new InvalidOperationException(
                    string.Format("No appender of type {0} is currently in use by the File Exporter.", 
                    appender.GetType().Name));
            }

            this.appenders.Remove(existingAppender);
        }

        public void Export(object obj)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(obj);
            }
        }
    }
}
