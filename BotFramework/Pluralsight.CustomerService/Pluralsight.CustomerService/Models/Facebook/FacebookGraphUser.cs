using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.CustomerService.Models.Facebook
{
    public class FacebookGraphUser
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string profile_pic { get; set; }
        public string locale { get; set; }
        public float? timezone { get; set; }
        public string gender { get; set; }
        public bool is_payment_enabled { get; set; }

        public FacebookGraphError error { get; set; }
    }
}
