using Microsoft.AspNetCore.Mvc;
using WebApiYoutube.Application.Services;

namespace WebApiYoutube.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "filipe" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Domain.Models.EmployeeAggregate.Employee());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}
