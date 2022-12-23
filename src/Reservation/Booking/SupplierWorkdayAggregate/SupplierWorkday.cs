using Booking.Base;
using Booking.BookableAggregate;
using Booking.TimeShiftAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Booking.SupplierWorkdayAggregate
{
    class SupplierWorkday
    {
        private TimeSuggestionStrategy _timeSuggestionStrategy;
        private int _supplierId;
        private DateTime _day;
        private List<TimeRange> _timeShifts;
        private List<Bookable> _bookables;
        private List<BookedUp> _bookedUps;
        public SupplierWorkday(TimeSuggestionStrategy timeSuggestionStrategy, int supplierId, DateTime day,
            List<TimeRange> timeShifts, List<Bookable> bookables, List<BookedUp> bookedUps = null)
        {
            _timeSuggestionStrategy = timeSuggestionStrategy ?? throw new ArgumentNullException("timeSuggestionStrategy should not null.");
            _supplierId = supplierId != 0 ? supplierId : throw new ArgumentException("supplierId should not zero.");
            _day = day;
            _timeShifts = timeShifts == null || timeShifts.Count == 0 ? throw new Exception("Must have at least one time shift") : timeShifts;
            _bookables = bookables == null || bookables.Count == 0 ? throw new Exception("Must have at least one bookable") : bookables;
            _bookedUps = bookedUps == null ? new List<BookedUp>() : bookedUps;
        }
        private SupplierWorkday()
        {
        }
        public static SupplierWorkday Initiale(int supplierId, DateTime day,
            List<TimeRange> timeShifts, List<Bookable> bookables)
        {
            var s = new SupplierWorkday();
            s._supplierId = supplierId != 0 ? supplierId : throw new ArgumentException("supplierId should not zero.");
            s._day = day;
            s._timeShifts = timeShifts == null || timeShifts.Count == 0 ? throw new Exception("Must have at least one time shift") : timeShifts;
            s._bookables = bookables;

            return s;
        }
        public string Id => $"{_supplierId}_{_day.ToShortDateString()}";
        public IReadOnlyList<TimeRange> TimeShifts => _timeShifts.AsReadOnly();
        public IReadOnlyList<Bookable> Bookables => _bookables.AsReadOnly();
        public IReadOnlyList<BookedUp> BookedUps => _bookedUps.AsReadOnly();
        public bool IsFull(Bookable bookable)
        {
            return _timeSuggestionStrategy.GetBookableTimeRange(this, bookable).Any();
        }
        public bool IsFull(List<Bookable> bookables)
        {
            return _timeSuggestionStrategy.GetBookableTimeRange(this, bookables).Any();
        }
        public bool IsOff => !_bookables.Any() || !_timeShifts.Any();
        public List<TimeRange> GetBookableTimeRange(List<Bookable> bookables)
        {
            return _timeSuggestionStrategy.GetBookableTimeRange(this, bookables);
        }
        public void Booking(int bookableId, TimeRange timeRange)
        {
            if (!_bookables.Any(b => b.Id == bookableId)) throw new Exception("bookable not found");
            if (IsOff) throw new Exception("workday is Off");
            var bookable = _bookables.First(b => b.Id == bookableId);
            if (IsFull(bookable)) throw new Exception("workday is full");

            AddBookedUp(bookable, timeRange);
        }
        public void Booking(List<int> bookableIds, TimeRange timeRange)
        {
            if (IsOff) throw new Exception("workday is Off");
            var bookables = _bookables.Where(b => bookableIds.Contains(b.Id)).ToList();
            if (bookableIds.Count != bookableIds.Count) throw new Exception("bookable not found");
            //bookable haye ke be soorate chantayi bashad, nabayad hich kodam az anha capacity bishtar az yek dashte bashad
            if (bookables.Any(b => b.Capacity > 1)) throw new Exception("bookabel capacity more than one capacity");
            if (bookables.Sum(s => s.Time.TotalMinutes) != timeRange.TotalMinutes) throw new Exception("differnt total minouts");
            if (IsFull(bookables)) throw new Exception("workday is full");

            TimeRange time = null;
            foreach (var bookable in bookables)
            {
                time = new TimeRange
                (
                    time == null ? timeRange.From : time.To,
                    timeRange.From.Add(TimeSpan.FromMinutes(bookable.Time.TotalMinutes))
                );
                AddBookedUp(bookable, time);
            }
        }
        public void CancelBooking(int bookableId)
        {
            var bookedUp = _bookedUps.FirstOrDefault(b => b.Id == bookableId);

            if (bookedUp == null) return;

            bookedUp.IncreaseCapacity();

            if (bookedUp.IsFree)
                _bookedUps.Remove(bookedUp);
        }
        public void CancelBooking(List<int> bookableIds)
        {
            foreach (var bookabelId in bookableIds)
            {
                CancelBooking(bookabelId);
            }
        }
        private void AddBookedUp(Bookable bookable, TimeRange timeRange)
        {
            var bookedUp = _bookedUps.FirstOrDefault(b => b.Id == bookable.Id);
            if (bookedUp == null)
                _bookedUps.Add(new BookedUp(bookable, timeRange));
            else if (bookedUp.CanBookup)
                bookedUp.DecreaseCapacity();
            else
                throw new Exception("capacity is full");
        }

    }
}


