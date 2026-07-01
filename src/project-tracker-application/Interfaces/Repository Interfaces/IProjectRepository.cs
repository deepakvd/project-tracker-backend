using project_tracker_domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_application.Interfaces.RepositoryInterfaces
{
    public interface IProjectRepository
    {

        // Get Project by Id
        public Task<Project> GetProjectByIdAsync(Guid projectId);

        // Get all projects
        public Task<List<Project>> GetProjectsAsync(Guid UserId);

        // Add a new project
        public Task<Project> AddProjectAsync(Project project);

        // Update an existing project
        public Task<Project> UpdateProjectAsync(Project project);

        // Delete a project
        public Task<bool> DeleteProjectAsync(Guid projectId);

    }
}
