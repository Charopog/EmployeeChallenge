
namespace EmployeeChallenge.Entities
{
    using EmployeeChallenge.Entities.Abstractions;
    using System;
    using System.Collections.Generic;

    public class Skill : IEntityBase
    {
        public Skill()
        {
            SkillAssignments = new List<SkillAssignment>();
        }
        public Guid ID { get; set; }
        public string Name { get; set; }

        public ICollection<SkillAssignment> SkillAssignments { get; set; }
    }
}
