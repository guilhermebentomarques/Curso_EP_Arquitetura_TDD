using System.Linq.Expressions;
using Banco.Domain.Conta_Corrente;
using Banco.Domain.Conta_Corrente.Inferfaces;
using Banco.Domain.Conta_Corrente.Services;
using Moq;
using Xunit;

namespace Banco.Domain.Tests.Conta_Corrente
{
    public class ContaCorrenteServiceTests
    {
        [Fact(DisplayName = "Deposito em Conta")]
        [Trait("Categoria", "Operacões ContaCorrenteService")]
        public void ContaCorrenteService_EfetuarDeposito_DeveRetornarTransacaoComSucesso()
        {
            // Arrange
            var contaCorrente = new ContaCorrente(50, 0);
            var deposito = 500M;

            var repo = new Mock<IContaCorrenteRepository>();
            repo.Setup(r => r.ObterContaPorNumero("12345")).Returns(contaCorrente);

            var contaCorrenteService = new ContaCorrenteService(repo.Object);

            // Act
            var transacao = contaCorrenteService.EfetuarDeposito("12345", deposito);

            // Assert
            repo.Verify(r => r.Atualizar(contaCorrente), Times.Once);
            Assert.Equal("Deposito Efetuado com Sucesso", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Sucesso, transacao.TipoRetorno);
        }
    }
}