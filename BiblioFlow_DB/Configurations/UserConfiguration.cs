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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.UserId);
            builder
                .Property(u => u.UserId)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .IsRequired();

            builder
                .Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(u => u.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasMaxLength(320)
                .IsRequired();
            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.Password)
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder
                .Property(u => u.Role)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(u => u.IsActif)
                .HasDefaultValue(true)
                .IsRequired();

            builder
                .Property(u => u.LastLoginAt)
                .HasColumnType("DATETIME2(7)");

            builder
                .Property(u => u.CreatedAt)
                .HasColumnType("DATETIME2(7)")
                .IsRequired();

            builder
                .Property(u => u.LastModifiedAt)
                .HasColumnType("DATETIME2(7)");

            builder
                .HasOne(u => u.CreatedByUser)
                .WithMany(u => u.CreatedUsers)
                .HasForeignKey(u => u.CreatedByUserId)
                .HasConstraintName("FK_User_User_CreatedByUserId");

            builder
                .HasOne(u => u.LastModifiedByUser)
                .WithMany(u => u.LastModifiedUsers)
                .HasForeignKey(u => u.LastModifiedByUserId)
                .HasConstraintName("FK_User_User_LastModifiedByUserId");

            builder
                .HasOne(u => u.Library)
                .WithMany(l => l.StaffMembers)
                .HasForeignKey(u => u.LibraryId)
                .HasConstraintName("FK_User_Library_LibraryId");
        }
    }
}
