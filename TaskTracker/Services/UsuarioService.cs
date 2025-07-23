using Microsoft.Extensions.Configuration;
using TaskTracker.Data;
using TaskTracker.DTOS;
using TaskTracker.Models;
using TaskTracker.Repository;
using TaskTracker.Repository.Interfaces;

namespace TaskTracker.Services
{
    public class UsuarioService
    {
        private readonly IUsuario _usuarioRepository;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuario usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        public async Task<ResponseUserDTO> CreateUser(CreateUserDTO dto)
        {
            var newUser = new Usuarios
            {
                Name = dto.Name,
                Email = dto.Email,
                Senha = dto.Senha
            };

            await _usuarioRepository.Create(newUser);

            return new ResponseUserDTO
            {
                Name = dto.Name,
                Email = dto.Email
            };




        }
    }
}
