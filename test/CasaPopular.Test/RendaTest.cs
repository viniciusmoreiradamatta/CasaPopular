using CasaPopular.Domain.Entities;
using System;
using Xunit;

namespace CasaPopular.Test
{
    public class RendaTest
    {
        [Fact]
        public void Validar_Valor_Renda_Invalido()
        {
            //Arrange
            Renda renda = new(Guid.NewGuid(), -3);

            //Act && Assert
            Assert.Throws<Exception>(() => renda.Validar());
        }
    }
}