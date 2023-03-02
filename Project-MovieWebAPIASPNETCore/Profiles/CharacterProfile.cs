using AutoMapper;
using Project_MovieWebAPIASPNETCore.Models.Domain;
using Project_MovieWebAPIASPNETCore.Models.DTOs.Characters;

namespace Project_MovieWebAPIASPNETCore.Profiles
{
    public class CharacterProfile: Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterReadDto>()
                .ForMember(movieDomain => movieDomain.Movies, options => options
                .MapFrom(movieDomain => movieDomain.Movies
                .Select(movieDomain => movieDomain.MovieId).ToList()))
                .ReverseMap();

            CreateMap<Character, CharacterEditDto>()
                .ForMember(dto => dto.MovieId, movieDomain => movieDomain
                .MapFrom(movieDomain => movieDomain.CharacterId))
                .ReverseMap();

            CreateMap<Character, CharacterCreateDto>()
                .ReverseMap();
        }
    }
}
