using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Project_MovieWebAPIASPNETCore.Models.Domain
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Title { get; set; }

        [MaxLength(255)]
        public string? Genre { get; set; }
        public int? Year { get; set; }

        [MaxLength(255)]
        public string? Director { get; set; }

        [MaxLength(2000)]
        public string? Picture { get; set; }

        [MaxLength(2000)]
        public string? Trailer { get; set; }

        public int? FranchisedId { get; set; }
        public Franchise? Franchise { get; set; }

        public ICollection<Character?> Characters { get; set; }


    }
}
