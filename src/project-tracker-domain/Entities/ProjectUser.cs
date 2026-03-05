using project_tracker_domain.Enums;
using project_tracker_domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_domain.Entities
{
    public class ProjectUser : IAuditable
    {
        public Guid UserId { get; set; } // Foreign key to User

        public User User { get; set; } // Navigation property to User

        public Guid ProjectId { get; set; } // Foreign key to Project

        public Project Project { get; set; } // Navigation property to Project

        public ProjectUserRole ProjectRole { get; set; } // Role of the user in the project

        public bool IsActive { get; set; } = true;

        public DateTime? DeactivatedAt { get; set; }

        public Guid? DeactivatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }
    }

}
