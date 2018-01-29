
namespace EmployeeChallenge.Data.Configurations
{
    using EmployeeChallenge.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AddressConfiguration
    {
        public AddressConfiguration(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Address");

            entity.Property(a => a.AddressLine)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(a => a.City)
                .HasMaxLength(100);

            entity.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(a => a.ZipCode)
                .HasMaxLength(50);

            entity.HasOne<Employee>(a => a.Employee)
                .WithOne(e => e.Address)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
