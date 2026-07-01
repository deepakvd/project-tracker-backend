using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_application.DTOs.TaskDtos
{
    public class TaskUpdateDto
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
