using TaskTracker.DTOS;
using TaskTracker.Models;
using TaskTracker.Repository.Interfaces;

namespace TaskTracker.Services
{
    public class TarefaService
    {
        private readonly ITarefa _tarefaRepository;

        public TarefaService(ITarefa tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Tarefa> Create(TarefaDTO dto)
        {
            var novaTarefa = new Tarefa
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                DataCriacao = DateTime.Now,
                //DataConclusao = dto.DataConclusao,
                Concluida = false
            };
            await _tarefaRepository.Create(novaTarefa);
            return novaTarefa;
        }

        public async Task Update(Tarefa tarefa)
        {
            await _tarefaRepository.Update(tarefa);
        }

        public async Task Delete(Tarefa tarefa)
        {
            await _tarefaRepository.Delete(tarefa);
        }

        public async Task<List<Tarefa>> GetAll()
        {
            return await _tarefaRepository.GetAll();
        }
    }
}
