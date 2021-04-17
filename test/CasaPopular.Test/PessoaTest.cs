using CasaPopular.Domain.Entities;
using System;
using Xunit;

namespace CasaPopular.Test
{
    public class PessoaTest
    {
        [Theory]
        [InlineData(0001, 01, 01, 2000)]
        public void Validar_Pessoa_Data_Nascimento_Invalida(int ano, int mes, int dia, decimal renda)
        {
            //Arrange Act && Assert
            Assert.Throws<Exception>(() => new Pretendente("Nome Pessoa", new DateTime(ano, mes, dia), renda));
        }

        [Fact]
        public void Validar_Pessoa_Nome_Invalida()
        {
            //Arrange Act && Assert
            Assert.Throws<Exception>(() => new Pretendente(string.Empty, new DateTime(1999, 01, 01), 3000M));
        }

        [Theory]
        [InlineData("Dependente", 2015, 02, 10, 0)]
        [InlineData("Dependente", 2005, 07, 01, 0)]
        public void Validar_Pessoa_Dependente_Menor_18_Anos(string nome, int ano, int mes, int dia, decimal renda)
        {
            //Arrange
            Dependente pessoa = new(nome, new DateTime(ano, mes, dia), renda);

            //Act && Assert
            Assert.True(pessoa.EhMenorDeIdade());
        }

        [Theory]
        [InlineData("Dependente", 1990, 02, 10, 0)]
        [InlineData("Dependente", 2003, 04, 17, 0)]
        public void Validar_Pessoa_Dependente_Maior_18_Anos(string nome, int ano, int mes, int dia, decimal renda)
        {
            //Arrange
            Dependente pessoa = new(nome, new DateTime(ano, mes, dia), renda);

            //Act && Assert
            Assert.True(!pessoa.EhMenorDeIdade());
        }
    }
}