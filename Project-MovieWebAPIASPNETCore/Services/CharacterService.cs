using Microsoft.EntityFrameworkCore;
using Project_MovieWebAPIASPNETCore.Exceptions;
using Project_MovieWebAPIASPNETCore.Models;
using Project_MovieWebAPIASPNETCore.Models.Domain;

namespace Project_MovieWebAPIASPNETCore.Services
{
    public class CharacterService : ICharacterService
    {
        //Injection the DbContext here
        private readonly MovieDBContext _context;

        public CharacterService(MovieDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }

            return character;
        }

        public async Task<Character> UpdateCharacter(Character character)
        {
            var searchCharacter = await _context.Characters.FindAsync(character.CharacterId);
            if (searchCharacter == null)
            {
                throw new CharacterNotFoundException(character.CharacterId);
            }
            // _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<Character> AddCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return character;
        }

        public async Task<Character> DeleteCharacter(int id)
        {

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return character;
        }
    }
}
