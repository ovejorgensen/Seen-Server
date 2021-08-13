using Microsoft.EntityFrameworkCore;
using SeenServer.Data;
using SeenServer.Domain;
using SeenServer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeenServer.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Movie>> GetAll()
        {
            return _unitOfWork.MovieRepo.GetAll().ToListAsync();
        }

        public async Task<Movie> InsertAsync(Movie movie)
        {
            var m = await _unitOfWork.MovieRepo.InsertAsync(movie);
            await _unitOfWork.SaveAsync();

            return m;
        }

        public async Task DeleteAsync(int movieId)
        {
            _unitOfWork.MovieRepo.Delete(movieId);
            await _unitOfWork.SaveAsync();
        }
    }
}
