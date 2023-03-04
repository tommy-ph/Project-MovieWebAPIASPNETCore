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
using NuGet.Protocol.Core.Types;
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

        /// <summary>
        /// Gets all movies from the database
        /// </summary>
        /// <returns>A list of movies</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetMovies()
        {
            return Ok(_mapper.Map<IEnumerable<MovieReadDto>>(await _movieService.GetAllMovies()));
        }

        /// <summary>
        /// Gets a specifik movie based on a unique identifier 
        /// </summary>
        /// <param name="id">A unique identifier for a movie resource</param>
        /// <returns>A movie resource</returns>
        /// <returns>One specific movie or Status code 404 Not Found (failure)</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Updates a movie by movie Id
        /// </summary>
        /// <param name="id">The unique identifier for a movie</param>
        /// <param name="movieEditDto">Movies Edit DTO model to update on</param>
        /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Add a new movie
        /// </summary>
        /// <param name="movieCreateDto">Movie Create DTO model to add new Movie</param>
        /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<MovieReadDto>> PostMovie(MovieCreateDto movieCreateDto)
        {
            var movie = _mapper.Map<Movie>(movieCreateDto);
            movie = await _movieService.AddMovie(movie);

            return CreatedAtAction(nameof(GetMovie), new { id = movie!.MovieId }, _mapper.Map<MovieReadDto>(movie));
        }

        /// <summary>
        /// Delete a movie by movie id
        /// </summary>
        /// <param name="id">Id of the movie to delete</param>
        /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        private async Task<bool> MovieExists(int id)
        {
            return await _movieService.MovieExist(id);
        }


        /// <summary>
        /// Get all characters from a movie by movie id
        /// </summary>
        /// <param name="id">Id of the movie to get characters</param>
        /// <returns>List of characters of the movie or Status code 404 Not Found (failure)</returns>
        [HttpGet("{id:int}/Characters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CharacterReadDto>> GetMovieInCharacters(int id)
        {
            if (!await _movieService.MovieExist(id))
                return NotFound();

            var movieCharacter = await _movieService.GetCharactersByMovieId(id);
            var charactersReadDto = _mapper.Map<List<CharacterReadDto>>(movieCharacter);

            return Ok(charactersReadDto);
        }

        /// <summary>
        /// Update all characters from a movie by movie id with enumerable of character id's
        /// </summary>
        /// <param name="id">Id of the movie to update characters</param>
        /// <param name="characterMovieIds">Enumerable of character ids to replace</param>
        /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
        [HttpPut("{id:int}/Characters")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UppdateMovieCharacters(int id, IEnumerable<int> characterMovieIds)
        {
            if (!await _movieService.MovieExist(id))
            {
                return NotFound();
            }

            try
            {
                await _movieService.UpdateMovieCharactersByMovieId(id, characterMovieIds);
            }
            catch (MovieNotFoundException e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }
    }
}
