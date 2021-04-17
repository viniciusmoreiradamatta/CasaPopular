using System;

namespace CasaPopular.Domain.Entities
{
    public class Criterio
    {
        protected Criterio()
        {
        }

        public Criterio(string nome, int quantidadePontos)
        {
            ID = Guid.NewGuid();
            Nome = nome;
            QuantidadePontos = quantidadePontos;
        }

        public Guid ID { get; private set; }
        public string Nome { get; set; }
        public int QuantidadePontos { get; set; }
    }
}