using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Data;
using TaskTracker.DTOS;
using TaskTracker.Services;

namespace TaskTracker.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _userService;
        private readonly AppDbContext _context;

        public UsuarioController(UsuarioService userService, AppDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> CreateUser(CreateUserDTO dto)
        {
            try
            {
                await _userService.CreateUser(dto);
                return Ok(new { message = "Usuário criado com sucesso!" });
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao salvar no banco: " + ex.InnerException?.Message);
            }
        }

    }
}
