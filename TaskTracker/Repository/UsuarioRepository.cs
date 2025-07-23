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

        public async Task<Usuarios> GetById(int id)
        {
                var identificatorUser =  await _context.Usuarios.FindAsync(id);
                return identificatorUser;  
        }

        public async Task Update(Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
