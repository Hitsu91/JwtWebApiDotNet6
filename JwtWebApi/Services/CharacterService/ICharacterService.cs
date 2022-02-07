using JwtWebApi.DTOs.Character;
using JwtWebApi.Models;

namespace JwtWebApi.Services.CharacterService;

public interface ICharacterService
{
    Task<List<CharacterResponseDto>> GetAllCharacters();

    Task<CharacterResponseDto?> GetCharacterById(Guid id);

    Task<CharacterResponseDto> AddCharacter(CharacterRequestDto newCharacter);

    Task<CharacterResponseDto?> UpdateCharacter(Guid id, CharacterRequestDto updatedCharacter);

    Task<CharacterResponseDto?> DeleteCharacter(Guid id);

    Task<CharacterResponseDto?> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);
}
