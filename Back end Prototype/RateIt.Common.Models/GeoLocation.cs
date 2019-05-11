using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class GeoLocation
    {
        public string City { get; set; }
        public string CountryShort { get; set; }
        public string CountryLong { get; set; }
        public string ZipCode { get; set; }
        public string DomainName { get; set; }
        public string InternetServiceProvider { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
