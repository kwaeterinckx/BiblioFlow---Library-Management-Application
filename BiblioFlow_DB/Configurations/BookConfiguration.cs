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
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder
				.HasKey(b => b.BookId);
			builder
				.Property(b => b.BookId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder
				.Property(b => b.Title)
				.HasMaxLength(255)
				.IsRequired();

			builder
				.Property(b => b.Description)
				.HasColumnType("TEXT");

			builder
				.Property(b => b.ISBN)
				.HasMaxLength(20);
			builder
				.HasIndex(b => b.ISBN)
				.IsUnique();

			builder
				.Property(b => b.Publisher)
				.HasMaxLength(255)
				.IsRequired();

			builder
				.Property(b => b.PublicationYear)
				.IsRequired();

			builder
				.Property(b => b.Price)
				.HasColumnType("DECIMAL(10, 2)");

			builder
				.Property(b => b.CreatedAt)
				.HasColumnType("DATETIME2(7)")
				.IsRequired();

			builder
				.Property(b => b.LastModifiedAt)
				.HasColumnType("DATETIME2(7)");

			builder
				.HasOne(b => b.CreatedByUser)
				.WithMany(u => u.CreatedBooks)
				.HasForeignKey(b => b.CreatedByUserId)
				.HasConstraintName("FK_Book_User_CreatedByUserId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(b => b.LastModifiedByUser)
				.WithMany(u => u.LastModifiedBooks)
				.HasForeignKey(b => b.LastModifiedByUserId)
				.HasConstraintName("FK_Book_User_LastModifiedByUserId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(b => b.Authors)
				.WithMany(a => a.Books)
				.UsingEntity<Dictionary<string, object>>(
					"BookAuthor",
					ba => ba.HasOne<Author>().WithMany().OnDelete(DeleteBehavior.NoAction),
					ba => ba.HasOne<Book>().WithMany().OnDelete(DeleteBehavior.NoAction)
				);

			builder
				.HasMany(b => b.Categories)
				.WithMany(c => c.Books)
				.UsingEntity<Dictionary<string, object>>(
					"BookCategory",
					bc => bc.HasOne<Category>().WithMany().OnDelete(DeleteBehavior.NoAction),
					bc => bc.HasOne<Book>().WithMany().OnDelete(DeleteBehavior.NoAction)
				);
		}
	}
}
