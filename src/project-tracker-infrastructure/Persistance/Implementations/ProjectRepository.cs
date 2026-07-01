using Microsoft.EntityFrameworkCore;
using project_tracker_application.Interfaces.RepositoryInterfaces;
using project_tracker_domain.Entities;

namespace project_tracker_infrastructure.Persistance.Implementations
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            return project;
        }

        public async Task<bool> DeleteProjectAsync(Guid projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project is null) return false;
            project.IsDeleted = true;
            return true;
        }

        public async Task<Project> GetProjectByIdAsync(Guid projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project is null)
            {
                throw new KeyNotFoundException($"Project with id '{projectId}' was not found.");
            }

            return project;
        }

        public async Task<List<Project>> GetProjectsAsync(Guid UserId)
        {
            List<Project> projects = await _context.Projects.Where(p => p.ProjectUsers
                                            .Any(pu => pu.UserId == UserId))
                                            .ToListAsync();
            return projects;
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            // Replace the existing project with the updated one
            _context.Projects.Update(project);
            return project;
        }
    }
}