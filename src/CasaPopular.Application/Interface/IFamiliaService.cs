using CasaPopular.Application.ViewModels;
using CasaPopular.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaPopular.Application.Interface
{
    public interface IFamiliaService
    {
        Task CadastrarFamilia(CadastroFamiliaViewModel viewModel);

        Task ContemplarFamilias();

        IEnumerable<Familia> ObterTodasFamiliasComtemplaveis();
    }
}