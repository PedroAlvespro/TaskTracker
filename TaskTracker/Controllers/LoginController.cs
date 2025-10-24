using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using TaskTracker.Data;
using TaskTracker.DTOS;
using TaskTracker.Exceptions;
using TaskTracker.Helpers;
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

            if (DtoNullHelper.dtoVazioOuNulo(dto))
                throw new AppException("Email e senha são obrigatórios.", HttpStatusCode.BadRequest);

            var token = await _userService.Authenticate(dto);

            if (token == null)
                throw new AppException("Credenciais inválidas. Verifique o email e a senha.", HttpStatusCode.Unauthorized);

            return Ok(new { Token = token });
        }


    }
}
