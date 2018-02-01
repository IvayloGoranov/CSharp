using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomappingLive.DTO
{
    using System.Reflection;
    using System.Security.AccessControl;

    public class BookDto
    {

        public string Title { get; set; }

        public int[] Authors { get; set; }
    }
}
