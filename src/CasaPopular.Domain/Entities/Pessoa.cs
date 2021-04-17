using CasaPopular.Domain.Entities.Base;
using CasaPopular.Domain.Enuns;
using System;

namespace CasaPopular.Domain.Entities
{
    public class Pessoa : EntityBase
    {
        public Pessoa()
        {
        }

        public Pessoa(string nome, TipoPessoa tipo, DateTime dataNascimento, decimal rendaPessoa)
        {
            Nome = nome;
            Tipo = tipo;
            DataNascimento = dataNascimento;
            RendaPessoa = new Renda(Id, rendaPessoa);

            Validar();
        }

        public string Nome { get; private set; }
        public TipoPessoa Tipo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Renda RendaPessoa { get; private set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("O nome deve ser preenchido");

            ValidarDataNascimento();
        }

        protected virtual void ValidarDataNascimento()
        {
        }
    }
}