using TaskTracker.Enums;

namespace TaskTracker.DTOS
{
    public class TarefaResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        public DateTime? DataConclusao { get; set; }

    }
}
