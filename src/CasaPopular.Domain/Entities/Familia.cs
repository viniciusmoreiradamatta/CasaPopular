using CasaPopular.Domain.Entities.Base;
using CasaPopular.Domain.Enuns;
using CasaPopular.Domain.Extenssions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CasaPopular.Domain.Entities
{
    public class Familia : EntityBase
    {
        public Familia()
        {
        }

        public Familia(int status, List<Pessoa> pessoas)
        {
            Status = (Status)status;
            _Pessoas = pessoas;

            Validar();
        }

        public Status Status { get; private set; }
        private List<Pessoa> _Pessoas;
        public IReadOnlyCollection<Pessoa> Pessoas => _Pessoas;

        public decimal ObterValorTotalRenda() => _Pessoas.Select(c => c.RendaPessoa).Sum(c => c.Valor);

        public override void Validar()
        {
            if (_Pessoas.Count(c => c.Tipo == TipoPessoa.Pretendente) != 1)
                throw new Exception("Somente um pretendente por familia");

            if (_Pessoas.Count(c => c.Tipo == TipoPessoa.Conjuge) != 1)
                throw new Exception("Somente um conjuge é permitido");
        }

        public int TotalDependentes()
        {
            var listaDependentes = _Pessoas.Where(c => c.Tipo == TipoPessoa.Dependente).Select(c => (Dependente)c);

            return listaDependentes.Count(c => c.EhMenorDeIdade());
        }

        public int PontosPorIdadePretendente()
        {
            int pontos = 0;

            var pretendente = Pessoas.Single(c => c.Tipo == TipoPessoa.Pretendente);

            var idade = pretendente.DataNascimento.Idade();

            if (idade >= 45)
                pontos = 3;
            else if (idade >= 30 && idade <= 44)
                pontos = 2;
            else if (idade <= 30)
                pontos = 1;

            return pontos;
        }

        public int PontosPorRenda()
        {
            int pontos = 0;

            var rendaTotal = Pessoas.Sum(c => c.RendaPessoa.Valor);

            if (rendaTotal >= 900)
                pontos = 3;
            else if (rendaTotal >= 901 && rendaTotal <= 1500)
                pontos = 2;
            else if (rendaTotal >= 1501 && rendaTotal <= 2000)
                pontos = 1;

            return pontos;
        }

        public int PontosPorDependentes()
        {
            var totalDependentes = TotalDependentes();

            int pontos = totalDependentes > 2 ? 3 : 2;

            return pontos;
        }

        public int TotalPontos() => PontosPorIdadePretendente() + PontosPorRenda() + PontosPorDependentes();

        public void ContemplarFamilia()
        {
            if (Status != Status.CadastroValido)
                throw new Exception("Nao é possivel comtemplar a familia, verifique o cadastro");

            Status = Status.JaSelecionada;
        }
    }
}