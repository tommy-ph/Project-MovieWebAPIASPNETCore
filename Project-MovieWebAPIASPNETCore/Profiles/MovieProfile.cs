using AutoMapper;
using Project_MovieWebAPIASPNETCore.Models.Domain;
using Project_MovieWebAPIASPNETCore.Models.DTOs.Movies;

namespace Project_MovieWebAPIASPNETCore.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieReadDto>()
                .ForMember(dto => dto.Franchise, options => options.MapFrom(movieDomain => movieDomain.FranchiseId))
                .ForMember(dto => dto.Characters, options =>options
                .MapFrom(movieDomain => movieDomain.Characters
                .Select(character => $"{character.CharacterId}").ToList()));

            CreateMap<Movie, MovieEditDto>()
                .ForMember(dto => dto.FranchiseId, options => options
                .MapFrom(movieDomain => movieDomain.FranchiseId)).ReverseMap();


            CreateMap<Movie, MovieCreateDto>()
                .ForMember(dto => dto.FranchiseId, options => options
                .MapFrom(movieDomain => movieDomain.FranchiseId))
                .ReverseMap();
        }
    }
}
