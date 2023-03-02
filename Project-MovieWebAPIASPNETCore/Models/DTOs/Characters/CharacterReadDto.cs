using Project_MovieWebAPIASPNETCore.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Project_MovieWebAPIASPNETCore.Models.DTOs.Characters
{
    public class CharacterReadDto
    {
        public int CharacterId { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }

        public List<string> Movies { get; set; }
    }
}
