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
	public class SaleConfiguration : IEntityTypeConfiguration<Sale>
	{
		public void Configure(EntityTypeBuilder<Sale> builder)
		{
			builder
				.HasKey(s => s.SaleId);
			builder
				.Property(s => s.SaleId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder
				.Property(s => s.SaleDate)
				.HasColumnType("DATETIME2(7)")
				.IsRequired();

			builder
				.Property(s => s.Quantity)
				.IsRequired();

			builder
				.Property(s => s.TotalPrice)
				.HasColumnType("DECIMAL(10, 2)")
				.IsRequired();

			builder
				.HasOne(s => s.User)
				.WithMany(u => u.BoughtBooks)
				.HasForeignKey(s => s.UserId)
				.HasConstraintName("FK_Sale_User_UserId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(s => s.Library)
				.WithMany(l => l.SoldBooks)
				.HasForeignKey(s => s.LibraryId)
				.HasConstraintName("FK_Sale_Library_LibraryId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(s => s.Book)
				.WithMany(b => b.SoldBooks)
				.HasForeignKey(s => s.BookId)
				.HasConstraintName("FK_Sale_Book_BookId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(s => s.SoldByUser)
				.WithMany(u => u.SoldBooks)
				.HasForeignKey(s => s.SoldByUserId)
				.HasConstraintName("FK_Sale_User_SoldByUserId")
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
