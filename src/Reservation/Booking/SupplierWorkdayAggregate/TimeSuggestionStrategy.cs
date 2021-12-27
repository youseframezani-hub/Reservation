using Booking.Base;
using Booking.BookableAggregate;
using System.Collections.Generic;

namespace Booking.SupplierWorkdayAggregate
{
    interface TimeSuggestionStrategy
    {
        List<TimeRange> GetBookableTimeRange(SupplierWorkday supplierWorkday, List<Bookable> bookables);
        List<TimeRange> GetBookableTimeRange(SupplierWorkday supplierWorkday, Bookable bookable);
    }
}


