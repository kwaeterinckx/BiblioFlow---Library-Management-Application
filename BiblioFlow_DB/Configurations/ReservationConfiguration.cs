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
	public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
	{
		public void Configure(EntityTypeBuilder<Reservation> builder)
		{
			builder
				.HasKey(r => r.ReservationId);
			builder
				.Property(r => r.ReservationId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder
				.Property(r => r.ReservationDate)
				.HasColumnType("DATETIME2(7)")
				.IsRequired();

			builder
				.Property(r => r.Status)
				.HasMaxLength(50)
				.IsRequired();

			builder
				.HasOne(r => r.User)
				.WithMany(u => u.Reservations)
				.HasForeignKey(r => r.UserId)
				.HasConstraintName("FK_Reservation_User_UserId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(r => r.Library)
				.WithMany(l => l.Reservations)
				.HasForeignKey(r => r.LibraryId)
				.HasConstraintName("FK_Reservation_Library_LibraryId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(r => r.Book)
				.WithMany(b => b.Reservations)
				.HasForeignKey(r => r.BookId)
				.HasConstraintName("FK_Reservation_Book_BookId")
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
