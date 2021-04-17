using System.Threading.Tasks;

namespace CasaPopular.Domain.Interfaces
{
    public interface IUnityOfWork
    {
        Task IniciarTransacao();

        Task CommitTransacao();

        Task SaveChanges();
    }
}