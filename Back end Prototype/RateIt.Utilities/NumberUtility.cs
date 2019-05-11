using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Utilities
{
    public static class NumberUtility
    {
        public static double SafeReturnNumber(this double? number)
        {
            if (!number.HasValue) return 0.0;
            return number.Value;
        }

        public static double Max(this double value, double max)
        {
            return value > max ? max : value;
        }

        public static double GetXPercent(this double value, double percent)
        {
            if (percent > 100) percent = 100;
            return (value / 100.0) * percent;
        }

        public static double GetRandomDouble(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}
