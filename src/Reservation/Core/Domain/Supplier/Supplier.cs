using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Supplier
{
    internal class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool IsInternal { get; set; }
        public string Role { get; set; }
    }
}
