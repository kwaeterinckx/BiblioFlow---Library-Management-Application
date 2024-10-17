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
	public class LoanConfiguration : IEntityTypeConfiguration<Loan>
	{
		public void Configure(EntityTypeBuilder<Loan> builder)
		{
			builder
				.HasKey(l => l.LoanId);
			builder
				.Property(l => l.LoanId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder
				.Property(l => l.LoanDate)
				.HasColumnType("DATETIME2(7)")
				.IsRequired();

			builder
				.Property(l => l.DueDate)
				.HasColumnType("DATETIME2(7)")
				.IsRequired();

			builder
				.Property(l => l.ReturnDate)
				.HasColumnType("DATETIME2(7)");

			builder
				.HasOne(s => s.User)
				.WithMany(u => u.RentedBooks)
				.HasForeignKey(s => s.UserId)
				.HasConstraintName("FK_Loan_User_UserId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(s => s.Library)
				.WithMany(l => l.LentBooks)
				.HasForeignKey(s => s.LibraryId)
				.HasConstraintName("FK_Loan_Library_LibraryId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(s => s.Book)
				.WithMany(b => b.LentBooks)
				.HasForeignKey(s => s.BookId)
				.HasConstraintName("FK_Loan_Book_BookId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(s => s.LentByUser)
				.WithMany(u => u.LentBooks)
				.HasForeignKey(s => s.LentByUserId)
				.HasConstraintName("FK_Loan_User_LentByUserId")
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
