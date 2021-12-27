using Booking.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.TimeShiftAggregate
{
    class TimeShift
    {
        public TimeShift(string title, TimeSpan fromTime, TimeSpan toTime)
        {
            Title = title;
            TimeRange = new TimeRange(fromTime, toTime);
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public TimeRange TimeRange { get; private set; }
    }
}
