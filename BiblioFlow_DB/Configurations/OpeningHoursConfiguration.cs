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
	public class OpeningHoursConfiguration : IEntityTypeConfiguration<OpeningHours>
	{
		public void Configure(EntityTypeBuilder<OpeningHours> builder)
		{
			builder
				.HasKey(oh => oh.OpeningHourId);
			builder
				.Property(oh => oh.OpeningHourId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder
				.Property(oh => oh.DayOfWeek)
				.IsRequired();
			builder
				.ToTable(t => t.HasCheckConstraint("CK_DayOfWeek", "[DayOfWeek] BETWEEN 1 AND 7"));

			builder
				.Property(oh => oh.OpenTime)
				.HasColumnType("TIME");

			builder
				.Property(oh => oh.CloseTime)
				.HasColumnType("TIME");

			builder
				.Property(oh => oh.IsClosed)
				.IsRequired();

			builder
				.Property(u => u.LastModifiedAt)
				.HasColumnType("DATETIME2(7)")
				.IsRequired();

			builder
				.Property(u => u.LastModifiedById)
				.HasColumnType("UNIQUEIDENTIFIER")
				.IsRequired();

			builder
				.HasOne(oh => oh.Library)
				.WithMany(l => l.OpeningHours)
				.HasForeignKey(oh => oh.LibraryId)
				.HasConstraintName("FK_OpeningHours_Library_LibraryId")
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
