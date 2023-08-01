using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public static class DatabaseConfiguration
{

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s=>s.FirstName).IsRequired().HasMaxLength(250);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(250);
            builder.Property(s => s.BankAccountNumber).IsRequired().HasMaxLength(15);
            builder.Property(s => s.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(100);

            builder.HasIndex(s => s.Email).IsUnique();

            builder.HasIndex(s => new { s.FirstName, s.LastName, s.DateOfBirth }).IsUnique();

        }
    }
}
