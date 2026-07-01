using project_tracker_domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_application.Interfaces.Repository_Interfaces
{
    public interface ITaskRepository
    {
        // Post
        public Task<ProjectTask> AddTaskAsync(ProjectTask projectTask);

        public Task<ProjectTask> GetTaskAsyncById(Guid taskId);

        public Task<List<ProjectTask>> GetAllTasksAsync(Guid projectId);

        public Task<ProjectTask> DeleteTask(Guid TaskId);


    }
}
