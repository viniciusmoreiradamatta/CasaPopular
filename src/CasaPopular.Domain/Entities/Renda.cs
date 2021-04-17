using CasaPopular.Domain.Entities.Base;
using System;

namespace CasaPopular.Domain.Entities
{
    public class Renda : EntityBase
    {
        public Renda()
        {
        }

        public Renda(Guid pessoaId, decimal valor)
        {
            PessoaId = pessoaId;
            Valor = valor;
        }

        public Guid PessoaId { get; private set; }
        public decimal Valor { get; private set; }

        public override void Validar()
        {
            if (Valor < 0)
                throw new Exception("O valor da renda nao pode ser menor que 0!");
        }
    }
}