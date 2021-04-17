using CasaPopular.Data.Context;
using CasaPopular.Domain.Interfaces;
using System.Threading.Tasks;

namespace CasaPopular.Data.UnitOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly CasaPopularContext _context;

        public async Task CommitTransacao()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task IniciarTransacao()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}