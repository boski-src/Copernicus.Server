using System;

namespace Copernicus.Common.Extensions
{
    public static class DateExtensions
    {
        public static bool IsEarlier(this DateTime date)
        {
            return date.IsEarlier(DateTime.UtcNow);
        }

        public static bool IsLater(this DateTime date)
        {
            return date.IsLater(DateTime.UtcNow);
        }

        public static bool IsEarlier(this DateTime date1, DateTime date2)
        {
            return date1.CompareTo(date2) < 0;
        }

        public static bool IsLater(this DateTime date1, DateTime date2)
        {
            return date1.CompareTo(date2) > 0;
        }

        public static long GetTicks(this DateTime dateTime)
        {
            var ticks = dateTime.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
            ticks /= 10000000;
            return ticks;
        }
    }
}