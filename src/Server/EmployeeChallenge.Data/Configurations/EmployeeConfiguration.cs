
using EmployeeChallenge.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeChallenge.Data.Configurations
{


    public class EmployeeConfiguration
    {
        public EmployeeConfiguration(EntityTypeBuilder<Employee> entity)
        {
            entity.ToTable("Employee");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired();

            entity.HasOne<Address>(e => e.Address)
                .WithOne(a => a.Employee)
                .HasForeignKey<Employee>(e => e.AddressID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
