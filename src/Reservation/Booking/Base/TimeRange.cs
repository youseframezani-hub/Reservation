using System;

namespace Booking.Base
{
    class TimeRange
    {
        public TimeRange(TimeSpan fromTime, TimeSpan toTime)
        {
            From = fromTime;
            To = toTime;
        }

        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public int TotalMinutes => (int)(To - From).TotalMinutes;
    }
}
