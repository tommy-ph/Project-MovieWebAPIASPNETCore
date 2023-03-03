namespace Project_MovieWebAPIASPNETCore.Models.DTOs.Franchises
{
    public class FranchiseReadDto
    {
        public int FranchiseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Movies { get; set; }
    }
}
