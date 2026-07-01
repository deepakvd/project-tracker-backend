using project_tracker_domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_application.DTOs.TaskDtos
{
    public class AssignTaskDto
    {
        public Guid TaskId { get; set; }

        public Guid AssigneeId { get; set; }
    }
}
