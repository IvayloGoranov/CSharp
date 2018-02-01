using Logger.Interfaces;
using System;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        private ILayout layout;
        
        public Appender(ILayout layout)
        {
            if (layout == null)
            {
                throw new ArgumentNullException("Layout cannot be null.");
            }

            this.layout = layout;
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

        public abstract void Append(string message, ReportLevel level, DateTime date);

    }
}
