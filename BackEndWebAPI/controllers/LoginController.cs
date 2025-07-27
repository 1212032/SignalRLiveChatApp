using Microsoft.AspNetCore.Mvc;

namespace SignalRLiveChatApp.BackEndWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        // Placeholder for UserRepository, to be injected via constructor later
        
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // TODO: Use UserRepository to validate credentials

            // Temporary response
            if (request.Username == "test" && request.Password == "password")
            {
                return Ok(new { Message = "Login successful" });
            }

            return Unauthorized(new { Message = "Invalid credentials" });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}