using Banco.Domain.Conta_Corrente;
using Xunit;

namespace Banco.Domain.Tests.Conta_Corrente
{
    /// Feature - Conta Corrente
    /// Consultar Saldo
    /// Realizar Deposito
    ///     Nao pode depositar valor invalido (menor ou igual a 0)
    /// Realizar saque
    ///     Nao pode sacar valor invalido (menor ou igual a 0)
    ///     Nao pode sacar acima do limite

    public class ContaCorrenteTests
    {
        private decimal _saldoInicial = 50;
        private decimal _saldoBloqueado = 10;
        private decimal _saldoDisponivel;
        private ContaCorrente _contaCorrente;

        public ContaCorrenteTests()
        {
            _contaCorrente = new ContaCorrente(_saldoInicial, _saldoBloqueado);
            _saldoDisponivel = _saldoInicial - _saldoBloqueado;
        }

        // AAA - Arrange - Act - Assert
        [Fact(DisplayName = "Consultar Saldo - Saldo Deve Estar Consistente")]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_ConsultarSaldo_SaldoDeveEstarConsistente()
        {
            // Act
            var saldo = _contaCorrente.ConsultarSaldo();

            // Assert
            Assert.Equal(_saldoDisponivel, saldo);
        }

        [Fact(DisplayName = "Depositar Dinheiro - Deve Retornar Saldo Atualizado Com Deposito")]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_RealizarDeposito_DeveRetornarSaldoAtualizadoComDeposito()
        {
            // Arrange
            var _deposito = 50M;

            // Act
            var transacao = _contaCorrente.Depositar(_deposito);

            // Assert
            var saldo = _contaCorrente.ConsultarSaldo();
            Assert.Equal(_deposito + _saldoDisponivel, saldo);
            Assert.Equal(TipoRetorno.Sucesso, transacao.TipoRetorno);
            Assert.Equal("Deposito Efetuado com Sucesso", transacao.Mensagem);
        }

        [Theory(DisplayName = "Depositar Valor Menor Igual Zero - Validar Transacao Com Falha")]
        [InlineData(-10)]
        [InlineData(0)]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_DepositarValorMenorIgualZero_ValidarTransacaoComFalha(decimal deposito)
        {
            // Act
            var transacao = _contaCorrente.Depositar(deposito);

            // Assert
            var saldo = _contaCorrente.ConsultarSaldo();
            Assert.Equal(_saldoDisponivel, saldo);
            Assert.Equal("Não foi possível efetuar o Deposito", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.TipoRetorno);
        }

        [Fact(DisplayName = "Saque - Validar Transacao Com Sucesso")]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_Saque_ValidarTransacaoComSucesso()
        {
            // Arrange
            var saque = 10;

            // Act
            var transacao = _contaCorrente.Sacar(saque);

            // Assert
            var saldo = _contaCorrente.ConsultarSaldo();
            Assert.Equal(_saldoDisponivel - saque, saldo);
            Assert.Equal("Saque Efetuado com Sucesso", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Sucesso, transacao.TipoRetorno);
        }

        [Theory(DisplayName = "Sacar Valor Negativo Ou Zero - Retornar Transacao Com Falha")]
        [InlineData(0)]
        [InlineData(-10)]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_SacarValorNegativoOuZero_DeveRetornarTransacaoComFalha(decimal saque)
        {
            // Act
            var transacao = _contaCorrente.Sacar(saque);

            // Assert
            var saldo = _contaCorrente.ConsultarSaldo();
            Assert.Equal(_saldoDisponivel, saldo);
            Assert.Equal("Não foi possível efetuar o Saque", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.TipoRetorno);
        }

        [Fact(DisplayName = "Sacar Valor Acima do Limite - Retornar Transacao Com Falha")]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_SacarValorAcimaDoLimite_RetornarTransacaoComFalha()
        {
            // Arrange
            var saque = 100;

            // Act
            var transacao = _contaCorrente.Sacar(saque);

            // Assert
            var saldo = _contaCorrente.ConsultarSaldo();
            Assert.Equal(_saldoDisponivel, saldo);
            Assert.Equal("Não foi possível efetuar o Saque", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.TipoRetorno);
        }
    }
}