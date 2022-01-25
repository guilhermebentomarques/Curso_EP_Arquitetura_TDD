namespace Banco.Domain.Conta_Corrente
{
    public class ContaCorrente
    {
        private decimal Saldo { get; set; }
        private decimal SaldoBloqueado { get; }
        private decimal SaldoDisponivel { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public ContaCorrente(decimal saldo, decimal saldoBloqueado)
        {
            Saldo = saldo;
            SaldoBloqueado = saldoBloqueado;
            ValidationResult = new ValidationResult();
        }

        public decimal ConsultarSaldo()
        {
            return CalcularSaldoDisponivel();
        }

        public Transacao Depositar(decimal valor)
        {
            if (!PreValidarTransacao(valor, TipoTransacao.Deposito))
                return new Transacao("Não foi possível efetuar o Deposito", TipoRetorno.Erro);

            Saldo += valor;
            return new Transacao("Deposito Efetuado com Sucesso", TipoRetorno.Sucesso);
        }

        public Transacao Sacar(decimal valor)
        {
            if (!PreValidarTransacao(valor, TipoTransacao.Saque))
                return new Transacao("Não foi possível efetuar o Saque", TipoRetorno.Erro);

            Saldo -= valor;
            return new Transacao("Saque Efetuado com Sucesso", TipoRetorno.Sucesso);
        }

        private decimal CalcularSaldoDisponivel()
        {
            SaldoDisponivel = Saldo - SaldoBloqueado;
            return SaldoDisponivel;
        }

        private bool PreValidarTransacao(decimal valor, TipoTransacao tipoTransacao)
        {
            if (valor == 0) 
                ValidationResult.AdicionarErro("Valor 0", "Não é possível realizar transações de valores igual a 0");

            if (valor < 0)
                ValidationResult.AdicionarErro("Valor Negativo", "Não é possível realizar transações de valores negativos");

            if (tipoTransacao != TipoTransacao.Saque) return ValidationResult.EhValido();

            if (CalcularSaldoDisponivel() < valor)
                ValidationResult.AdicionarErro("Valor Negativo", "Não é possível sacar um valor superior aos fundos");

            return ValidationResult.EhValido();
        }
    }
}