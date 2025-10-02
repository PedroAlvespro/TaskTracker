using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop.Infrastructure;
using Org.BouncyCastle.Crypto.Generators;
using System.IdentityModel.Tokens.Jwt;
using TaskTracker.Data;
using TaskTracker.DTOS;
using TaskTracker.Helpers;
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

        public async Task<string> Authenticate(LoginDTO dto)
        {
            var user = await _usuarioRepository.GetByEmail(dto.Email);

            if (user == null || dto.Password != user.Senha)
            {
                throw new Exception("Credenciais inválidas");
            }

            var token = JwtHelper.GenerateToken(user, _configuration);
            return token;
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
