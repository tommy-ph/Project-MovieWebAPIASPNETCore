using Project_MovieWebAPIASPNETCore.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Project_MovieWebAPIASPNETCore.Models.DTOs.Characters
{
    public class CharacterCreateDto
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }

    }
}
