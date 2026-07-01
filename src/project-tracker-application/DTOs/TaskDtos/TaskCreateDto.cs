using project_tracker_domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_application.DTOs.TaskDtos
{
    public class TaskCreateDto
    {
        public required string Title { get; set; }

        public string? Description { get; set; }

        public Guid? AssigneeId { get; set; }

    }
}
