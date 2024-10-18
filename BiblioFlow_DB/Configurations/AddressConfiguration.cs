using BiblioFlow_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(a=>a.AddressId);
            builder
                .Property(a => a.AddressId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(a=>a.StreetName)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(a=>a.StreetNumber)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(a=>a.Complement)
                .HasMaxLength(10);

            builder
                .Property(a=>a.PostalCode)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(a=>a.City)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(a=>a.Country)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .HasConstraintName("FK_Address_User_UserId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
