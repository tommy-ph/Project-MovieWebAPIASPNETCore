using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MovieWebAPIASPNETCore.Exceptions;
using Project_MovieWebAPIASPNETCore.Models.Domain;
using Project_MovieWebAPIASPNETCore.Services;

namespace Project_MovieWebAPIASPNETCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //private readonly MovieDBContext _context;
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movies
        //Need to add the Configuration in Progam cs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return Ok(await _movieService.GetAllMovies());
        }

        // GET: api/Movies/5
        //Add Exception
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            #region Move to MovieService
            //var movie = await _context.Movies.FindAsync(id);

            //if (movie == null)
            //{
            //    return NotFound();
            //}

            //return movie;
            #endregion
            try
            {
                return await _movieService.GetMovieById(id);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message,
                    //Status = (int)HttpStatusCode.NotFound
                });
            }
        }

        //// PUT: api/Movies/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            try
            {
                await _movieService.UpdateMovie(movie);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message,
                    //Status = (int)HttpStatusCode.NotFound
                });
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            #region Move to AddMove in MovieService
            //_context.Movies.Add(movie);
            //await _context.SaveChangesAsync();
            #endregion


            return CreatedAtAction("GetMovie", new { id = movie.MovieId }, await _movieService.AddMovie(movie));
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            #region Move to DeleteMovie in MovieService
            //var movie = await _context.Movies.FindAsync(id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}

            //_context.Movies.Remove(movie);
            //await _context.SaveChangesAsync();
            #endregion

            try
            {
                await _movieService.DeleteMovie(id);
            }
            catch (MovieNotFoundException ex)
            {

                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message,
                    //Status = (int)HttpStatusCode.NotFound
                });
            }
            return NoContent();
        }

        //private bool MovieExists(int id)
        //{
        //    return _context.Movies.Any(e => e.MovieId == id);
        //}
    }
}
