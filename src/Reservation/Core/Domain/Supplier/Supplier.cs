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
        public GuidId Id { get; set; }
        public SupplierName Name { get; set; }
        public Mobile Mobile { get; set; }
        public Email Email { get; set; }
        public Description Description { get; set; }
        public bool Active { get; set; }
        public bool IsInternal { get; set; }
        public bool IsManager { get; set; }
        public List<SuppliierSeviceConfig> SuppliierSeviceConfigs { get; set; }
    }
    internal class SuppliierSeviceConfig
    {
        public Guid Id { get; set; }
        public int SuplierId { get; set; }
        public int ServiceId { get; set; }
        public bool Active { get; set; }
        public bool IsInternal { get; set; }
    }
    public class Id<T>
    {
        public T Value { get; set; }
    }
    public class GuidId :Id<Guid>
    {

    }
    public class Mobile
    {

    }
    public class Email
    {

    }
    public class Description
    {

    }


    internal record SupplierName(string Name)
    {
        public string Name { get; set; }
        public static SupplierName Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidValueException("");

            return new SupplierName(name);
        }
    }

    internal class InvalidValueException : Exception
    {
        public InvalidValueException(string message):base(message)
        {
        }
    }
}
