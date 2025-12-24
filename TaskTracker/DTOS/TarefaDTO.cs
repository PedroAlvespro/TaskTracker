using System.ComponentModel.DataAnnotations;

namespace TaskTracker.DTOS
{
    public class TarefaDTO
    {
        [Required(ErrorMessage = "Seu nome da Tarefa é obrigatório")]
        [StringLength(60, MinimumLength = 11, ErrorMessage = "O seu nome de Tarefa deve ter entre 11 e 60 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sua descrição de Tarefa é obrigatório")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "O seu descrição de tarefa deve ter entre 5 e 60 caracteres")]
        public string Descricao { get; set; }
        public string Tipo { get; set; }
    }
}
