using CasaPopular.Domain.Entities;
using CasaPopular.Domain.Enuns;

namespace CasaPopular.Application.Factory
{
    public static class CriterioFactory
    {
        public static Criterio CriarCriterio(TipoCriterio tipo, int pontos)
        {
            return new Criterio(tipo.ToString(), pontos);
        }
    }
}