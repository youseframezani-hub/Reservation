using System;

namespace Booking.Base
{
    class Time
    {
        private TimeSpan _timeSpan;
        public int TotalMinutes => (int)_timeSpan.TotalMinutes;
    }
}

