using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Project_MovieWebAPIASPNETCore.Models.Domain
{
    public class Franchise
    {
        public int FranchiseId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(3000)]
        public string? Description { get; set; }


        public ICollection<Movie?> Movies { get; set; }
    }
}
