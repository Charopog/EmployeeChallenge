
namespace EmployeeChallenge.Entities
{
    using EmployeeChallenge.Entities.Abstractions;
    using System;

    public class SkillAssignment : IEntityBase
    {
        public Guid ID { get; set; }
        public DateTime AssignmentDate { get; set; }

        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public Guid SkillID { get; set; }
        public Skill Skill { get; set; }
    }
}
