using TaskTracker.Data;
using TaskTracker.Models;
using TaskTracker.Repository;
using TaskTracker.Repository.Interfaces;

namespace TaskTracker.Services
{
    public class UsuarioService 
    {
        private readonly IUsuario _usuarioRepository;

        public UsuarioService(IUsuario usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        

        
    }
}
