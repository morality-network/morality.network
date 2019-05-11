using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace RateIt.Utilities
{
    public class StringUtility
    {
        private static Random random = new Random();

        public static string RandomString(int length, bool includeSpecial=true)
        {
            var lower = "abcdefghijklmnopqrstuvwxyz";
            var upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var num = "0123456789";
            var special = "!£$+=";
            string chars = lower + upper + num + (includeSpecial? special : upper);
            var str = new string(Enumerable.Repeat(chars, length - 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            str += new string(Enumerable.Repeat(lower, 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            str += new string(Enumerable.Repeat(upper, 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            str += new string(Enumerable.Repeat(num, 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            if (includeSpecial)
            {
                str += new string(Enumerable.Repeat(special, 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            else
            {
                str += new string(Enumerable.Repeat(upper, 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            }          
            return str;
        }

        public static string GetStringSha256Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        public static string EnsureAddressHas0X(string rawAddress)
        {
            if (rawAddress.StartsWith("0x") || rawAddress.StartsWith("0X")) return rawAddress;
            else return $"0x{rawAddress}";
        }

        public static string GetEmail(string fileName)
        {
            string path = HostingEnvironment.MapPath("~/Email-Templates/");
            var virtualFolder = new Uri(path).LocalPath;
            path = Path.Combine(path, fileName);
            var confEmail = File.ReadAllText(path);
            return confEmail;
        }
    }
}
