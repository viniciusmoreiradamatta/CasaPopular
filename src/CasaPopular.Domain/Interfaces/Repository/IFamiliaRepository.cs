using CasaPopular.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaPopular.Domain.Interfaces.Repository
{
    public interface IFamiliaRepository
    {
        Task CadastrarFamilia(Familia familia);

        IEnumerable<Familia> ObterTodasFamiliasComtemplaveis();

        Task AdicionarSelecao(FamiliaSelecionada familiaSelecionada);
    }
}