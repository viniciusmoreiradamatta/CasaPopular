using CasaPopular.Domain.Entities;
using System;

namespace CasaPopular.Application.Factory
{
    public static class PessoaPretendenteFactory
    {
        public static Pessoa CriarPessoaPretendente(string nome, DateTime dataNascimento, decimal renda)
        {
            return new Pretendente(nome, dataNascimento, renda);
        }
    }
}