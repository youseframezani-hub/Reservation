using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customer
{
    internal class Customer
    {
        public string phonenumber { get; set; }
        public string name { get; set; } //(required)
        public string Email { get; set; }//(optional)
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Notes { get; set; }//(Notes help keep track of customers. customers cannot see these notes)
        public string CreatedBy { get; set; }
    }
}
