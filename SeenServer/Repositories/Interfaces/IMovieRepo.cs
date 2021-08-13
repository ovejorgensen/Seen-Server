using SeenServer.Domain;
using SeenServer.Repositories.Interfaces;

namespace SeenServer.Data
{
    public interface IMovieRepo : IRepoBase<Movie>
    {
        void Delete(int movieId);
    }
}