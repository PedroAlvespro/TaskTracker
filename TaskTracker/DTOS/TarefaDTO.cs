namespace TaskTracker.DTOS
{
    public class TarefaDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public bool Urgente { get; set; }
        public int UsuarioId { get; set; }

        public bool VazioOuNulo()
        {
            return string.IsNullOrEmpty(Nome)
                && string.IsNullOrEmpty(Descricao);
        }

    }
}
