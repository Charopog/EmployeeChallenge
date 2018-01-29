
namespace EmployeeChallenge.Entities
{
    using EmployeeChallenge.Entities.Abstractions;
    using System;

    public class Address : IEntityBase
    {
        public Guid ID { get; set; }

        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        
        public Employee Employee { get; set; }
    }
}
