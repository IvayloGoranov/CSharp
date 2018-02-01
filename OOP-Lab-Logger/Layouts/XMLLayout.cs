using Logger.Interfaces;
using System;
using System.Text;

namespace Logger.Layouts
{
    public class XMLLayout : ILayout
    {
        public string Format(string msg, ReportLevel level, DateTime date)
        {
            var output = new StringBuilder();
            output.AppendFormat("<log>" + Environment.NewLine);
            output.AppendFormat("<date>" + date + "</date>" + Environment.NewLine);
            output.AppendFormat("<level>" + level + "</level>" + Environment.NewLine);
            output.AppendFormat("<message>" + msg + "</message>" + Environment.NewLine);
            output.AppendFormat("</log>");

            return output.ToString();
        }
    }
}
