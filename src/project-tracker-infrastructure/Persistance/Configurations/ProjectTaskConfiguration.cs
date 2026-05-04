using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project_tracker_domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_infrastructure.Persistance.Configurations
{
    public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.HasKey(pt=>pt.Id);

            builder.Property(pt=>pt.Title).IsRequired().HasMaxLength(50);

            builder.Property(pt=> pt.Description).HasMaxLength(2000);

            builder.Property(pt => pt.Status).HasConversion<string>();

            // Indexes

            builder.HasIndex(pt => pt.ProjectId);

            builder.HasIndex(pt => pt.AssignedUserId);

            builder.HasIndex(pt => pt.DueDate);

            builder.HasIndex(pt => pt.Status);

            builder.HasOne(pt=>pt.Project).WithMany(p=>p.Tasks).HasForeignKey(p=>p.ProjectId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pt=>pt.Attachments).WithOne(at=>at.Task).HasForeignKey(a=>a.TaskId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
