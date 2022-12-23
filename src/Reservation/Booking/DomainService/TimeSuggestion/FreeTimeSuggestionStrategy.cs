using Booking.Base;
using Booking.BookableAggregate;
using Booking.SupplierWorkdayAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Booking.DomainService.TimeSuggestion
{
    class FreeTimeSuggestionStrategy : TimeSuggestionStrategy
    {
        private List<TimeRangeBookable> _timeRangeBookables;
        public List<TimeRange> GetBookableTimeRange(SupplierWorkday supplierWorkday, List<Bookable> bookables)
        {
            if (supplierWorkday.IsOff || bookables == null || bookables.Count == 0)
                return new List<TimeRange>();

            FillTimeRangeBookables(supplierWorkday);
            SetBookedUpsToTimeRangeBookables(supplierWorkday);

            if (bookables.Count == 1)
                return SuggestTimeRange(bookables.First());

            return SuggestTimeRanges(bookables);
        }
        public List<TimeRange> GetBookableTimeRange(SupplierWorkday supplierWorkday, Bookable bookable)
        {
            return GetBookableTimeRange(supplierWorkday, new List<Bookable> { bookable });
        }

        protected void FillTimeRangeBookables(SupplierWorkday supplierWorkday)
        {
            var minTimeShift = 5; //supplierWorkday.Bookables.Min(b => b.Time.TimeSpan.TotalMinutes);
            foreach (var timeShift in supplierWorkday.TimeShifts)
            {
                addTimeShifts(timeShift);
            }

            void addTimeShifts(TimeRange timeRange)
            {
                var time = timeRange.From;
                while (time < timeRange.To)
                {
                    _timeRangeBookables.Add(new TimeRangeBookable(time, time.Add(TimeSpan.FromMinutes(minTimeShift))));
                    time.Add(TimeSpan.FromMinutes(minTimeShift));
                }
            }
        }
        protected void SetBookedUpsToTimeRangeBookables(SupplierWorkday supplierWorkday)
        {
            if (supplierWorkday.BookedUps == null)
            {
                return;
            }
            foreach (var bookable in supplierWorkday.BookedUps)
            {
                foreach (var timeRangeBookable in _timeRangeBookables)
                {
                    timeRangeBookable.SetBookable(bookable.Id, bookable.TimeRange, bookable.Capacity);
                }
            }
        }
        protected List<TimeRange> SuggestTimeRange(Bookable bookable)
        {
            var timeRanges = new List<TimeRange>();
            var bookableTotalMinutes = TimeSpan.FromMinutes(bookable.Time.TotalMinutes);

            TimeSpan fromTime = TimeSpan.Zero;

            foreach (var timeRangeBookable in _timeRangeBookables)
            {
                TimeSpan time = TimeSpan.Zero;
                if (!timeRangeBookable.IsFree(bookable.Id))
                {
                    fromTime = TimeSpan.Zero;
                    continue;
                }

                if (fromTime == TimeSpan.Zero)
                    fromTime = timeRangeBookable.TimeRange.From;

                time.Add(TimeSpan.FromMinutes(timeRangeBookable.TimeRange.TotalMinutes));
                if (time >= bookableTotalMinutes)
                {
                    timeRanges.Add(new TimeRange(fromTime, fromTime.Add(time)));
                    fromTime = TimeSpan.Zero;
                }
            }

            return timeRanges;
        }
        protected List<TimeRange> SuggestTimeRanges(List<Bookable> bookables)
        {
            //bookable haye ke be soorate chantayi bashad, nabayad hich kodam az anha capacity bishtar az yek dashte bashad
            if (bookables.Any(b => b.Capacity > 1))
            {
                throw new Exception("bookabe capacity more than one capacity");
            }
            var timeRanges = new List<TimeRange>();
            var bookableTotalMinutes = TimeSpan.FromMinutes(bookables.Sum(s => s.Time.TotalMinutes));

            TimeSpan fromTime = TimeSpan.Zero;

            foreach (var timeRangeBookable in _timeRangeBookables)
            {
                TimeSpan time = TimeSpan.Zero;
                if (!timeRangeBookable.IsFree())
                {
                    fromTime = TimeSpan.Zero;
                    continue;
                }

                if (fromTime == TimeSpan.Zero)
                    fromTime = timeRangeBookable.TimeRange.From;

                time.Add(TimeSpan.FromMinutes(timeRangeBookable.TimeRange.TotalMinutes));
                if (time >= bookableTotalMinutes)
                {
                    timeRanges.Add(new TimeRange(fromTime, fromTime.Add(time)));
                    fromTime = TimeSpan.Zero;
                }
            }

            return timeRanges;
        }
    }
}


