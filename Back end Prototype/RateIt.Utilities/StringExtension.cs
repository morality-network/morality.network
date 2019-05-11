using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RateIt.Utilities
{
    public static class StringExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static IList<string> StripMentions(this string str)
        {
            IList<string> mentions = new List<string>();
            MatchCollection mcol = Regex.Matches(str, @"@\b\S+?\b");

            foreach (Match m in mcol)
            {
                mentions.Add(m.ToString());
            }

            return mentions;
        }

        public static double SafeReturnNumber(this string number)
        {
            var safeNumber = 0.0;
            if (!string.IsNullOrEmpty(number))
            {
                double.TryParse(number, out safeNumber);
            }
            return safeNumber;
        }

        public static string GetMaxString(this string original, int max)
        {
            var maxStringRaw = original?.Take(max);
            var maxString = maxStringRaw == null ? string.Empty : string.Concat(maxStringRaw);
            return maxString;
        }
    }
}
