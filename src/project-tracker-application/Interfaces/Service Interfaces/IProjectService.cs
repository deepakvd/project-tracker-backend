using project_tracker_application.DTOs.ProjectDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace project_tracker_application.Interfaces.Service_Interfaces
{
    public interface IProjectService
    {
        public Task<ProjectResponseDto> GetProjectByIdAsync(Guid projectId);

        public Task<List<ProjectResponseDto>> GetProjectsAsync(Guid UserId);

        public Task<ProjectResponseDto> AddProjectAsync(ProjectCreateDto projectCreateDto);

        public Task<bool> DeleteProjectAsync(Guid ProjectId);

        public Task<ProjectResponseDto> UpdateProjectAsync(Guid projectId, ProjectUpdateDto projectUpdateDto);


    }
}
