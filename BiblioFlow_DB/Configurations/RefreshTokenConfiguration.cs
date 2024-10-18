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
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder
                .HasKey(t => t.TokenId);
            builder
                .Property(t => t.TokenId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(t => t.Token)
                .IsRequired();

            builder
                .Property(t => t.ExpiresAt)
                .IsRequired();

            builder
                .Property(t => t.IsRevoked)
                .IsRequired();

            builder
                .Property(t => t.CreatedAt)
                .IsRequired();
        }
    }
}
