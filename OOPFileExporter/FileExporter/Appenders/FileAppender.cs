using Exporter.Interfaces;
using System;

namespace Exporter.Appenders
{
    public abstract class FileAppender : IFileAppender
    {
        private ILayout layout;
        private string filePath;

        public FileAppender(string filePath, ILayout layout)
        {
            this.FilePath = filePath;
            this.Layout = layout;
        }

        public ILayout Layout
        {
            get
            {
                return this.layout;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Layout cannot be null");
                }

                this.layout = value;
            }
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

        public abstract void Append(object obj);
    }
}
