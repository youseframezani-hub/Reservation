using Booking.Base;
using Booking.BookableAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCase.Commands
{
    class DefinitionOfWorkingDays
    {
        private List<DateTime> WhichDays { get; set; }
        private List<int> WhichServices { get; set; }
        private List<TimeRange> WhichShifts { get; set; }

        private IBokableRepository bokableRepository;
        public void Execute()
        {

        }
    }

    internal interface IBokableRepository
    {
        List<Bookable> GetBookables(int supplierId);
    }
}
