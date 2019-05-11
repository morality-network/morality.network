using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace RateItWebApi
{
    public class MoralityAuthenticationIdentity : GenericIdentity
    {
        public MoralityAuthenticationIdentity(string name, string password)
            : base(name, "Basic")
        {
            this.Password = password;
        }

        /// <summary>
        /// Basic Auth Password for custom authentication
        /// </summary>
        public string Password { get; set; }
    }
}