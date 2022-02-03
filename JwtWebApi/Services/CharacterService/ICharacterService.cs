using JwtWebApi.DTOs.Character;
using JwtWebApi.Models;

namespace JwtWebApi.Services.CharacterService;

public interface ICharacterService
{
    Task<List<Character>> GetCharacters();

    Task<Character?> GetCharacterById(Guid id);

    Task<Character> AddCharacter(CharacterRequestDto character);

    Task<Character?> UpdateCharacter(Guid id, CharacterRequestDto character);

    Task<Character?> DeleteCharacter(Guid id);
}
