using Booking.Base;
using System;

namespace Booking.DomainService.TimeSuggestion
{
    class TimeRangeBookable
    {
        public TimeRangeBookable(TimeSpan formTime, TimeSpan toTime)
        {
            TimeRange = new TimeRange(formTime, toTime);
        }
        public TimeRange TimeRange { get; private set; }
        public int Capacity { get; private set; }
        public int BookableId { get; private set; }
        public bool IsFree(int bookableId) => BookableId == 0 || BookableId == bookableId && Capacity > 0;
        public bool IsFree() => BookableId == 0;
        public void SetBookable(int bookableId, TimeRange bookableTimeRange, int bookableCapacity)
        {
            if (!IsBookable(bookableId, bookableTimeRange)) return;
            Capacity = BookableId == 0 ? bookableCapacity - 1 : Capacity - 1;
            BookableId = BookableId;
        }
        private bool IsBookable(int bookableId, TimeRange bookableTimeRange) =>
            TimeRange.From >= bookableTimeRange.From
            && TimeRange.To <= bookableTimeRange.To
            && IsFree(bookableId);

    }
}


