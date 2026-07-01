using project_tracker_application.DTOs.ProjectDtos;
using project_tracker_application.Interfaces.RepositoryInterfaces;
using project_tracker_application.Interfaces.Service_Interfaces;
using project_tracker_domain.Entities;

namespace project_tracker_application.Implementations.ProjectService
{
    public class ProjectService : IProjectService
    {

        IProjectRepository projectRepositry;
        IUnitOfWork unitOfWork;

        public ProjectService(IProjectRepository _projectRepositry, IUnitOfWork _unitOfWork)
        {
            projectRepositry = _projectRepositry;
            unitOfWork = _unitOfWork;
        }

        public async Task<ProjectResponseDto> AddProjectAsync(ProjectCreateDto projectCreateDto)
        {
            // Map the ProjectCreateDto to a Project entity
            Project project = MapTo(projectCreateDto);

            Project createdProject =
                await projectRepositry.AddProjectAsync(project);

            await unitOfWork.SaveChangesAsync();

            ProjectResponseDto projectResponseDto = MapTo(createdProject);
            return projectResponseDto;
        }

        public async Task<bool> DeleteProjectAsync(Guid ProjectId)
        {
            // Call the repository to delete the project
            Project project = await projectRepositry.GetProjectByIdAsync(ProjectId);
            project.IsDeleted = true;

            await unitOfWork.SaveChangesAsync();

            return true;


        }

        public async Task<ProjectResponseDto> GetProjectByIdAsync(Guid ProjectId)
        {
            Project project = await projectRepositry.GetProjectByIdAsync(ProjectId);

            if (project == null)
            {
                return null;
            }

            ProjectResponseDto projectResponseDto = MapTo(project);

            return projectResponseDto;

        }

        public async Task<List<ProjectResponseDto>> GetProjectsAsync(Guid UserId)
        {
            List<Project> projects = await projectRepositry.GetProjectsAsync(UserId);
            if (projects == null || projects.Count == 0)
            {
                return new List<ProjectResponseDto>();

            }
            else
            {
                List<ProjectResponseDto> projectResponseDtos = projects.Select(p => MapTo(p)).ToList();
                return projectResponseDtos;
            }
        }

        public async Task<ProjectResponseDto> UpdateProjectAsync(Guid projectId, ProjectUpdateDto projectUpdateDto)
        {
            Project ExistingProject = await projectRepositry.GetProjectByIdAsync(projectId);

            if (ExistingProject == null || ExistingProject.IsDeleted)
            {
                return null;
            }

            if (projectUpdateDto.Name is not null)
                ExistingProject.Name = projectUpdateDto.Name;

            if (projectUpdateDto.Description is not null)
                ExistingProject.Description = projectUpdateDto.Description;


            await unitOfWork.SaveChangesAsync();

            return MapTo(ExistingProject);


        }

        public project_tracker_domain.Entities.Project MapTo(ProjectCreateDto projectCreateDto)
        {
            return new project_tracker_domain.Entities.Project
            {
                Id = Guid.NewGuid(),
                Name = projectCreateDto.Name,
                Description = projectCreateDto.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public ProjectResponseDto MapTo(project_tracker_domain.Entities.Project projectCreateDto)
        {
            return new ProjectResponseDto
            {
                Id = projectCreateDto.Id,
                Name = projectCreateDto.Name,
                Description = projectCreateDto.Description,
                CreatedAt = projectCreateDto.CreatedAt,
                UpdatedAt = projectCreateDto.UpdatedAt
            };
        }
    }
}
