using SeenServer.Data;
using SeenServer.Domain;
using SeenServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SeenServer.Repositories
{
    public class MovieRepo : RepoBase<Movie>, IMovieRepo
    {
        private readonly DbSet<Movie> _movies;

        public MovieRepo(DatabaseContext databaseContext) : base (databaseContext)
        {
            _movies = databaseContext.Set<Movie>();
        }
    }
}
