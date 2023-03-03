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
using Project_MovieWebAPIASPNETCore.Models.DTOs.Movies;
using Project_MovieWebAPIASPNETCore.Services;

namespace Project_MovieWebAPIASPNETCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Character
        /// </summary>
        /// <returns>List of character</returns>
        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDto>>> GetCharacters()
        {
            return Ok(_mapper.Map<IEnumerable<CharacterReadDto>>(await _characterService.GetAllCharacters()));
        }

        // GET: api/Characters/5
        /// <summary>
        /// Get a specific character based on unique identifier
        /// </summary>
        /// <param name="id">A unique identifier for a character recource</param>
        /// <returns>A character recource</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDto>> GetCharacter(int id)
        {
            try
            {
                var character = await _characterService.GetCharacterById(id);
                var characterReadDto = _mapper.Map<CharacterReadDto>(character);
                return Ok(characterReadDto);
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message,
                });
            }
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update the character
        /// </summary>
        /// <param name="id">Get a unique identifier that needs to update</param>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterEditDto characterEditDto)
        {
            if (id != characterEditDto.CharacterId)
            {
                return BadRequest();
            }

            if (!await _characterService.CharacterExist(id))
            {
                return NotFound();
            }

            try
            {
                var character = _mapper.Map<Character>(characterEditDto);
                await _characterService.UpdateCharacter(character);
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message,
                });
            }

            return NoContent();

        }

        //// POST: api/Characters
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a character
        /// </summary>
        /// <param name="character"></param>
        /// <returns>Return adding character</returns>
        [HttpPost]
        public async Task<ActionResult<CharacterReadDto>> PostCharacter(CharacterCreateDto characterCreateDto)
        {
            var character = _mapper.Map<Character>(characterCreateDto);
            character = await _characterService.AddCharacter(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = character!.CharacterId }, _mapper.Map<CharacterReadDto>(character));
        }

        //// DELETE: api/Characters/5
        /// <summary>
        /// Delete a unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            try
            {
                await _characterService.DeleteCharacter(id);
            }
            catch (CharacterNotFoundException ex)
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
            return await _characterService.CharacterExist(id);
        }
    }
}
