using Microsoft.EntityFrameworkCore;
using TaskTracker.Data;
using TaskTracker.Models;
using TaskTracker.Repository.Interfaces;

namespace TaskTracker.Repository
{
    public class UsuarioRepository : IUsuario
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext conxtext) 
        { 
            _context = conxtext;
        }
        public async Task Create(Usuarios usuario)
        {
           _context.Usuarios.Add(usuario);
           await _context.SaveChangesAsync();
        }

        public async Task Delete(Usuarios usuario)
        {
            _context.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Tarefa> GetById(int id)
        {
            try
            {
                var identificador = _context.Usuarios.FirstOrDefaultAsync(c => c.Id == id);
                return identificador;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao salvar no banco: " + ex.InnerException?.Message);
            }
        }

        public async Task Update(Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
