
namespace EmployeeChallenge.Data.Configurations
{
    using EmployeeChallenge.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SkillConfiguration
    {
        public SkillConfiguration(EntityTypeBuilder<Skill> entity)
        {
            entity.ToTable("Skill");

            entity.Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
