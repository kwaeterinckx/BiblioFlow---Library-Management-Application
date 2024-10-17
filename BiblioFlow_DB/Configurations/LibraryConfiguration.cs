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
    public class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder
                .HasKey(l => l.LibraryId);
            builder
                .Property(l => l.LibraryId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(l => l.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(l => l.Address)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(l => l.Phone)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(l => l.Email)
                .HasMaxLength(320)
                .IsRequired();

            builder
                .Property(l => l.CreatedAt)
                .HasColumnType("DATETIME2(7)")
                .IsRequired();

            builder
                .Property(l => l.LastModifiedAt)
                .HasColumnType("DATETIME2(7)");

            builder
                .HasOne(l => l.CreatedByUser)
                .WithMany(u => u.CreatedLibraries)
                .HasForeignKey(l => l.CreatedByUserId)
                .HasConstraintName("FK_Library_User_CreatedByUserId");

            builder
                .HasOne(l => l.LastModifiedByUser)
                .WithMany(u => u.LastModifiedLibraries)
                .HasForeignKey(l => l.LastModifiedByUserId)
                .HasConstraintName("FK_Library_User_LastModifiedByUserId");
        }
    }
}
