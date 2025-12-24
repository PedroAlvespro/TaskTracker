namespace TaskTracker.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public int Status { get; set; }

        // relacionamento com o usuario:
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }
   
    }
}
