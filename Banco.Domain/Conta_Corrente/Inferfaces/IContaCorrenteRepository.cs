namespace Banco.Domain.Conta_Corrente.Inferfaces
{
    public interface IContaCorrenteRepository
    {
        ContaCorrente ObterContaPorNumero(string numeroConta);
        void Atualizar(ContaCorrente contaCorrente);
    }
}