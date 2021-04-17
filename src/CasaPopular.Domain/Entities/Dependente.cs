using CasaPopular.Domain.Enuns;
using System;

namespace CasaPopular.Domain.Entities
{
    public class Dependente : Pessoa
    {
        public Dependente(string nome, DateTime dataNascimento, decimal rendaPessoa) : base(nome, TipoPessoa.Dependente, dataNascimento, rendaPessoa)
        {
        }

        protected override void ValidarDataNascimento()
        {
            if (DataNascimento == DateTime.MinValue)
                throw new Exception("A data de nascimento deve ser preenchida");

            if (DateTime.Now.Date < DataNascimento.Date)
                throw new Exception("A data de nascimento não é valida");
        }

        public bool EhMenorDeIdade() =>
            DateTime.Now.Date < DataNascimento.AddYears(18);
    }
}