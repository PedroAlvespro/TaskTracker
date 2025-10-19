using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskTracker.Data;
using TaskTracker.DTOS;
using TaskTracker.Services;

namespace TaskTracker.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService _userService;
        private readonly AppDbContext _context;

        public LoginController(UsuarioService userservice, AppDbContext context)
        {
            _userService = userservice;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                var token = await _userService.Authenticate(dto);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { Error = ex.Message });
            }
        }


    }
}
