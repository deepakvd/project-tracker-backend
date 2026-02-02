using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_domain.Entities
{
    public class Task : BaseEntity
    {
        public Guid ProjectId { get; set; } // Foreign key to Project

        public Project Project { get; set; } // Navigation property to Project

        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public TaskStatus Status { get; set; }

        public Guid AssigneeUserId { get; set; } // Foreign key to User

        public User AssignedUser { get; set; } // Navigation property to User

        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();


    }
}
