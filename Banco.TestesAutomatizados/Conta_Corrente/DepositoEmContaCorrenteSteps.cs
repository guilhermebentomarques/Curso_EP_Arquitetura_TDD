using System;
using Banco.Domain.Conta_Corrente;
using TechTalk.SpecFlow;
using Xunit;

namespace Banco.TestesAutomatizados.Conta_Corrente
{
    [Binding]
    public class DepositoEmContaCorrenteSteps
    {
        private ContaCorrente contaCorrente;
        private decimal valorDeposito;
        private decimal saldoInicial;
        private Transacao retornoTransacao;

        public DepositoEmContaCorrenteSteps()
        {
            saldoInicial = 50;
            contaCorrente = new ContaCorrente(saldoInicial, 0);
            valorDeposito = 500;
        }

        [Given(@"Uma conta corrente ativa")]
        public void DadoUmaContaCorrenteAtiva()
        {
            Assert.NotNull(contaCorrente);
        }
        
        [When(@"O valor for depositado")]
        public void QuandoOValorForDepositado()
        {
            retornoTransacao = contaCorrente.Depositar(valorDeposito);
        }
        
        [When(@"o valor é superior a zero")]
        public void QuandoOValorESuperiorAZero()
        {
            Assert.True(valorDeposito > 0);
        }
        
        [When(@"O valor é negativo ou igual zero")]
        public void QuandoOValorENegativoOuIgualZero()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"O valor é acima do limite")]
        public void QuandoOValorEAcimaDoLimite(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Receberei uma mensagem de deposito realizado com sucesso")]
        public void EntaoRecebereiUmaMensagemDeDepositoRealizadoComSucesso()
        {
            Assert.Equal("Deposito Efetuado com Sucesso", retornoTransacao.Mensagem);
        }
        
        [Then(@"Receberei uma mensagem de falha na transacao")]
        public void EntaoRecebereiUmaMensagemDeFalhaNaTransacao()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Receberei uma mensagem de valor acima do limite")]
        public void EntaoRecebereiUmaMensagemDeValorAcimaDoLimite()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
