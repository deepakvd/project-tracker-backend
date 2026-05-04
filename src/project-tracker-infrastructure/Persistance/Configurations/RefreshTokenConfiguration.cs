using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project_tracker_domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_infrastructure.Persistance.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            // Set primary key
            builder.HasKey(rt => rt.Id);

            // Set required properties
            builder.Property(rt => rt.UserId)
                .IsRequired();

            builder.Property(rt => rt.Token).IsRequired()
                .HasMaxLength(500);

            builder.Property(rt => rt.ExpiresAt).IsRequired();

            builder.Property(rt => rt.IsUsed).IsRequired();

            // Set up relationship with User
            builder.HasOne(rt => rt.User)
                .WithMany()
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
