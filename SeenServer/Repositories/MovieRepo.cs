using SeenServer.Data;
using SeenServer.Domain;
using SeenServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace SeenServer.Repositories
{
    public class MovieRepo : RepoBase<Movie>, IMovieRepo
    {
        private readonly DbSet<Movie> _movies;

        public MovieRepo(DatabaseContext databaseContext) : base (databaseContext)
        {
            _movies = databaseContext.Set<Movie>();
        }

        public void Delete(int movieId)
        {
            var movie = _movies.Where(movie => movie.MovieId == movieId).First();
            _movies.Remove(movie);
        }
    }
}
