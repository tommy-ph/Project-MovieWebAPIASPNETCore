using Project_MovieWebAPIASPNETCore.Models.Domain;

namespace Project_MovieWebAPIASPNETCore.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int id);
        Task<Character> AddCharacter(Character character);
        Task<Character> UpdateCharacter(Character character);
        Task<Character> DeleteCharacter(int id);
    }
}
