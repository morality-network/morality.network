using RateIt.Common.Models;
using RateIt.RequestResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Utilities
{
    public class LocationResolver
    {
        public static IPData FindLocationCodeIpInfo(string ip, string token)
        {
            if (!string.IsNullOrEmpty(ip))
            {
                var url = $"https://ipinfo.io/{ip}/geo?token={token}";
                var data = WebUtility.MakeWebCall<IPData>(url);
                return data;
            }
            return null;
        }

        public static GeoLocation FindLocationCode(string ip)
        {
            if (!string.IsNullOrEmpty(ip))
            {
                return RequestUtil.GetGeoLocation(ip);
            }
            return null;
        }
    }
}
