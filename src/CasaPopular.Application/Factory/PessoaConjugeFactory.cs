using CasaPopular.Domain.Entities;
using System;

namespace CasaPopular.Application.Factory
{
    public static class PessoaConjugeFactory
    {
        public static Pessoa CriarPessoaConjuge(string nome, DateTime dataNascimento, decimal renda)
        {
            return new Conjuge(nome, dataNascimento, renda);
        }
    }
}