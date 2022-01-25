using Banco.Domain.Conta_Corrente.Inferfaces;

namespace Banco.Domain.Conta_Corrente.Services
{
    public class ContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public Transacao EfetuarDeposito(string nroConta, decimal valor)
        {
            var conta = _contaCorrenteRepository.ObterContaPorNumero(nroConta);
            var transacao = conta.Depositar(valor);

            if(transacao.TipoRetorno == TipoRetorno.Sucesso)
                _contaCorrenteRepository.Atualizar(conta);

            return transacao;
        }
    }
}