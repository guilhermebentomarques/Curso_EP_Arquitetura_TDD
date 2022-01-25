using System.Collections.Generic;
using System.Linq;

namespace Banco.Domain.Conta_Corrente
{
    public class ValidationResult
    {
        public Dictionary<string, string> Erros { get; set; }

        public ValidationResult()
        {
            Erros = new Dictionary<string, string>();
        }

        public void AdicionarErro(string erro, string mensagem)
        {
            Erros.Add(erro, mensagem);
        }

        public bool EhValido()
        {
            return !Erros.Any();
        }
    }
}