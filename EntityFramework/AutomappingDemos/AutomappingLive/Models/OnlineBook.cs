using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomappingLive.Models
{
    using System.Security.AccessControl;

    public class OnlineBook : Book
    {
        public string Url { get; set; }
    }
}
