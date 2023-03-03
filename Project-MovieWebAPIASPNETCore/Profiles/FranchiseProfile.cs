using AutoMapper;
using Project_MovieWebAPIASPNETCore.Models.Domain;
using Project_MovieWebAPIASPNETCore.Models.DTOs.Franchises;
using System.Runtime.CompilerServices;

namespace Project_MovieWebAPIASPNETCore.Profiles
{
    public class FranchiseProfile: Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseReadDto>()
             .ForMember(dto => dto.Movies, opttions => opttions
             .MapFrom(movieDomain => movieDomain.Movies
             .Select(m => m.MovieId).ToList()))
             .ReverseMap();


            CreateMap<Franchise, FranchiseEditDto>()
                .ForMember(m => m.MovieId, opt => opt.MapFrom(m => m.FranchiseId)).ReverseMap();


            CreateMap<Franchise, FranchiseCreateDto>().ReverseMap();
        }
    }
}
