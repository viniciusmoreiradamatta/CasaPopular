using CasaPopular.Domain.Entities;
using System;

namespace CasaPopular.Application.Factory
{
    public static class PessoaDependenteFactory
    {
        public static Pessoa CriarPessoaDependente(string nome, DateTime dataNascimento, decimal renda)
        {
            return new Dependente(nome, dataNascimento, renda);
        }
    }
}