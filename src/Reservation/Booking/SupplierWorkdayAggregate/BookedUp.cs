using Booking.Base;
using Booking.BookableAggregate;

namespace Booking.SupplierWorkdayAggregate
{
    class BookedUp : Bookable
    {
        public BookedUp(Bookable bookable, TimeRange timeRange)
            : base(bookable.Id, bookable.Title, bookable.Capacity, bookable.Time, bookable.Price, bookable.BookableType,0)
        {
            BookStatus = BookStatus.Booked;
            TimeRange = timeRange;
            _totalCapacity = bookable.Capacity;
            DecreaseCapacity();
        }
        private int _totalCapacity;
        public BookStatus BookStatus { get; private set; }
        public TimeRange TimeRange { get; private set; }
        public void DecreaseCapacity()
        {
            if (Capacity == 0) return;
            Capacity -= 1;
        }
        public void IncreaseCapacity()
        {
            if (Capacity == _totalCapacity) return;
            Capacity += 1;
        }
        public bool IsFree => Capacity == _totalCapacity;
        public bool CanBookup => Capacity < _totalCapacity;
    }
}


