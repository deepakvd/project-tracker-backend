using project_tracker_domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();

        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();



    }

}
