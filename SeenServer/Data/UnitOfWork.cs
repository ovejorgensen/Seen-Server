using SeenServer.Repositories;
using SeenServer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SeenServer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IMovieRepo MovieRepo => new MovieRepo(_databaseContext);

        public Task<int> SaveAsync()
        {
            return _databaseContext.SaveChangesAsync();
        }
    }
}
