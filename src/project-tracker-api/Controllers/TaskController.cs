using Microsoft.AspNetCore.Mvc;
using project_tracker_application.DTOs.TaskDtos;

namespace project_tracker_api.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/tasks")]
    public class TaskController : BaseApiController
    {

        [HttpPost]
        public async Task<ActionResult<TaskResponseDto>> Create(Guid projectId, [FromBody] TaskCreateDto dto)
        {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetAll(Guid projectId)
        {
            return null;
        }


        [HttpGet("{taskId}")]
        public async Task<ActionResult<TaskResponseDto>> GetById(Guid projectId, Guid taskId){
            return null;
        }


        [HttpPut("{taskId}")]
        public async Task<ActionResult<TaskResponseDto>> Update(Guid projectId, Guid taskId, [FromBody] TaskUpdateDto dto)

        {
            return null;
        }

        [HttpPatch("{taskId}/assignUser")]
        public async Task<ActionResult<TaskResponseDto>> AssignUser(Guid projectId, Guid taskId, [FromBody] AssignTaskDto dto)
        {
            return null;
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> Delete(Guid projectId, Guid taskId)
        {
            return null;
        }
            
    }
}