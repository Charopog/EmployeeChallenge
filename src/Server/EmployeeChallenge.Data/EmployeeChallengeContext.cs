
namespace EmployeeChallenge.Data
{
    using EmployeeChallenge.Data.Configurations;
    using EmployeeChallenge.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class EmployeeChallengeContext : DbContext
    {

        public EmployeeChallengeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillAssignment> SkillAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AddressConfiguration(modelBuilder.Entity<Address>());
            new EmployeeConfiguration(modelBuilder.Entity<Employee>());
            new SkillConfiguration(modelBuilder.Entity<Skill>());
            new SkillAssignmentConfiguration(modelBuilder.Entity<SkillAssignment>());

        }


    }
}
