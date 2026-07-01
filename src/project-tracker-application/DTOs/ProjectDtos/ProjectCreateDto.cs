using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_application.DTOs.ProjectDtos
{
    public class ProjectCreateDto
    {
        public required string Name { get; set; }

        public required string Description { get; set; }
    }
}
