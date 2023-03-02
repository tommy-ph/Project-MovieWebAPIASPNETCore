using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MovieWebAPIASPNETCore.Exceptions;
using Project_MovieWebAPIASPNETCore.Models.Domain;
using Project_MovieWebAPIASPNETCore.Models.DTOs.Characters;
using Project_MovieWebAPIASPNETCore.Models.DTOs.Movies;
using Project_MovieWebAPIASPNETCore.Services;

namespace Project_MovieWebAPIASPNETCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //private readonly MovieDBContext _context;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // GET: api/Movies
        //Need to add the Configuration in Progam cs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetMovies()
        {
            return Ok(_mapper.Map<IEnumerable<MovieReadDto>>(await _movieService.GetAllMovies()));
        }

        // GET: api/Movies/5
        //Add Exception
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDto>> GetMovie(int id)
        {
            try
            {
                var movie = await _movieService.GetMovieById(id);
                var movieReadDTO = _mapper.Map<MovieReadDto>(movie);
                return Ok(movieReadDTO);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message,
                });
            }
        }

        //// PUT: api/Movies/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieEditDto movieEditDto)
        {
            if (id != movieEditDto.MovieId)
            {
                return BadRequest();
            }

            try
            {
                var movie = _mapper.Map<Movie>(movieEditDto);
                await _movieService.UpdateMovie(movie);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message,
                });
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieReadDto>> PostMovie(MovieCreateDto movieCreateDto)
        {
            var movie = _mapper.Map<Movie>(movieCreateDto);
            movie = await _movieService.UpdateMovie(movie);

            return CreatedAtAction(nameof(GetMovie), new { id = movie!.MovieId }, _mapper.Map<MovieReadDto>(movie));
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
           
            try
            {
                await _movieService.DeleteMovie(id);
            }
            catch (MovieNotFoundException ex)
            {

                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message,
                   
                });
            }
            return NoContent();
        }
    }
}
