using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Identity { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Profile_Picture_Url { get; set; }
        public System.DateTime Last_Login { get; set; }
        public bool Active { get; set; }
        public string Info { get; set; }
        public string Comments { get; set; }
        public string Current_App { get; set; }
    }
}
