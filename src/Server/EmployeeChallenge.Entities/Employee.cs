
namespace EmployeeChallenge.Entities
{
    using EmployeeChallenge.Entities.Abstractions;
    using System;
    using System.Collections.Generic;

    public class Employee : IEntityBase
    {
        public Employee()
        {
            SkillAssignments = new List<SkillAssignment>();
        }

        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
        public Guid AddressID { get; set; }
        public ICollection<SkillAssignment> SkillAssignments { get; set; }
    }
}
