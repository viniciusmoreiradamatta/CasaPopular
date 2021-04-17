using CasaPopular.Domain.Enuns;
using System;

namespace CasaPopular.Domain.Entities
{
    public class Pretendente : Pessoa
    {
        public Pretendente(string nome, DateTime dataNascimento, decimal rendaPessoa) : base(nome, TipoPessoa.Pretendente, dataNascimento, rendaPessoa)
        {
        }

        protected override void ValidarDataNascimento()
        {
            if (DataNascimento == DateTime.MinValue)
                throw new Exception("A data de nascimento deve ser preenchida");

            if (DateTime.Now.Date < DataNascimento.Date)
                throw new Exception("A data de nascimento não é valida");

            if (EhMaiorDeIdade())
                throw new Exception("Pretendente deve ser maior de idade");
        }

        public bool EhMaiorDeIdade() => DateTime.Now.Date.AddYears(-18) <= DataNascimento;
    }
}