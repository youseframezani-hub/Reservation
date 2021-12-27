using Booking.Base;
using System.Collections.Generic;
using System.Text;

namespace Booking.BookableAggregate
{
    class Bookable
    {
        public Bookable(int id, string title, int capacity, Time time, int price, BookableType bookableType)
        {
            Id = id;
            Title = title;
            Capacity = capacity;
            Time = time;
            Price = price;
            BookableType = bookableType;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public int Capacity { get; protected set; }
        public Time Time { get; private set; }
        public int Price { get; private set; }
        public BookableType BookableType { get; set; }
    }

}
