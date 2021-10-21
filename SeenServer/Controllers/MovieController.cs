using Microsoft.AspNetCore.Mvc;
using SeenServer.Domain;
using SeenServer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeenServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAll();
            return Ok(movies);
        }

        // POST api/<MovieController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Movie movie)
        {
            var m = await _movieService.InsertAsync(movie);
            return Ok(m);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{movieId}")]
        public async Task<IActionResult> Delete(int movieId)
        {
            await _movieService.DeleteAsync(movieId);
            return Ok();
        }
    }
}
