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
	public class AuthorConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder
				.HasKey(a => a.AuthorId);
			builder
				.Property(a => a.AuthorId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder
				.Property(a => a.FirstName)
				.HasMaxLength(100)
				.IsRequired();

			builder
				.Property(a => a.LastName)
				.HasMaxLength(100)
				.IsRequired();

			builder
				.Property(a => a.Bio)
				.HasColumnType("TEXT");

			builder
				.Property(a => a.CreatedAt)
				.HasColumnType("DATETIME2(7)")
				.IsRequired();

			builder
				.Property(a => a.LastModifiedAt)
				.HasColumnType("DATETIME2(7)");

			builder
				.HasOne(a => a.CreatedByUser)
				.WithMany(u => u.CreatedAuthors)
				.HasForeignKey(a => a.CreatedByUserId)
				.HasConstraintName("FK_Author_User_CreatedByUserId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(a => a.LastModifiedByUser)
				.WithMany(u => u.LastModifiedAuthors)
				.HasForeignKey(a => a.LastModifiedByUserId)
				.HasConstraintName("FK_Author_User_LastModifiedByUserId")
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
