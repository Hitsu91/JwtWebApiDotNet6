using AutoMapper;
using JwtWebApi.DTOs.Character;
using JwtWebApi.Models;

namespace JwtWebApi.Config;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Character, CharacterRequestDto>();
        CreateMap<CharacterRequestDto, Character>();
        CreateMap<Character, CharacterResponseDto>();
        CreateMap<CharacterResponseDto, Character>();
    }
}
