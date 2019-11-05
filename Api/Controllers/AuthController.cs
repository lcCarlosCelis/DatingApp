using Api.DTOs.Auth;
using Api.Repositories.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            this.authRepo = authRepo;
        }

        [HttpPost("register")]
        public IActionResult Get(Register register)
        {
            if(authRepo.register(register)){
                return Ok();
            }
            return BadRequest("Ya existe usuario");
        }

        [HttpPost("login")]
        public IActionResult login(Login login)
        {
            var token = authRepo.login(login);
            if(token == null){
                return BadRequest("Revise credenciales");
            }
            return Ok(token);
        }
    }
}