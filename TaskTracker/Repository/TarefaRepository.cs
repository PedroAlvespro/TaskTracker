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
            _context.Tarefa.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Tarefa tarefa)
        {
            _context.Tarefa.Remove(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tarefa>> GetAll()
        {
            return await _context.Tarefa.ToListAsync();
        }

        public async Task<Tarefa> GetById(int id)
        {
            var identificator = await _context.Tarefa.FindAsync(id);
            return identificator;
        }

        public async Task Update(Tarefa tarefa)
        {
            _context.Tarefa.Update(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
