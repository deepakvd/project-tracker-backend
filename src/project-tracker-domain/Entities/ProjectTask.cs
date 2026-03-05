using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_domain.Entities
{
    public class ProjectTask : BaseEntity
    {
        public Guid ProjectId { get; set; } // Foreign key to Project

        public required Project Project { get; set; } // Navigation property to Project

        public required string Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public TaskStatus Status { get; set; }

        public Guid? AssignedUserId { get; set; } // Foreign key to User

        public User? AssignedUser { get; set; } // Navigation property to User

        public ICollection<Attachment>? Attachments { get; set; } = new List<Attachment>();


    }
}
