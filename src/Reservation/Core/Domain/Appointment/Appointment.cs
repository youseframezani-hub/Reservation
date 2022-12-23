using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Appointment
{
    internal class Appointment
    {
        public int Id { get; set; }
        public List<int> ServiceIds { get; set; }//Choosing at least 1 service 
        public int Supplier { get; set; }//(required)
        public int CustomerId { get; set; }//(optional)
        public DateTime Date { get; set; }//(required)
        public TimeSpan Time { get; set; }//(required)
        public string Interval { get; set; }
        public string Status { get; set; }
        public void Cancel()
        {

        }
        public void Reschedule(DateTime date, TimeSpan time)
        {

        }
        public void EditAppointmentInterval(string interval)
        { }
    }
}
