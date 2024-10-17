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
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder
				.HasKey(c => c.CategoryId);
			builder
				.Property(c => c.CategoryId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder
				.Property(c => c.Name)
				.HasMaxLength(100)
				.IsRequired();
			builder
				.HasIndex(c => c.Name)
				.IsUnique();

			builder
				.Property(c => c.Description)
				.HasMaxLength(255);

			builder
				.HasOne(c => c.CreatedByUser)
				.WithMany(u => u.CreatedCategories)
				.HasForeignKey(c => c.CreatedByUserId)
				.HasConstraintName("FK_Category_User_CreatedByUserId")
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(c => c.LastModifiedByUser)
				.WithMany(u => u.LastModifiedCategories)
				.HasForeignKey(c => c.LastModifiedByUserId)
				.HasConstraintName("FK_Category_User_LastModifiedByUserId")
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
