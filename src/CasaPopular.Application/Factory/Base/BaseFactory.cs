using CasaPopular.Application.ViewModels;
using CasaPopular.Domain.Entities;
using CasaPopular.Domain.Enuns;

namespace CasaPopular.Application.Factory.Base
{
    public class BaseFactory
    {
        public static Pessoa CriarPessoas(CadastroPessoaViewModel viewModel)
        {
            return (TipoPessoa)viewModel.Tipo switch
            {
                TipoPessoa.Conjuge => PessoaConjugeFactory.CriarPessoaConjuge(viewModel.Nome, viewModel.DataNascimento, viewModel.Renda),
                TipoPessoa.Dependente => PessoaDependenteFactory.CriarPessoaDependente(viewModel.Nome, viewModel.DataNascimento, viewModel.Renda),
                TipoPessoa.Pretendente => PessoaPretendenteFactory.CriarPessoaPretendente(viewModel.Nome, viewModel.DataNascimento, viewModel.Renda),
                _ => throw new System.InvalidOperationException("Tipo de pessoa Invalido"),
            };
        }
    }
}