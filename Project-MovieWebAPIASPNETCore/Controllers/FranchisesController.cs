using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDto>>> GetFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<FranchiseReadDto>>(await _franchiseService.GetAllFranchises()));
        }

        // GET: api/Franchises/5
        [HttpGet("{id}")]
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

        [HttpGet("{id:int}/Movies")]
        public async Task<ActionResult<MovieReadDto>> GetFranchiseMovies(int id)
        {
            if (!await _franchiseService.FranchiseExist(id))
                return NotFound();

            var franchiseMovies = await _franchiseService.GetAllMovieInFranchiseId(id);
            var moviesReadDto = _mapper.Map<List<MovieReadDto>>(franchiseMovies);

            return Ok(moviesReadDto);
        }

        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FranchiseReadDto>> PostFranchise(FranchiseCreateDto franchiseCreateDto)
        {
            var franchise = _mapper.Map<Franchise>(franchiseCreateDto);
            franchise = await _franchiseService.AddFranchise(franchise);
            return CreatedAtAction(nameof(GetFranchise), new { id = franchise!.FranchiseId }, _mapper.Map<FranchiseCreateDto>(franchise));
        }

        // DELETE: api/Franchises/5
        [HttpDelete("{id}")]
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

        [HttpPut("{id}/movies")]
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
