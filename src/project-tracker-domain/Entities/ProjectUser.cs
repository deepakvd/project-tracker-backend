using project_tracker_domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_domain.Entities
{
    public class ProjectUser : BaseEntity
    {
        public Guid UserId { get; set; } // Foreign key to User

        public User User { get; set; } // Navigation property to User

        public Guid ProjectId { get; set; } // Foreign key to Project

        public Project Project { get; set; } // Navigation property to Project

        public ProjectUserRole ProjectRole { get; set; } // Role of the user in the project
        
    }

}
