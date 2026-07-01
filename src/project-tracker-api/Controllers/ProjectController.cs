using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_tracker_api.ResponseModels;
using project_tracker_application.DTOs.ProjectDtos;
using project_tracker_application.Interfaces.Service_Interfaces;
using System.Buffers.Text;

namespace project_tracker_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BaseApiController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ProjectResponseDto>>> CreateProject([FromBody] ProjectCreateDto projectCreateDto)
        {
            // Call the service to create the project
            var result = await _projectService.AddProjectAsync(projectCreateDto);

            return CreatedAtAction(nameof(GetProjectById), new { projectId = result.Id }, new ApiResponse<ProjectResponseDto>
            {
                Success = true,
                Data = result,
                Message = "Project created successfully"
            });
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<ApiResponse<ProjectResponseDto>>> GetProjectById([FromRoute] Guid projectId)
        {
            var result = await _projectService.GetProjectByIdAsync(projectId);

            return Ok(new ApiResponse<ProjectResponseDto>
            {
                Success = true,
                Data = result,
                Message = "Project retrieved successfully"
            });
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ProjectResponseDto>>>> GetProjects([FromQuery] Guid userId)
        {
            var result = await _projectService.GetProjectsAsync(userId);

            return Ok(new ApiResponse<List<ProjectResponseDto>>
            {
                Success = true,
                Data = result,
                Message = "Projects retrieved successfully"
            });

        }

        [HttpPut("{projectId}")]
        public async Task<ActionResult<ApiResponse<ProjectResponseDto>>> UpdateProject([FromRoute] Guid projectId, [FromBody] ProjectUpdateDto projectUpdateDto)
        {
            var result = await _projectService.UpdateProjectAsync(projectId, projectUpdateDto);

            return Ok(new ApiResponse<ProjectResponseDto>
            {
                Success = true,
                Data = result,
                Message = "Project updated successfully"
            });
        }

        [HttpDelete("{projectId}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProject([FromRoute] Guid projectId)
        {
            var result = await _projectService.DeleteProjectAsync(projectId);

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = result,
                Message = "Project deleted successfully"
            });

        }
    }
}
