using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class Notification
    {
        public string Action { get; set; }
        public string DateTimeFormatted { get; set; }
        public DateTime DateTimeAdded { get; set; }
    }
}
