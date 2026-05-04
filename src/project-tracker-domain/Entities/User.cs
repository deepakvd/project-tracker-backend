using project_tracker_domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public UserRole Role { get; set; }

        public ICollection<ProjectUser> ProjectMemberships { get; set; } = new List<ProjectUser>(); // Navigation property to ProjectUser

    }
}
