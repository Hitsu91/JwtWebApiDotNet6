using AutoMapper;
using JwtWebApi.DTOs.Character;
using JwtWebApi.DTOs.Skill;
using JwtWebApi.DTOs.Weapon;
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
        CreateMap<Weapon, WeaponResponseDto>();
        CreateMap<Skill, GetSkillDto>();
    }
}
