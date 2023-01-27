using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Supplier
{
    internal class Supplier
    {
        public Supplier(GuidId id, string name, Mobile mobile, Email? email, string? description, bool active, bool isInternal, bool isManager)
        {
            Id = id;
            Name = name;
            Mobile = mobile;
            Email = email;
            Description = description;
            Active = active;
            IsInternal = isInternal;
            IsManager = isManager;
        }

        public GuidId Id { get; set; }
        public string Name { get; set; }
        public Mobile Mobile { get; set; }
        public Email? Email { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public bool IsInternal { get; set; }
        public bool IsManager { get; set; }
        public static Supplier Create(string name, Mobile mobile, Email? email, string? description)
        {
            return new Supplier(GuidId.Create(), name ?? throw new ArgumentNullException(nameof(name)),
                mobile ?? throw new ArgumentNullException(nameof(mobile)), email, description, true, false, false);
        }
    }
    public class Id<T>
    {
        public T Value { get; set; }
    }
    public class GuidId : Id<Guid>
    {
        public static GuidId Create() => new GuidId { Value = Guid.NewGuid() };
    }
    public class Mobile
    {

    }
    public class Email
    {

    }

    internal class InvalidValueException : Exception
    {
        public InvalidValueException(string message) : base(message)
        {
        }
    }
}
