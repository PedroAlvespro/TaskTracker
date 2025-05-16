using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TaskTracker.Data;
using TaskTracker.DTOS;
using TaskTracker.Services;

namespace TaskTracker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaService _service;
        private readonly AppDbContext _context;

        public TarefaController(TarefaService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }
        
        [HttpPost]
        public async Task<IActionResult> CriarTarefa(TarefaDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nome) || string.IsNullOrWhiteSpace(dto.Descricao)) return BadRequest("Nome e descrição são obrigatórios.");

            var novaTarefa = await _service.Create(dto); 
            return Ok(novaTarefa);
        }

    }
}
