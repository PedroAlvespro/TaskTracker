using TaskTracker.Models;

namespace TaskTracker.Repository.Interfaces
{
    public interface IUsuario
    {
        public Task Create(Usuarios usuario);
        public Task Update(Usuarios usuario);
        public Task Delete(Usuarios usuario);
        public Task<Tarefa> GetById(int id);
    }
}
