using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Project_MovieWebAPIASPNETCore.Models.Domain
{
    public class Character
    {
        public int CharacterId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? FullName { get; set; }

        [MaxLength(255)]
        public string? Alias { get; set; }

        [MaxLength(255)]
        public string? Gender { get; set; }

        [MaxLength(2055)]
        public string? Picture { get; set; }

        public ICollection<Movie?> Movies { get; set; }
    }
}
