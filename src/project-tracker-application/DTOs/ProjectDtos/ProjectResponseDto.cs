using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_application.DTOs.ProjectDtos
{
    public class ProjectResponseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }



    }
}
