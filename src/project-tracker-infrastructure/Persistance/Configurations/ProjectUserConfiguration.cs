using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project_tracker_domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_infrastructure.Persistance.Configurations
{
    public class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser>
    {
        public void Configure(EntityTypeBuilder<ProjectUser> builder)
        {
            builder.HasKey(pu => new { pu.ProjectId, pu.UserId });

            builder.HasOne(pu => pu.Project)
                .WithMany(p => p.ProjectUsers)
                .HasForeignKey(pu => pu.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pu => pu.User)
                .WithMany(p=>p.ProjectMemberships)
                .HasForeignKey(pu => pu.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Set Enum ProjectRole
            builder.Property(pu => pu.ProjectRole).HasConversion<string>();

        }
    }
}
