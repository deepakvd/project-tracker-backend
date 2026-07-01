using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_tracker_api.ResponseModels;

namespace project_tracker_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected ActionResult<ApiResponse<T>> Success<T>(T data, string? message = null)
        {
            return Ok(new ApiResponse<T>(data: data, success: true, message: message));
        }

        protected ActionResult<ApiResponse<T>> Failure<T>(string message, Dictionary<string, string>? errors = null)
        {
            return BadRequest(new ApiResponse<T>(data: default, success: false, message: message, errors: errors));
        }
    }
}
