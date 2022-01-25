using Xunit;

namespace Calculos.Tests
{
    public class CalculadoraTests
    {
        // AAA => Arrange Act Assert

        [Fact(DisplayName = "Calculo de Soma")]
        [Trait("Categoria", "Somas")]
        public void Calculadora_Adicionar_DeveRetornarResultadoCorreto()
        {
            Assert.Equal(4, Calculadora.Adicao(2, 2));
        }

        [Fact(DisplayName = "Calculo de Subtração")]
        [Trait("Categoria", "Subtrações")]
        public void Calculadora_Subtrair_DeveRetornarResultadoCorreto()
        {
            Assert.Equal(2, Calculadora.Subtracao(4, 2));
        }

        [Theory(DisplayName = "Validacoes de CPF")]
        [Trait("Categoria", "Validacoes")]
        [InlineData("30390600821")]
        [InlineData("30390600811")]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("3039060082112")]
        [InlineData("30390600")]
        [InlineData("303.906.008-22")]
        [InlineData("00446142337")]
        public void Cpf_ValidarCpf_RecusarCpfsValidos(string cpf)
        {
            Assert.False(CPF.Validar(cpf));
        }

        [Theory(DisplayName = "Validacoes de CPF")]
        [Trait("Categoria", "Validacoes")]
        [InlineData("30390600822")]
        [InlineData("57462189879")]
        [InlineData("02755382228")]
        [InlineData("2755382228")]
        public void Cpf_ValidarCpf_RecusarCpfsInvalidos(string cpf)
        {
            Assert.True(CPF.Validar(cpf));
        }
    }
}