using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.JSInterop.Infrastructure;
using System.Reflection.Metadata.Ecma335;
using TaskTracker.DTOS;
using TaskTracker.Models;
using TaskTracker.Repository;
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
                Tipo = dto.Tipo,
                Concluida = false,
                UsuarioId = dto.UsuarioId
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
                Urgente = tarefa.Urgente,
                Descricao = tarefa.Descricao,
                DataConclusao = tarefa.DataConclusao
            };
        }

        public async Task<List<Tarefa>> ListarTarefasdoUsuario(int usuarioid)
        {
           var tarefas = await _tarefaRepository.GetAll(usuarioid);
            return tarefas.ToList();
        }

        public async Task<Tarefa> TarefaConcluida(int tarefaId)
        {
            // Buscar a tarefa no banco
            var tarefa = await _tarefaRepository.GetById(tarefaId);

            if (tarefa == null)
                throw new ArgumentException("Tarefa não encontrada.");

            // Marcar como concluída
            tarefa.Concluida = true;
            tarefa.DataConclusao = DateTime.Now;

            // Atualizar no banco
            await _tarefaRepository.Update(tarefa);

            return tarefa;
        }


        public async Task Delete(int id)
        {
            var remove = await _tarefaRepository.GetById(id);

            if (remove == null)
                throw new Exception("Tarefa não encontrada");

            await _tarefaRepository.Delete(remove);
        }
       


    }
}
