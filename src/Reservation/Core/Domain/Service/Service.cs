using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Interval { get; set; }
        public string BasePrice { get; set; }
        public string Description { get; set; }
        public string SupplierId { get; set; }
        public bool Active { get; set; }
        public bool IsInternal { get; set; }

    }
}
