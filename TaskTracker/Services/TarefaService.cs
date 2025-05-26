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

        public async Task<TarefaResponseDTO> Update(int id, TarefaDTO dto)
        {
            var tarefa = await _tarefaRepository.GetById(id);
            if (tarefa == null) throw new Exception("Tarefa não encontrada");

            tarefa.Nome = dto.Nome;
            tarefa.Descricao = dto.Descricao;
            tarefa.DataConclusao = DateTime.Now;

            await _tarefaRepository.Update(tarefa);

            return new TarefaResponseDTO
            {
                Id = tarefa.Id,
                Nome = tarefa.Nome,
                Descricao = tarefa.Descricao,
                DataConclusao = tarefa.DataConclusao
            };
        }

        public async Task Delete(int id)
        {
            var remove = await _tarefaRepository.GetById(id);

            if (remove == null)
                throw new Exception("Tarefa não encontrada");

            await _tarefaRepository.Delete(remove);
        }
        public async Task<List<Tarefa>> GetAll()
        {
            var tarefas = await _tarefaRepository.GetAll() ?? new List<Tarefa>();
            return tarefas;
        }
    }
}
