
namespace EmployeeChallenge.Xam.Mappings
{
    using EmployeeChallenge.Dtos;
    using EmployeeChallenge.Xam.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class SkillMappings
    {
        public static Skill ToLocal(this SkillDto skillDto)
        {
            return new Skill(skillDto.ID)
            {
                Name = skillDto.Name
            };
        }

        public static SkillDto ToDto(this Skill skill)
        {
            return new SkillDto()
            {
                ID = skill.ID,
                Name = skill.Name
            };
        }
    }
}
