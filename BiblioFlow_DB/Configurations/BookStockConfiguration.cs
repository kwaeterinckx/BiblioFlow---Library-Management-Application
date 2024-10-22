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
	public class BookStockConfiguration : IEntityTypeConfiguration<BookStock>
	{
		public void Configure(EntityTypeBuilder<BookStock> builder)
		{
			builder
				.HasKey(bs => bs.BookStockId);
			builder
				.Property(bs => bs.BookStockId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder
				.Property(bs => bs.StockType)
				.HasMaxLength(50)
				.IsRequired();

			builder
				.Property(bs => bs.Quantity)
				.IsRequired();

			builder
				.Property(bs => bs.ReservedStock)
				.IsRequired();

			builder
				.Property(bs => bs.LastUpdatedAt)
				.HasColumnType("DATETIME2(7)")
				.IsRequired();

			builder
				.HasOne(bs => bs.LastUpdatedByUser)
				.WithMany(u => u.LastUpdatedBookStock)
				.HasForeignKey(u => u.LastUpdatedByUserId)
				.HasConstraintName("FK_BookStock_User_LastUpdatedByUserId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(bs => bs.Library)
				.WithMany(l => l.BookStocks)
				.HasForeignKey(bs => bs.LibraryId)
				.HasConstraintName("FK_BookStock_Library_LibraryId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(bs => bs.Book)
				.WithMany(b => b.BookStocks)
				.HasForeignKey(bs => bs.BookId)
				.HasConstraintName("FK_BookStock_Book_BookId")
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
