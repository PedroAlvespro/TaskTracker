namespace TaskTracker.Notifications
{
    public class Notificacao
    {
        public string Campo { get; set; }
        public string Mensagem { get; set; }
        public TipoNotificacao Tipo { get; set; }

        public Notificacao(string campo, string mensagem, TipoNotificacao tipo)
        {
            Campo = campo;
            Mensagem = mensagem;
            Tipo = tipo;
        }
    }
}
