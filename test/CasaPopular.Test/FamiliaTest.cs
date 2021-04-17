using CasaPopular.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace CasaPopular.Test
{
    public class FamiliaTest
    {
        [Fact]
        public void Validar_Familia_Com_Mais_De_Um_Conjuge()
        {
            //Arrange
            Pretendente Pretendente = new("Pretendente", new DateTime(1990, 01, 01), 2555M);

            Conjuge Conjuge = new("Conjuge", new DateTime(1990, 01, 01), 2555M);

            Conjuge Conjuge2 = new("Conjuge", new DateTime(1990, 01, 01), 2555M);

            Dependente Dependente = new("Dependente", new DateTime(2005, 01, 01), 2555M);

            List<Pessoa> lista = new()
            {
                Pretendente,
                Conjuge,
                Conjuge2,
                Dependente
            };

            Familia Familia = new(0, lista);

            //Act && Assert
            Assert.Throws<Exception>(() => Familia.Validar());
        }

        [Fact]
        public void Validar_Quantidade_Dependentes_Validos()
        {
            //Arrange
            Pretendente Pretendente = new("Pretendente", new DateTime(1990, 01, 01), 2555M);

            Conjuge Conjuge = new("Conjuge", new DateTime(1990, 01, 01), 2555M);

            Dependente Dependente = new("Dependente", new DateTime(2005, 01, 01), 0);

            Dependente Dependente2 = new("Dependente", new DateTime(2015, 01, 01), 0);

            Dependente Dependente3 = new("Dependente", new DateTime(2015, 01, 01), 0);

            Dependente Dependente4 = new("Dependente", new DateTime(1990, 01, 01), 0);

            List<Pessoa> lista = new()
            {
                Pretendente,
                Conjuge,
                Dependente2,
                Dependente3,
                Dependente4,
                Dependente
            };

            Familia Familia = new(0, lista);

            //Act && Assert
            Assert.True(Familia.TotalDependentes() == 3);
        }
    }
}