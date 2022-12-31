using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Supplier
{
    internal class Supplier
    {
        public GuidBaseId BaseId { get; set; }
        public Name FullName { get; set; }
        public Mobile Mobile { get; set; }
        public Email? Email { get; set; }
        public Description? Description { get; set; }
        public bool Active { get; set; }
        public bool IsInternal { get; set; }
        public bool IsManager { get; set; }
        public List<SupplierServiceOption>? SupplierServiceOptions { get; set; }
    }


    public record Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static Name Create(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                throw new InvalidValueException("");

            return new Name { FirstName = firstName, LastName = lastName };
        }
    }
}