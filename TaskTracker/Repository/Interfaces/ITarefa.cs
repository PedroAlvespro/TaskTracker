using TaskTracker.Models;

namespace TaskTracker.Repository.Interfaces
{
    public interface ITarefa
    {
        public Task Create(Tarefa tarefa);
        public Task Update(Tarefa tarefa);
        public Task Delete(Tarefa tarefa);
        public Task<List<Tarefa>> GetAll();
        public Task<Tarefa> GetById(int id);
        public Task<IEnumerable<Tarefa>> GetByDateAsync(DateTime date);


    }
}

