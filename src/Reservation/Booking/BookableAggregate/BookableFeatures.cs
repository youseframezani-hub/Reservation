using Booking.Base;

namespace Booking.BookableAggregate
{
    class BookableFeatures<TFeatures> : Bookable
    {
        public BookableFeatures(int id, string title, int capacity, Time time, int price, BookableType bookableType, TFeatures features)
            : base(id, title, capacity, time, price, bookableType)
        {
            Features = features;
        }

        public TFeatures Features { get; private set; }
    }

}
