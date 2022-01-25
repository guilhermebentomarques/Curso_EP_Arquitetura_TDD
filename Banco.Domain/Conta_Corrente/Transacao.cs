namespace Banco.Domain.Conta_Corrente
{
    public class Transacao
    {
        public string Mensagem { get; private set; }
        public TipoRetorno TipoRetorno { get; private set; }

        public Transacao(string mensagem, TipoRetorno tipoRetorno)
        {
            Mensagem = mensagem;
            TipoRetorno = tipoRetorno;
        }
    }
}