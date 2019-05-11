using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Utilities
{
    public class TimeSpanUtilities
    {
        public static TimeSpan Get3MonthsTimeSpanFirstToFirst()
        {
            var now = DateTime.Now;
            var start = new DateTime(now.Year, now.Month, 1, 1, 0, 0).AddMonths(-3);
            var end = new DateTime(now.Year, now.Month, 1, 1, 0, 0);
            return new TimeSpan() { StartDate = start, EndDate = end };
        }
        public static TimeSpan GetLastMonth()
        {
            return GetLast(DateTime.Now, 1, 0);
        }
        public static DateTime GetStartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
        public static TimeSpan GetLastWeek()
        {
            var startOfWeek = GetStartOfWeek(DateTime.Now, DayOfWeek.Monday);
            return GetLast(startOfWeek, 0, 0, 7);
        }
        public static TimeSpan GetLastTwoWeeks()
        {
            var startOfWeek = GetStartOfWeek(DateTime.Now, DayOfWeek.Monday);
            return GetLast(startOfWeek, 0, 0, 14);
        }
        public static TimeSpan GetYesterday()
        {
            return GetLast(DateTime.Now, 0, 0, 1);
        }
        public static TimeSpan GetLast3Months()
        {
            return GetLast(DateTime.Now, 3, 0);
        }
        public static TimeSpan GetLast6Months()
        {
            return GetLast(DateTime.Now, 6, 0);
        }
        public static TimeSpan GetLastYear()
        {
            return GetLast(DateTime.Now, 0, 1);
        }
        public static DateTime GetDateWith30MinutesAdded(DateTime original)
        {
            return GetDateWithNMinutesAdded(original,30);
        }
        public static DateTime GetDateWith15MinutesAdded(DateTime original)
        {
            return GetDateWithNMinutesAdded(original,15);
        }
        public static DateTime GetDateWith2HoursAdded(DateTime original)
        {
            return GetDateWithNMinutesAdded(original, 120);
        }
        private static DateTime GetDateWithNMinutesAdded(DateTime original, int n)
        {
            return original.AddMinutes(n);
        }
        private static TimeSpan GetLast(DateTime startDate, int months = 1, int years = 0, int days = 0)
        {
            months = months * -1;
            years = years * -1;
            var endDate = DateTime.Now;
            startDate = startDate.AddYears(years);
            startDate = startDate.AddMonths(months);
            startDate = startDate.AddDays(days);
            return new TimeSpan() { StartDate = startDate, EndDate = endDate.AddSeconds(-1) };
        }
        public static List<KeyValuePair<int, string>> GetBasicTimeSpans()
        {
            return new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "Last Month"),
                new KeyValuePair<int, string>(2,  "Last 3 Months"),
                new KeyValuePair<int, string>(3, "Last 6 Months"),
                new KeyValuePair<int, string>(4, "Last Year"),
                new KeyValuePair<int, string>(5, "All Time")
            };
        }
    }

    public class TimeSpan
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
