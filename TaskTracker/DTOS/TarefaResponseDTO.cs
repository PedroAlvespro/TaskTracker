namespace TaskTracker.DTOS
{
    public class TarefaResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Urgente { get; set; }
        public DateTime? DataConclusao { get; set; }

    }
}
