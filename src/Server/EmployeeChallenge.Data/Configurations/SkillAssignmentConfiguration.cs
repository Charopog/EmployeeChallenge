
namespace EmployeeChallenge.Data.Configurations
{
    using EmployeeChallenge.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SkillAssignmentConfiguration
    {
        public SkillAssignmentConfiguration(EntityTypeBuilder<SkillAssignment> entity)
        {
            entity.ToTable("SkillAssignment");

            entity.Property(sa => sa.AssignmentDate)
                .HasDefaultValueSql("getutcdate()")
                .IsRequired();

            entity.HasOne<Employee>(sa => sa.Employee)
                .WithMany(e => e.SkillAssignments)
                .HasForeignKey(sa => sa.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne<Skill>(sa => sa.Skill)
                .WithMany(s => s.SkillAssignments)
                .HasForeignKey(sa => sa.SkillID)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
