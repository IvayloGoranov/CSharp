using System.IO;
using Logger.Interfaces;
using System;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        //private StreamWriter writer;
        private string filePath;

        public FileAppender(string filePath, ILayout layout)
            : base(layout)
        {
            this.FilePath = filePath;
            //this.writer = new StreamWriter(this.FilePath, true);
        }

        public string FilePath 
        {
            get
            {
                return this.filePath;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("File path cannot be empty.");
                }

                this.filePath = value;
            }
        }

        public override void Append(string message, ReportLevel level, DateTime date)
        {
            string output = this.Layout.Format(message, level, date);
            File.AppendAllText(this.FilePath, output);

            //StreamWriter writer = new StreamWriter(this.FilePath);
            //using (writer)
            //{
            //    writer.WriteLine(output);
            //}
        }
    }
}
