using System;
using System.Collections.Generic;

namespace CasaPopular.Domain.Entities
{
    public class FamiliaSelecionada
    {
        protected FamiliaSelecionada()
        {
        }

        public FamiliaSelecionada(Guid idFamilia, DateTime dataSelecao, int pontuacaoTotal, List<Criterio> criterios)
        {
            ID = Guid.NewGuid();
            IdFamilia = idFamilia;
            DataSelecao = dataSelecao;
            PontuacaoTotal = pontuacaoTotal;
            _Criterios = criterios;
        }

        public Guid ID { get; private set; }
        public Guid IdFamilia { get; private set; }
        public DateTime DataSelecao { get; private set; }
        public int PontuacaoTotal { get; private set; }
        private List<Criterio> _Criterios;
        public IReadOnlyCollection<Criterio> CriterioS => _Criterios;
    }
}