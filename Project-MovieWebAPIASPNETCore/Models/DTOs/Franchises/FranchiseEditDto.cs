namespace Project_MovieWebAPIASPNETCore.Models.DTOs.Franchises
{
    public class FranchiseEditDto
    {
        public int FranchiseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MovieId { get; set; }
    }
}
