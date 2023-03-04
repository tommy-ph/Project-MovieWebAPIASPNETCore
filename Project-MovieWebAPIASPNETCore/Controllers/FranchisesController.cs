using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Project_MovieWebAPIASPNETCore.Exceptions;
using Project_MovieWebAPIASPNETCore.Models;
using Project_MovieWebAPIASPNETCore.Models.Domain;
using Project_MovieWebAPIASPNETCore.Models.DTOs.Characters;
using Project_MovieWebAPIASPNETCore.Models.DTOs.Franchises;
using Project_MovieWebAPIASPNETCore.Models.DTOs.Movies;
using Project_MovieWebAPIASPNETCore.Services;

namespace Project_MovieWebAPIASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all franchises
        /// </summary>
        /// <returns>List of all franchises</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<FranchiseReadDto>>> GetFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<FranchiseReadDto>>(await _franchiseService.GetAllFranchises()));
        }


        /// <summary>
        /// Get one specific franchise by franchise id
        /// </summary>
        /// <param name="id">Id of the franchise to get</param>
        /// <returns>One specific franchise or Status code 404 Not Found (failure)</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FranchiseReadDto>> GetFranchise(int id)
        {
            try
            {
                var franchise = await _franchiseService.GetFranchiseById(id);
                var franchiseReadDto = _mapper.Map<FranchiseReadDto>(franchise);
                return Ok(franchiseReadDto);
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message,
                });
            }
        }

        /// <summary>
        /// Get the movies in a specific franchise by the franchise id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A list of movies in a specifik franchise</returns>
        [HttpGet("{id:int}/Movies")]
        public async Task<ActionResult<MovieReadDto>> GetFranchiseMovies(int id)
        {
            if (!await _franchiseService.FranchiseExist(id))
                return NotFound();

            var franchiseMovies = await _franchiseService.GetAllMovieInFranchiseId(id);
            var moviesReadDto = _mapper.Map<List<MovieReadDto>>(franchiseMovies);

            return Ok(moviesReadDto);
        }

        // PUT: /franchises/1
        /// <summary>
        /// Update a franchise by franchise id
        /// </summary>
        /// <param name="id">Id of the franchise to update</param>
        /// <param name="franchiseEditDto">Franchise Edit DTO model to update on</param>
        /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutFranchise(int id, FranchiseEditDto franchiseEditDto)
        {
            if (id != franchiseEditDto.FranchiseId)
            {
                return BadRequest();
            }

            try
            {
                var franchise = _mapper.Map<Franchise>(franchiseEditDto);
                await _franchiseService.UpdateFranchise(franchise);
            }
            catch (FranchiseNotFoundException ex)
            {
                if (!await FranchiseExists(id))
                {
                    return NotFound(new ProblemDetails
                    {
                        Detail = ex.Message,
                    });
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Add a new franchise
        /// </summary>
        /// <param name="franchiseCreateDto">Franchise Create DTO model to add new Franchise</param>
        /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FranchiseReadDto>> PostFranchise(FranchiseCreateDto franchiseCreateDto)
        {
            var franchise = _mapper.Map<Franchise>(franchiseCreateDto);
            franchise = await _franchiseService.AddFranchise(franchise);
            return CreatedAtAction(nameof(GetFranchise), new { id = franchise!.FranchiseId }, _mapper.Map<FranchiseCreateDto>(franchise));
        }

        /// <summary>
        /// Delete a franchise by franchise id
        /// </summary>
        /// <param name="id">Id of the franchise to delete</param>
        /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            try
            {
                await _franchiseService.DeleteFranchise(id);
            }
            catch (FranchiseNotFoundException ex)
            {

                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message,

                });
            }
            return NoContent();
        }

        private async Task<bool> FranchiseExists(int id)
        {
            return await _franchiseService.FranchiseExist(id);
        }

        /// <summary>
        /// Updates a movies franchise by first selecting the id of the franchise you want to put and then the id of the movie you want to update the franchise of
        /// </summary>
        /// <param name="id">Id of the franchise</param>
        /// <param name="movieIds">Enumerable of movies id's to replace</param>
        /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
        [HttpPut("{id:int}/Movies")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMovieFranchise(int id, IEnumerable<int> movies)
        {
            if (!await _franchiseService.FranchiseExist(id))
            {
                return NotFound();
            }

            try
            {
                await _franchiseService.UpdateFranchiseMovie(id, movies);
            }
            catch (FranchiseNotFoundException e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

    }
}
