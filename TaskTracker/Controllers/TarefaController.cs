using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TaskTracker.Data;
using TaskTracker.DTOS;
using TaskTracker.Services;

namespace TaskTracker.Controllers
{
    [Route("[controller]")]
    [Authorize]
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

            try
            {
                var novaTarefa = await _service.Create(dto);
                return Ok(novaTarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> BuscarTarefa()
        {
            try
            {
                var TarefaBuscada = await _service.GetAll();
                return Ok(TarefaBuscada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AlterarTarefa(int id, TarefaDTO dto)
        {
            try
            {
                var update = await _service.Update(id, dto);
                return Ok(update);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}