using CasaPopular.Data.Context;
using CasaPopular.Domain.Entities;
using CasaPopular.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaPopular.Data.Repository
{
    public class FamiliaRepository : IFamiliaRepository
    {
        private readonly CasaPopularContext _context;

        public FamiliaRepository(CasaPopularContext casaPopularContext)
        {
            _context = casaPopularContext;
        }

        public async Task CadastrarFamilia(Familia familia)
        {
            await _context.Familia.AddAsync(familia);
        }

        public IEnumerable<Familia> ObterTodasFamiliasComtemplaveis()
        {
            return _context.Familia.Where(c => c.Status == Domain.Enuns.Status.CadastroValido &&
                                               !_context.FamiliaSelecionada.Select(cc => cc.IdFamilia).Contains(c.Id));
        }

        public async Task AdicionarSelecao(FamiliaSelecionada familiaSelecionada)
        {
            _context.FamiliaSelecionada.Add(familiaSelecionada);
        }
    }
}