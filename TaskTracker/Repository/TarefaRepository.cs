using Microsoft.EntityFrameworkCore;
using TaskTracker.Data;
using TaskTracker.Models;
using TaskTracker.Repository.Interfaces;

namespace TaskTracker.Repository
{
    public class TarefaRepository : ITarefa
    {
        public readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Tarefa tarefa)
        {
            try
            {
                _context.Tarefa.Add(tarefa);
                await _context.SaveChangesAsync();
            } catch(DbUpdateException ex)
            {
                throw new Exception("Erro ao salvar no banco" +ex.InnerException?.Message);
            }
            
        }

        public async Task Delete(Tarefa tarefa)
        {
            _context.Tarefa.Remove(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tarefa>> GetAll(int usuarioId)
        {
            try
            {
                GetById(usuarioId);
            }
            catch (Exception ex) 
            {
                throw new Exception("Usuario não encontrado");           
            }

            var tarefas = await _context.Tarefa.
                Where(t => t.UsuarioId == usuarioId).ToListAsync();
             
            return tarefas;

        }

        public async Task<IEnumerable<Tarefa>> GetByDateAsync(DateTime date)
        {
            return await _context.Tarefa.
                Where(t => t.DataConclusao.Date == date.Date).
                ToListAsync();
        }

        public async Task<Tarefa> GetById(int id)
        {
            var identificator = await _context.Tarefa.FindAsync(id);
            return identificator;
        }

        public async Task<IEnumerable<Tarefa>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Tarefa
                .Where(t => t.UsuarioId == usuarioId)
                .Include(t => t.Usuario)
                .ToListAsync();
        }

        public async Task Update(Tarefa tarefa)
        {
            _context.Tarefa.Update(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
