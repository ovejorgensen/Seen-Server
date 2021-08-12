using SeenServer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SeenServer.Data
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();

        IMovieRepo MovieRepo{ get;  }
    }
}
