using SeenServer.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeenServer.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAll();
        Task<Movie> InsertAsync(Movie movie);
    }
}