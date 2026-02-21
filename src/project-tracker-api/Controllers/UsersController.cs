using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace project_tracker_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController() { }

        public ActionResult<> Login(LoginRequest request)
        {
            // Implement login logic here
            return Ok();
    }
}
